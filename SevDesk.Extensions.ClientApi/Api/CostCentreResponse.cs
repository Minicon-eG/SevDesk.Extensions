namespace SevDesk.Extensions.ClientApi.Api;

public record CostCentreResponse(
	string Id,
	string AdditionalInformation,
	DateTime Create,
	DateTime Update,
	string Number,
	string Name,
	string Color,
	string PostingAccount,
	string DefaultCentre = "0",
	string ObjectName = "CostCentreResponse",
	SevClientReference? SevClient = null
);