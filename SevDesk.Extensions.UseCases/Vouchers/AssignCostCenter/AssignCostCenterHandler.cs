using System.Diagnostics.Metrics;
using Extensions.Dictionary;
using MediatR;
using Microsoft.Extensions.Logging;
using SevDesk.Extensions.ClientApi;
using SevDesk.Extensions.ClientApi.Api;
using SevDesk.Extensions.ClientApi.Model;
using SevDesk.Extensions.Core.Extensions.Converting;
using SevDesk.Extensions.UseCases.Extensions.ClientApi;
using SevDesk.Extensions.UseCases.Extensions.Linq;

namespace SevDesk.Extensions.UseCases.Vouchers.AssignCostCenter;

public sealed class AssignCostCenterHandler
	: IRequestHandler<AssignCostCenterRequest, AssignCostCenterResponse>
{
	private readonly IApiFactory _apiFactory;
	private readonly ILogger<AssignCostCenterHandler> _logger;

	public AssignCostCenterHandler(
		IApiFactory apiFactory,
		ILogger<AssignCostCenterHandler> logger
	)
	{
		_apiFactory = apiFactory;
		_logger = logger;
	}

	public async Task<AssignCostCenterResponse> Handle(
		AssignCostCenterRequest request,
		CancellationToken cancellationToken
	)
	{
		var costCentres =  _apiFactory.RefitApi<ICostCentreApi>().GetCostCentreAsync(cancellationToken);
		var contactsApi = _apiFactory.Api<ContactApi>();
		var contactResponse = contactsApi.GetContactsAsync(ContactDepth.OnlyOrganizations);
		
		var api = _apiFactory.Api<VoucherApi>();
		
		var items =  api.GetAllDraftModelVoucherResponses(request.DaysToLookBack);

		await Task.WhenAll(items, costCentres, contactResponse);

		// Get the final supplierName from its id or Name
		var supplierNameOrIdToName = contactResponse.Result.Objects
			.Select(e => new KeyValuePair<string, string>(e.Name, e.Name))
			.Union(contactResponse.Result.Objects.Select(e => new KeyValuePair<string, string>(e.Id, e.Name)))
			.ToDictionary(e => e.Key, e => e.Value);
		
		var filteredItems = items
			.Result
			.Where(e => e.CostCentre is null)
			.And(e => e.Supplier?.Id is not null)
			.And(e => IsSupplierKnownAndNeedToBeMapped(request, e, supplierNameOrIdToName))
			.ToList();

		// Get mapped SupplierName to CostCenter
		var supplierNameToCostCenter = request.Mapping
			.SelectMany(mapping => mapping.Value.Select(item => (SupplierName: item, CostCenter: mapping.Key)))
			.ToDictionary(e => e.SupplierName, e => e.CostCenter);

		// Merge the two dictionaries for supplierIdToNameMapping
		var supplierNameOrIdToCostCenter  = supplierNameOrIdToName
			.Where(item => supplierNameToCostCenter.Keys.Contains(item.Value))
			.Select(item => (SupplierNameOrId: item.Key, CostCenter: supplierNameToCostCenter[item.Value]))
				.ToDictionary(e => e.SupplierNameOrId, e => e.CostCenter);

		List<ModelVoucherResponse> updated = new();

		foreach (var voucher in filteredItems)
		{
			var costCentre = ModelVoucherUpdateCostCentre(
				supplierNameOrIdToCostCenter[voucher.Supplier!.Id],
				costCentres.Result.Objects
			);
			_ = await api.UpdateVoucherAsync(
				int.Parse(voucher.Id),
				new ModelVoucherUpdate
				(
					costCentre: costCentre
				)
			);
			
			updated.Add(voucher);

			_logger.LogInformation(
				"Updated Voucher:{Voucher} -> CostCenter:{CostCenter}",
				voucher.Id,
				costCentre.Id
			);
		}

		return new AssignCostCenterResponse
		{
			Value = updated
		};
	}

	private static bool IsSupplierKnownAndNeedToBeMapped(AssignCostCenterRequest request, ModelVoucherResponse voucher, Dictionary<string, string> supplierIdToNameMapping)
	{
		if (voucher.Supplier?.Id is null)
		{
			return false;
		}
		
		return (supplierIdToNameMapping.ContainsKey(voucher.Supplier.Id))
			&& request.Mapping.Values.Any(item => item.Contains(supplierIdToNameMapping[voucher.Supplier.Id]));
			
	}

	private ModelVoucherUpdateCostCentre ModelVoucherUpdateCostCentre(
		string costCentre,
		IEnumerable<CostCentreResponse> costCentres
	)
	{
		return new ModelVoucherUpdateCostCentre(
			int.Parse(costCentres.Single(item => item.Name == costCentre).Id),
			"CostCentre"
		);
	}
}