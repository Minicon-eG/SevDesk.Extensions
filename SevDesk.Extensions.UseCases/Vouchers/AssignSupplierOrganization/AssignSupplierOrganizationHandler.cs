using MediatR;
using Microsoft.Extensions.Logging;
using SevDesk.Extensions.ClientApi;
using SevDesk.Extensions.ClientApi.Api;
using SevDesk.Extensions.ClientApi.Client;
using SevDesk.Extensions.ClientApi.Model;
using SevDesk.Extensions.Core.Extensions.Converting;
using SevDesk.Extensions.UseCases.Extensions.ClientApi;
using SevDesk.Extensions.UseCases.Extensions.Linq;

namespace SevDesk.Extensions.UseCases.Vouchers.AssignSupplierOrganization;

public sealed class AssignSupplierOrganizationHandler
	: IRequestHandler<AssignSupplierOrganizationRequest, AssignSupplierOrganizationResponse>
{
	private readonly IApiFactory _apiFactory;
	private readonly ILogger<AssignSupplierOrganizationHandler> _logger;

	public AssignSupplierOrganizationHandler(
		IApiFactory apiFactory,
		ILogger<AssignSupplierOrganizationHandler> logger
	)
	{
		_apiFactory = apiFactory;
		_logger = logger;
	}

	public async Task<AssignSupplierOrganizationResponse> Handle(
		AssignSupplierOrganizationRequest request,
		CancellationToken cancellationToken
	)
	{
		var contactsApi = _apiFactory.Api<ContactApi>();
		var getContactsAsync = contactsApi.GetContactsAsync(ContactDepth.OnlyOrganizations);

		IVoucherApi api = _apiFactory.Api<VoucherApi>();
		var getVouchersAsync =  request.OnlyDrafts ? api.GetAllDraftModelVoucherResponsesAsync(request.DaysToLookBack) : api.GetAllModelVoucherResponsesAsync(request.DaysToLookBack);

		await Task.WhenAll(getVouchersAsync, getContactsAsync);

		var contacts = getContactsAsync
			.Result
			.Objects
			.GroupBy(item => item.Name)
			.Select(
				item => item.OrderBy(i => i.Id).First()
			).ToDictionary(e => e.Name, e =>
				new ModelVoucherUpdateSupplier
				(
					objectName: e.ObjectName,
					id: int.Parse(e.Id)
				)
			);
		
		var filteredItems = getVouchersAsync
			.Result
			.Where(IsSupplierNameNotEmpty)
			.And(HasNoSupplierAssigned)
			.ToList();

		List<ModelVoucherResponse> updated = new();
		foreach (var voucher in filteredItems)
			try
			{
				string supplierName = request.SupplierMapping.ContainsKey(voucher.SupplierName!)
					? request.SupplierMapping[voucher.SupplierName!] 
					: voucher.SupplierName!;
				
				if (!contacts.ContainsKey(supplierName))
				{
					_logger.LogWarning(
						"Supplier is not present: {Supplier}",
						voucher.SupplierName
					);
					continue;
				}

				var supplier = contacts[supplierName];
				
				var response = await api.UpdateVoucherAsync(
					int.Parse(voucher.Id),
					new ModelVoucherUpdate
					(
						supplier: supplier
					)
				);
				updated.Add(response.Objects);

				_logger.LogInformation("Updated: {Voucher}", response.Objects.Id);
			}
			catch (ApiException ex) when (
				ex.Message.Contains(
					"Cannot deserialize the current JSON object"
				)
			)
			{
				_logger.LogDebug("{Exception}", ex);
			}

		return new AssignSupplierOrganizationResponse
		{
			Value = updated
		};
	}

	private async Task<List<(int Id, string Name)>> AccountingTypesAsync(CancellationToken cancellationToken)
	{
		List<(int Id, string Name)> result = new();
		var total = 0;
		const int take = 50;
		var requestCount = 0;
		do
		{
			var accountingTypes = await _apiFactory
				.RefitApi<IAccountingTypeApi>()
				.GetAccountingTypeAsync(
					offset: requestCount * take,
					limit: take,
					cancellationToken: cancellationToken
				);

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

	private static bool IsSupplierNameNotEmpty(ModelVoucherResponse origin)
	{
		return !string.IsNullOrWhiteSpace(origin.SupplierName);
	}

	private static bool HasNoSupplierAssigned(ModelVoucherResponse e)
	{
		return e.Supplier?.Id is null;
	}
}