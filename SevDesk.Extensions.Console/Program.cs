using System.Runtime.InteropServices;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SevDesk.Extensions.Console.Extensions.Options;
using SevDesk.Extensions.UseCases.Extensions.DependencyInjection;
using SevDesk.Extensions.UseCases.Vouchers.AssignCostCenter;
using SevDesk.Extensions.UseCases.Vouchers.AssignSupplierOrganization;
using SevDesl.Extensions.Dtos.Options;

var configuration = new ConfigurationBuilder()
	.AddJsonFile("appsettings.json")
	.AddUserSecrets<Program>()
	.Build();

await Host.CreateDefaultBuilder(args)
	.ConfigureServices(
		(context, services) =>
		{
			services.AddUseCases();

			services
				.Configure<SevDeskOptions>(
					configuration.GetSection(SevDeskOptions.SectionName)
				)
				.AddOptions<SevDeskOptions>()
				.ValidateDataAnnotations();

			services.Configure<AssignSupplierOrganizationOptions>(
					configuration.GetSection(AssignSupplierOrganizationOptions.SectionName)
				)
				.AddOptions<AssignSupplierOrganizationOptions>()
				.ValidateDataAnnotations();
			
			services.Configure<AssignCostCenterOptions>(
					configuration.GetSection(AssignCostCenterOptions.SectionName)
				)
				.AddOptions<AssignCostCenterOptions>()
				.ValidateDataAnnotations();

			services.AddHostedService<SevDeskWorker>();
		}
	).RunConsoleAsync();

public sealed class SevDeskWorker : BackgroundService
{
	private readonly IServiceProvider _serviceProvider;

	public SevDeskWorker(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		Console.WriteLine($"Starting {this.GetType().Name}");
		while (!stoppingToken.IsCancellationRequested)
		{
			
			Console.WriteLine("1: AssignSupplierOrganization");
			Console.WriteLine("2: AssignCostCenter");
			var result = Console.ReadKey().Key;

			
			switch (result)
			{
				case ConsoleKey.D1:
					await AssignSupplierOrganizationAsync(_serviceProvider);
					break;
				case ConsoleKey.D2:
					await AssignCostCenterAsync(_serviceProvider);
					break;
				default:
					await Task.Delay(1000, stoppingToken);
					break;
			}
			
		}
	}

	private async Task AssignSupplierOrganizationAsync(IServiceProvider serviceProvider)
	{
		var mediatr = serviceProvider.GetRequiredService<IMediator>();
		var options = serviceProvider.GetRequiredService<IOptions<AssignSupplierOrganizationOptions>>().Value;

		await mediatr
			.Send(
				new AssignSupplierOrganizationRequest(options.DaysToLookBack)
			);
	}
	private async Task AssignCostCenterAsync(IServiceProvider serviceProvider)
	{
		var mediatr = serviceProvider.GetRequiredService<IMediator>();
		var options = serviceProvider.GetRequiredService<IOptions<AssignCostCenterOptions>>().Value;

		await mediatr
			.Send(
				new AssignCostCenterRequest(options.DaysToLookBack, options.SupplierName, options.CostCenterName, options.SupplierName)
			);
	}
}