using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RuleEngine.Models.Configuration;
using RuleEngine.Services;
using Serilog;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

Log.Information("Starting up");

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => {
        services.AddOptions<CheckSettings>().BindConfiguration(nameof(CheckSettings));

        services.AddSingleton<ICheckService, CheckService>();
    })
    .UseSerilog()
    .Build();

var checkService = host.Services.GetRequiredService<ICheckService>();
checkService.DoTheChecks();
