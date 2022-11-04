using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SevDesk.Extensions.ClientApi.Extensions.DependencyInjection;

namespace SevDesk.Extensions.UseCases.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddUseCases(this IServiceCollection services)
	{
		services.AddApiFactory();

		services.AddMediatR(typeof(ServiceCollectionExtensions).Assembly);

		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
		return services;
	}
}