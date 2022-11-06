using System.Net.Http.Headers;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Refit;
using SevDesk.Extensions.ClientApi.Api;
using SevDesk.Extensions.Dtos.Options;

namespace SevDesk.Extensions.ClientApi.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddApiFactory(this IServiceCollection services)
	{
		services.TryAddScoped<IApiFactory, ApiFactory>();

		var refitTypes = Assembly.GetExecutingAssembly()
			.GetTypes()
			.Where(type => type.IsAssignableTo(typeof(IRefitApi)))
			.Where(type => type.IsAbstract)
			.Where(type => typeof(IRefitApi) != type);

		foreach (var refitType in refitTypes)
			services
				.AddRefitClient(refitType)
				.ConfigureHttpClient(ConfigureHttpClient());

		return services;
	}

	private static Action<IServiceProvider, HttpClient> ConfigureHttpClient()
	{
		return (serviceProvider, httpClient) =>
		{
			httpClient.BaseAddress = new Uri("https://my.sevdesk.de/api/v1");
			httpClient.DefaultRequestHeaders.Authorization =
				AuthenticationHeaderValue.Parse(serviceProvider.GetRequiredService<IOptions<SevDeskOptions>>().Value
					.ApiKey);
		};
	}
}