using System.Text.Json;
using System.Text.Json.Serialization;

namespace SevDesk.Extensions.Core.Extensions.Converting;

public static class ObjectExtensions
{
	public static string ToJson(this object obj)
	{
		return JsonSerializer.Serialize(
			obj, new JsonSerializerOptions
			{
				WriteIndented = true,
				Converters =
				{
					new JsonStringEnumConverter()
				}
			}
		);
	}
	
}