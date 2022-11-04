using Refit;

namespace SevDesk.Extensions.ClientApi.Api;

public interface ICostCentreApi : IRefitApi
{
	[Get("/CostCentreResponse")]
	ObjectsResult<CostCentreResponse> GetCostCentre();

	[Get("/CostCentreResponse")]
	Task<ObjectsResult<CostCentreResponse>> GetCostCentreAsync(CancellationToken cancellationToken = default);
}