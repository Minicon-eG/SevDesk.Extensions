using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace SevDesk.Extensions.Core.DataAnnotations;

public sealed class StringLengthDictionaryKeyAttribute : StringLengthAttribute
{
	public StringLengthDictionaryKeyAttribute(int maximumLength, int minimumLength = 0)
		: base(maximumLength)
	{
		MinimumLength = minimumLength;
	}

	public override bool IsValid(object value)
	{
		if (value.GetType().IsAssignableTo(typeof(IDictionary<string, object>)))
			return false;

		return (value as IDictionary<string, object>)!
			.Keys
			.All(str => str.Length <= MaximumLength && str.Length >= MinimumLength);
	}
}