using MediatR;

namespace SevDesk.Extensions.UseCases.Vouchers.AssignCostCenter;

public sealed record AssignCostCenterRequest(
	int DaysToLookBack,
	string? SupplierName,
	string CostCenterName,
	string? SupplierId) : IRequest<AssignCostCenterResponse>;