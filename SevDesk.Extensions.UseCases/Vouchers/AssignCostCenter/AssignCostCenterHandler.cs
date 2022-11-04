using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SevDesk.Extensions.ClientApi;
using SevDesk.Extensions.ClientApi.Api;
using SevDesk.Extensions.ClientApi.Client;
using SevDesk.Extensions.ClientApi.Model;
using SevDesk.Extensions.UseCases.Extensions.ClientApi;
using SevDesk.Extensions.UseCases.Extensions.Linq;
using SevDesl.Extensions.Dtos.Options;

namespace SevDesk.Extensions.UseCases.Vouchers.AssignCostCenter;

public sealed class AssignCostCenterHandler
	: IRequestHandler<AssignCostCenterRequest, AssignCostCenterResponse>
{
	private readonly IApiFactory _apiFactory;
	private readonly ILogger<AssignCostCenterHandler> _logger;
	private readonly IOptions<SevDeskOptions> _sevDeskOptions;

	public AssignCostCenterHandler(
		IApiFactory apiFactory,
		ILogger<AssignCostCenterHandler> logger,
		IOptions<SevDeskOptions> sevDeskOptions
	)
	{
		_apiFactory = apiFactory;
		_logger = logger;
		_sevDeskOptions = sevDeskOptions;
	}

	public async Task<AssignCostCenterResponse> Handle(
		AssignCostCenterRequest request,
		CancellationToken cancellationToken
	)
	{
		var costCentres = await _apiFactory.RefitApi<ICostCentreApi>().GetCostCentreAsync(cancellationToken);

		var api = _apiFactory.Api<VoucherApi>();

		var items = await api.GetAllDraftModelVoucherResponses(request.DaysToLookBack);

		var filteredItems = items
			.Where(e => e.CostCentre is null)
			.And(e => IsFilterMatch(request, e))
			.ToList();

		List<ModelVoucherResponse> updated = new();
		var targetCostCenter = ModelVoucherUpdateCostCentre(request.CostCenterName, costCentres.Objects);
		foreach (var voucher in filteredItems)
		{
			try
			{
				_ = await api.UpdateVoucherAsync(
					int.Parse(voucher.Id),
					new ModelVoucherUpdate
					(
						costCentre: targetCostCenter
					)
				);
				updated.Add(voucher);
			}
			catch (ApiException ex) when (ex.Message.Contains(
				                              "Cannot deserialize the current JSON object"))
			{
				_logger.LogDebug("{Exception}", ex);
			}

			_logger.LogInformation("Updated: {Voucher}", voucher.Id);
		}

		return new AssignCostCenterResponse
		{
			Value = updated
		};
	}

	private static bool IsFilterMatch(AssignCostCenterRequest request, ModelVoucherResponse e)
	{
		return (request.SupplierName is not null && e.SupplierName is not null &&
		        e.SupplierName.Equals(request.SupplierName))
		       || (request.SupplierId is not null && e.Supplier is not null &&
		           e.Supplier.Id.Equals(request.SupplierId));
	}

	public ModelVoucherUpdateCostCentre ModelVoucherUpdateCostCentre(
		string costCentre, List<CostCentreResponse> costCentres
	)
	{
		return new ModelVoucherUpdateCostCentre(
			int.Parse(costCentres.Single(item => item.Name == costCentre).Id),
			"CostCentreResponse"
		);
	}
}