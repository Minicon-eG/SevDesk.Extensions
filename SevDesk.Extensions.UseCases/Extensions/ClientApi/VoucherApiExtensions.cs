using SevDesk.Extensions.ClientApi.Api;
using SevDesk.Extensions.ClientApi.Model;

namespace SevDesk.Extensions.UseCases.Extensions.ClientApi;

public static class VoucherApiExtensions
{
	public static async Task<List<ModelVoucherResponse>> GetAllDraftModelVoucherResponses(this IVoucherApi api,
		int daysToLookBack)
	{
		List<ModelVoucherResponse> items = new();
		var callNumber = 0;
		const int daysInWeek = 7;
		do
		{
			var result = await api.GetVouchersAsync(
				startDate: (int)DateTimeOffset.Now.AddDays(-daysToLookBack + callNumber * daysInWeek)
					.ToUnixTimeSeconds()
				, endDate: (int)DateTimeOffset.Now.AddDays(-daysToLookBack + callNumber * daysInWeek + daysInWeek)
					.ToUnixTimeSeconds()
				, status: VoucherStatus.Draft
			);

			items.AddRange(result.Objects);
			callNumber++;
		} while (-daysToLookBack + callNumber * daysInWeek + daysInWeek < 0);

		return items;
	}
}