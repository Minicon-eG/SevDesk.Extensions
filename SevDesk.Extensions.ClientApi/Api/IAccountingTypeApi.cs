using Refit;
using SevDesk.Extensions.ClientApi.Model;

namespace SevDesk.Extensions.ClientApi.Api;

public interface IAccountingTypeApi : IRefitApi
{
	[Get("/AccountingType")]
	Task<ObjectsResult<AccountingType>> GetAccountingTypeAsync(
		bool emptyState = false,
		bool countAll = true,
		bool useClientAccountingChart = true,
		string embed = "accountingSystemNumber",
		bool onlyOwn = false,
		int offset = 0,
		int limit = 50,
		CancellationToken cancellationToken = default
	);
}

public interface ISaveVoucherApi : IRefitApi
{
	// embed=accountingType,accountingType.accountingSystemNumber,supplier,object,additionalInfo,debit,acquisitionCostReference,propertyIsFirstVisit,accountDatev,propertyCateringTipForeignCurrency
	// &cft=e31a6df1c9b18aecb4b9c42044440bc1
	[Multipart]
	[Post("/Voucher/Factory/saveVoucher")]
	Task<SaveVoucherResponse> SaveVoucherAsync(
		params IEnumerable<KeyValuePair<string, string>>[] request
	);
}

public sealed class SaveVoucherRequest
{
	public bool ExistenceCheck { get; } = true;
	public List<ModelVoucherPosSave> VoucherPosSave { get; init; }
	public int Id { get; init; }

	public IEnumerable<KeyValuePair<string, string>> ToForm()
	{
		yield return new KeyValuePair<string, string>("existenceCheck", ExistenceCheck.ToString());
		yield return new KeyValuePair<string, string>("id", Id.ToString());

		for (var index = 0; index < VoucherPosSave.Count; index++)
		{
			yield return new KeyValuePair<string, string>(
				$"VoucherPosSave[{index}][id]",
				VoucherPosSave[index].Id
			);
			yield return new KeyValuePair<string, string>(
				$"VoucherPosSave[{index}][accountingType][id]",
				VoucherPosSave[index].AccountingType.Id
			);
			yield return new KeyValuePair<string, string>(
				$"VoucherPosSave[{index}][accountingType][objectName]",
				VoucherPosSave[index].AccountingType.ObjectName
			);
		}
	}
}

public sealed class ModelVoucherPosSave
{
	public AccountingTypeReference AccountingType { get; init; }
	public string Id { get; init; }
}