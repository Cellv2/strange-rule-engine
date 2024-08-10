using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using RuleEngine.Models.Configuration;
using RuleEngine.Services;
using RuleEngine.Services.RuleEngine.Validators;
using RuleEngine.Services.RuleProcessor;
using RuleEngine.Services.RuleProcessor.Validators;
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

        services.TryAddEnumerable([
            ServiceDescriptor.Singleton<IRuleValidatorBase, MessageRuleValidator>(),
            ServiceDescriptor.Singleton<IRuleValidatorBase, NumberRuleValidator>()
        ]);

        services.AddSingleton<ICheckService, CheckService>();
        services.AddSingleton<IMessageService, MessageService>();
        services.AddSingleton<INumberService, NumberService>();
        services.AddSingleton<IRuleProcessor, RuleProcessor>();
    })
    .UseSerilog()
    .Build();

var checkService = host.Services.GetRequiredService<ICheckService>();
checkService.DoTheChecks();
