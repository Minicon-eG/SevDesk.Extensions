using Extensions.Dictionary;
using MediatR;
using Microsoft.Extensions.Logging;
using SevDesk.Extensions.ClientApi;
using SevDesk.Extensions.ClientApi.Api;
using SevDesk.Extensions.ClientApi.Client;
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
		var costCentres = await _apiFactory.RefitApi<ICostCentreApi>().GetCostCentreAsync(cancellationToken);

		var api = _apiFactory.Api<VoucherApi>();

		var items = await api.GetAllDraftModelVoucherResponses(request.DaysToLookBack);

		var filteredItems = items
			.Where(e => e.CostCentre is null)
			.And(e => ContainsSupplier(request, e))
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

			_logger.LogInformation(
				"Updated V:{Voucher} Request:{Request}",
				voucher.Id,
				request.ToDictionary()
			);
		}

		return new AssignCostCenterResponse
		{
			Value = updated
		};
	}

	private static bool ContainsSupplier(AssignCostCenterRequest request, ModelVoucherResponse e)
	{
		return request
			.SupplierNames
			.Contains(e.SupplierName, StringComparer.InvariantCultureIgnoreCase);
	}

	private ModelVoucherUpdateCostCentre ModelVoucherUpdateCostCentre(
		string costCentre, List<CostCentreResponse> costCentres
	)
	{
		return new ModelVoucherUpdateCostCentre(
			int.Parse(costCentres.Single(item => item.Name == costCentre).Id),
			"CostCentre"
		);
	}
}