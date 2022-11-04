using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace SevDesk.Extensions.Console.Extensions.Options;

public static class OptionsBuilderExtensions
{
	public static OptionsBuilder<TOptions> ValidateDataAnnotations<TOptions>(this OptionsBuilder<TOptions> builder)
		where TOptions : class
	{
		return builder.Validate(options =>
		{
			var validationResult = new List<ValidationResult>();
			Validator.TryValidateObject(
				options,
				new ValidationContext(options),
				validationResult
			);
			return validationResult.Count == 0;
		});
	}
}