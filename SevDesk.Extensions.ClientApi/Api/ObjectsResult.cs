namespace SevDesk.Extensions.ClientApi.Api;

public record ObjectsResult<T>(List<T> Objects, string Total, int Offset, int Limit);