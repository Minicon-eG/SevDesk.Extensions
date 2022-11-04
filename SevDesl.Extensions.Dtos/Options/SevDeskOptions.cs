using System.ComponentModel.DataAnnotations;

namespace SevDesl.Extensions.Dtos.Options;

public sealed class SevDeskOptions
{
	public const string SectionName = "SevDesk";

	[Url] [Required] public string ApiKey { get; init; } = "";

	[StringLength(32, MinimumLength = 32)]
	[Required]
	public string ApiUrl { get; init; } = "";
}