using System.ComponentModel.DataAnnotations;

namespace SevDesl.Extensions.Dtos.Options;

public sealed class AssignSupplierOrganizationOptions
{
	private const int Year = 365;

	public const string SectionName = "AssignSupplierOrganization";
	
	[Range(1, Year)] public int DaysToLookBack { get; init; } = Year;
}