using System.ComponentModel.DataAnnotations;

namespace SevDesk.Extensions.UseCases;

public record SevDeskApiRequest(string ApiKey, string ApiUrl)
{
	public const string SectionName = "SevDesk";

	public SevDeskApiRequest()
		: this(default, default)
	{
	}

	[Url] [Required] public string ApiKey { get; init; } = "";

	[StringLength(32, MinimumLength = 32)]
	[Required]
	public string ApiUrl { get; init; } = "";
}