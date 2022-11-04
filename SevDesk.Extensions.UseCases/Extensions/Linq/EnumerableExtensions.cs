namespace SevDesk.Extensions.UseCases.Extensions.Linq;

public static class EnumerableExtensions
{
	public static IEnumerable<TSource> And<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
	{
		return source.Where(predicate);
	}
}