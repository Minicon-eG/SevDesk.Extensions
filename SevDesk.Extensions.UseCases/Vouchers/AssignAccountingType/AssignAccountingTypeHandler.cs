using MediatR;
using Microsoft.Extensions.Logging;
using SevDesk.Extensions.ClientApi;
using SevDesk.Extensions.ClientApi.Api;
using SevDesk.Extensions.Core.Extensions.Converting;

namespace SevDesk.Extensions.UseCases.Vouchers.AssignAccountingType;

public sealed class AssignAccountingTypeHandler
	: IRequestHandler<AssignAccountingTypeRequest, AssignAccountingTypeResponse>
{
	private readonly IApiFactory _apiFactory;
	private readonly ILogger<AssignAccountingTypeHandler> _logger;

	public AssignAccountingTypeHandler(
		IApiFactory apiFactory,
		ILogger<AssignAccountingTypeHandler> logger
	)
	{
		_apiFactory = apiFactory;
		_logger = logger;
	}

	public async Task<AssignAccountingTypeResponse> Handle(
		AssignAccountingTypeRequest request,
		CancellationToken cancellationToken
	)
	{
		throw new NotImplementedException();
	}

	private async Task<List<(int Id, string Name)>> AccountingTypesAsync(CancellationToken cancellationToken)
	{
		List<(int Id, string Name)> result = new();
		var total = 0;
		var take = 50;
		var requestCount = 0;
		do
		{
			var accountingTypes = await _apiFactory
				.RefitApi<IAccountingTypeApi>()
				.GetAccountingTypeAsync(
					offset: requestCount * take,
					limit: take,
					cancellationToken: cancellationToken);
			total = accountingTypes.Total.ToInt();

			result.AddRange(
				accountingTypes
					.Objects
					.Select(item => (int.Parse(item.Id), item.Name))
			);
			requestCount++;
		} while (total > result.Count);

		return result;
	}
}