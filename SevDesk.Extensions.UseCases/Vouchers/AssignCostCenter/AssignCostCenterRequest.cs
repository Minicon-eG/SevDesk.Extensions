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

	public AssignCostCenterRequest(
		Dictionary<string, string[]> mapping,
		int daysToLookBack,
		bool onlyDrafts,
		Dictionary<string, int[]> vouchers
	)
	{
		Mapping = mapping;
		DaysToLookBack = daysToLookBack;
		OnlyDrafts = onlyDrafts;
		Vouchers = vouchers;
	}

	[StringLengthDictionaryKey(100, 1)] public Dictionary<string, string[]> Mapping { get; init; } = new();
	[StringLengthDictionaryKey(100, 1)] public Dictionary<string, int[]> Vouchers { get; init; } = new();
	[Range(1, Year * 3)] public int DaysToLookBack { get; init; } = Year;

	public bool OnlyDrafts { get; init; } = false;
}