using System.ComponentModel.DataAnnotations;
using MediatR;
using SevDesk.Extensions.Core.DataAnnotations;

namespace SevDesk.Extensions.UseCases.Vouchers.AssignSupplierOrganization;

public sealed class AssignSupplierOrganizationRequest : IRequest<AssignSupplierOrganizationResponse>
{
	private const int Year = 365;

	public AssignSupplierOrganizationRequest()
	{
	}

	public AssignSupplierOrganizationRequest(
		int daysToLookBack,
		bool onlyDrafts,
		IDictionary<string, string> supplierMapping
	)
	{
		DaysToLookBack = daysToLookBack;
		OnlyDrafts = onlyDrafts;
		SupplierMapping = supplierMapping.ToDictionary(e => e.Key, e => e.Value);
	}

	[Range(1, Year * 3)] public int DaysToLookBack { get; init; } = Year;
	
	[StringLengthDictionaryKey(50, 1)] 
	[StringLengthDictionaryValue(50, 1)]
	public Dictionary<string, string> SupplierMapping { get; init; } = new();
	
	public bool OnlyDrafts { get; init; } = false;
}