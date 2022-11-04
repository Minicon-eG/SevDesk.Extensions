using System.ComponentModel.DataAnnotations;
using MediatR;

namespace SevDesk.Extensions.UseCases.Vouchers.AssignSupplierOrganization;

public sealed record AssignSupplierOrganizationRequest(
	[Range(1, AssignSupplierOrganizationRequest.Year)]
	int DaysToLookBack = AssignSupplierOrganizationRequest.Year
) : IRequest<AssignSupplierOrganizationResponse>
{
	private const int Year = 365;
}