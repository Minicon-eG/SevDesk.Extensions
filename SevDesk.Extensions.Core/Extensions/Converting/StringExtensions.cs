namespace SevDesk.Extensions.Core.Extensions.Converting;

public static class StringExtensions
{
	public static int ToInt(this string source)
	{
		return int.Parse(source);
	}
}