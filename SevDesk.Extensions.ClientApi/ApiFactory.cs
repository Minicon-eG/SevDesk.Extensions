using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SevDesk.Extensions.ClientApi.Client;
using SevDesl.Extensions.Dtos.Options;

namespace SevDesk.Extensions.ClientApi;

public sealed class ApiFactory : IApiFactory
{
	private readonly IOptions<SevDeskOptions> _options;
	private readonly IServiceProvider _serviceProvider;

	public ApiFactory(IOptions<SevDeskOptions> options, IServiceProvider serviceProvider)
	{
		_options = options;
		_serviceProvider = serviceProvider;
	}

	public T RefitApi<T>()
	{
		return _serviceProvider.GetRequiredService<T>();
	}

	public T Api<T>() where T : IApiAccessor, new()
	{
		var result = new T();
		result.Configuration.BasePath = "https://my.sevdesk.de/api/v1";
		result.Configuration.DefaultHeader.TryAdd(
			"Authorization",
			_options.Value.ApiKey
		);
		result.Configuration.UserAgent = "SevDesk.Extensions.ClientApi";

		return result;
	}
}

public interface IApiFactory
{
	T RefitApi<T>();

	T Api<T>()
		where T : IApiAccessor, new();
}