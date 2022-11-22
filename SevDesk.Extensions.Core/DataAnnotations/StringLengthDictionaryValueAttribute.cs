using System.ComponentModel.DataAnnotations;

namespace SevDesk.Extensions.Core.DataAnnotations;

public sealed class StringLengthDictionaryValueAttribute : StringLengthAttribute
{
	public StringLengthDictionaryValueAttribute(int maximumLength, int minimumLength = 0)
		: base(maximumLength)
	{
		MinimumLength = minimumLength;
	}

	public override bool IsValid(object value)
	{
		if (value.GetType().IsAssignableTo(typeof(IDictionary<object, string>)))
			return false;

		return (value as IDictionary<object, string>)!
			.Values
			.All(str => str.Length <= MaximumLength && str.Length >= MinimumLength);
	}
}