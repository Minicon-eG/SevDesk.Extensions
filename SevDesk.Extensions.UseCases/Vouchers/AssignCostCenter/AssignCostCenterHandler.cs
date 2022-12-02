using MediatR;
using Microsoft.Extensions.Logging;
using SevDesk.Extensions.ClientApi;
using SevDesk.Extensions.ClientApi.Api;
using SevDesk.Extensions.ClientApi.Model;
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
		var getCostCentreAsync = _apiFactory.RefitApi<ICostCentreApi>().GetCostCentreAsync(cancellationToken);
		var getContactsAsync = _apiFactory.Api<ContactApi>().GetContactsAsync(ContactDepth.OnlyOrganizations);

		var api = _apiFactory.Api<VoucherApi>();
		var getVouchersAsync = request.OnlyDrafts
			? api.GetAllDraftModelVoucherResponsesAsync(request.DaysToLookBack)
			: api.GetAllModelVoucherResponsesAsync(request.DaysToLookBack);

		await Task.WhenAll(getVouchersAsync, getCostCentreAsync, getContactsAsync);

		var supplierNameOrIdToName = SupplierNameOrIdToName(getContactsAsync);
		var supplierNameToCostCenter = SupplierNameToCostCenter(request);
		var supplierNameOrIdToCostCenter = SupplierNameOrIdToCostCenter(
			supplierNameOrIdToName,
			supplierNameToCostCenter
		);

		List<ModelVoucherResponse> updated = new();

		await UpdateBySupplierNameAsync(
			request,
			getVouchersAsync.Result,
			supplierNameOrIdToName,
			supplierNameOrIdToCostCenter,
			getCostCentreAsync.Result,
			api,
			updated
		);

		await UpdateByVoucherIdAsync(
			request,
			getVouchersAsync.Result,
			getCostCentreAsync.Result,
			api,
			supplierNameOrIdToCostCenter,
			updated
		);

		return new AssignCostCenterResponse
		{
			Value = updated
		};
	}

	private async Task UpdateByVoucherIdAsync(
		AssignCostCenterRequest request,
		List<ModelVoucherResponse> getVouchers,
		ObjectsResult<CostCentreResponse> costCentres,
		VoucherApi api,
		Dictionary<string, string> supplierNameOrIdToCostCenter,
		List<ModelVoucherResponse> updated
	)
	{
		if (request.Vouchers.Any() == false)
		{
			return;
		}
		// Go through all vouchers check voucher id against request Values and use key to create a cost centre and update voucher
		foreach (var voucher in getVouchers)
		{
			string? costCentreName = request
				.Vouchers
				.SingleOrDefault(kv => kv.Value.Contains(int.Parse(voucher.Id)))
				.Key;

			if (costCentreName is null)
			{
				continue;
			}
			
			var costCentre = ModelVoucherUpdateCostCentre(
				costCentreName,
				costCentres.Objects
			);

			if (IsSameCostCenter(costCentre, voucher))
			{
				continue;
			}
			_ = await api.UpdateVoucherAsync(
				int.Parse(voucher.Id),
				new ModelVoucherUpdate
				(
					costCentre: costCentre
				)
			);

			updated.Add(voucher);

			_logger.LogInformation(
				"Updated Voucher by Supplier: {Voucher} -> CostCenter: {CostCenter}",
				voucher.Id,
				costCentre.Id
			);
		}
	}

	private static bool IsSameCostCenter(ModelVoucherUpdateCostCentre costCentre, ModelVoucherResponse voucher)
	{
		return costCentre.Id.ToString() == voucher.CostCentre?.Id;
	}

	private static Dictionary<string, string> SupplierNameOrIdToCostCenter(
		Dictionary<string, string> supplierNameOrIdToName, Dictionary<string, string> supplierNameToCostCenter)
	{
		return supplierNameOrIdToName
			.Where(item => supplierNameToCostCenter.Keys.Contains(item.Value))
			.Select(item => (SupplierNameOrId: item.Key, CostCenter: supplierNameToCostCenter[item.Value]))
			.ToDictionary(e => e.SupplierNameOrId, e => e.CostCenter);
	}

	private static Dictionary<string, string> SupplierNameToCostCenter(AssignCostCenterRequest request)
	{
		return request.Mapping
			.SelectMany(mapping => mapping.Value.Select(item => (SupplierName: item, CostCenter: mapping.Key)))
			.ToDictionary(e => e.SupplierName, e => e.CostCenter);
	}

	private static Dictionary<string, string> SupplierNameOrIdToName(Task<GetContactResponse> getContactsAsync)
	{
		return getContactsAsync
			.Result
			.Objects
			.Select(e => new KeyValuePair<string, string>(e.Name, e.Name))
			.Union(getContactsAsync.Result.Objects.Select(e => new KeyValuePair<string, string>(e.Id, e.Name)))
			.ToDictionary(e => e.Key, e => e.Value);
	}

	private async Task UpdateBySupplierNameAsync(AssignCostCenterRequest request,
		List<ModelVoucherResponse> getVouchers,
		Dictionary<string, string> supplierNameOrIdToName,
		Dictionary<string, string> supplierNameOrIdToCostCenter,
		ObjectsResult<CostCentreResponse> costCentres,
		IVoucherApi api,
		List<ModelVoucherResponse> updated)
	{
		var filteredItems = getVouchers
			.Where(e => e.CostCentre is null)
			.And(e => e.Supplier?.Id is not null)
			.And(e => IsSupplierKnownAndNeedToBeMapped(request, e, supplierNameOrIdToName))
			.ToList();

		foreach (var voucher in filteredItems)
		{
			var costCentre = ModelVoucherUpdateCostCentre(
				supplierNameOrIdToCostCenter[voucher.Supplier!.Id],
				costCentres.Objects
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
				"Updated Voucher by Id: {Voucher} -> CostCenter: {CostCenter}",
				voucher.Id,
				costCentre.Id
			);
		}
	}

	private static bool IsSupplierKnownAndNeedToBeMapped(AssignCostCenterRequest request, ModelVoucherResponse voucher,
		Dictionary<string, string> supplierIdToNameMapping)
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