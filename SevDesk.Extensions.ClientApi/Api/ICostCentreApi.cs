using Refit;

namespace SevDesk.Extensions.ClientApi.Api;

public interface ICostCentreApi : IRefitApi
{
	[Get("/CostCentre")]
	Task<ObjectsResult<CostCentreResponse>> GetCostCentreAsync(CancellationToken cancellationToken = default);
}