using System.ComponentModel.DataAnnotations;
using MediatR;
using SevDesk.Extensions.Core.DataAnnotations;

namespace SevDesk.Extensions.UseCases.Vouchers.AssignCostCenter;

public sealed class AssignCostCenterRequest : IRequest<AssignCostCenterResponse>
{
	private const int Year = 365;

	public AssignCostCenterRequest()
	{
	}

	public AssignCostCenterRequest(string[] supplierNames, string costCenterName, int daysToLookBack)
	{
		SupplierNames = supplierNames;
		CostCenterName = costCenterName;
		DaysToLookBack = daysToLookBack;
	}

	[Required]
	[StringLengthEnumerable(100, MinimumLength = 1)]
	public string[] SupplierNames { get; init; } = Array.Empty<string>();

	[Required]
	[StringLength(50, MinimumLength = 1)]
	public string CostCenterName { get; init; } = default!;

	[Range(1, Year * 3)] public int DaysToLookBack { get; init; } = Year;
}