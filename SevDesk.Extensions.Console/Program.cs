using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SevDesk.Extensions.Console;
using SevDesk.Extensions.Console.Extensions.Options;
using SevDesk.Extensions.Dtos.Options;
using SevDesk.Extensions.UseCases.Extensions.DependencyInjection;
using SevDesk.Extensions.UseCases.Vouchers.AssignCostCenter;
using SevDesk.Extensions.UseCases.Vouchers.AssignSupplierOrganization;

var configuration = new ConfigurationBuilder()
	.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
	.AddUserSecrets<Program>()
	.AddCommandLine(args)
	.Build();
await Host.CreateDefaultBuilder(args)
	.ConfigureServices(
		(context, services) =>
		{
			services.AddUseCases();

			services.Configure<SevDeskOptions>(
					configuration.GetSection(SevDeskOptions.SectionName)
				)
				.AddOptions<SevDeskOptions>()
				.ValidateDataAnnotations();

			services.Configure<AssignSupplierOrganizationRequest>(
					configuration.GetSection("AssignSupplierOrganization")
				)
				.AddOptions<AssignSupplierOrganizationRequest>()
				.ValidateDataAnnotations();

			services.Configure<AssignCostCenterRequest>(
					configuration.GetSection("AssignCostCenter")
				)
				.AddOptions<AssignCostCenterRequest>()
				.ValidateDataAnnotations();

			services.AddHostedService<SevDeskWorker>();
		}
	).RunConsoleAsync();