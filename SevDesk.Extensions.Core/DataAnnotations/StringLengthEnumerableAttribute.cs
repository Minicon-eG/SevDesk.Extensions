using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace SevDesk.Extensions.Core.DataAnnotations;

public sealed class StringLengthEnumerableAttribute : StringLengthAttribute
{
	public StringLengthEnumerableAttribute(int maximumLength)
		: base(maximumLength)
	{
	}

	public override bool IsValid(object value)
	{
		if (value.GetType().IsAssignableTo(typeof(IEnumerable<string>)))
			return false;

		return (value as IEnumerable<string>)!
			.All(str => str.Length <= MaximumLength && str.Length >= MinimumLength);
	}
}