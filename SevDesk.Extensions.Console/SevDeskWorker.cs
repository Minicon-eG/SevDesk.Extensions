using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SevDesk.Extensions.UseCases.Vouchers.AssignAccountingType;
using SevDesk.Extensions.UseCases.Vouchers.AssignCostCenter;
using SevDesk.Extensions.UseCases.Vouchers.AssignSupplierOrganization;

namespace SevDesk.Extensions.Console;

public sealed class SevDeskWorker : BackgroundService
{
	private readonly IServiceProvider _serviceProvider;

	public SevDeskWorker(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		System.Console.WriteLine($"Starting {GetType().Name}");
		while (!stoppingToken.IsCancellationRequested)
		{
			System.Console.WriteLine("1: AssignSupplierOrganization");
			System.Console.WriteLine("2: AssignCostCenter");
			var result = System.Console.ReadKey().Key;

			switch (result)
			{
				case ConsoleKey.D1:
					await SendFromOptions<AssignSupplierOrganizationRequest>(_serviceProvider);
					break;
				case ConsoleKey.D2:
					await SendFromOptions<AssignCostCenterRequest>(_serviceProvider);
					break;
				case ConsoleKey.D3:
					await SendFromOptions<AssignAccountingTypeRequest>(_serviceProvider);
					break;
				default:
					await Task.Delay(1000, stoppingToken);
					break;
			}
		}
	}

	private async Task SendFromOptions<T>(IServiceProvider serviceProvider) where T : class
	{
		var mediatr = serviceProvider.GetRequiredService<IMediator>();
		var request = serviceProvider.GetRequiredService<IOptionsSnapshot<T>>().Value;

		await mediatr.Send(request);
	}
}