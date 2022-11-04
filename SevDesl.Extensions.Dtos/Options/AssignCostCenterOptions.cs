using System.ComponentModel.DataAnnotations;

namespace SevDesl.Extensions.Dtos.Options;

public sealed class AssignCostCenterOptions
{
	private const int Year = 365;

	public const string SectionName = "AssignCostCenter";
	
	[Required]
	[StringLength(500, MinimumLength = 1)]
	public string SupplierName { get; init; }
	
	[Required]
	[StringLength(500, MinimumLength = 1)]
	public string CostCenterName { get; init; }

	[Range(1, Year)] public int DaysToLookBack { get; init; } = Year;
}