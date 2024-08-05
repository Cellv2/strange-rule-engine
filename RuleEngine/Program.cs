using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

Log.Information("Starting up");

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => {

        //services.AddOptions<TestSettings>().Configure<IConfiguration>((options, configuration) => configuration.GetSection(nameof(TestSettings)).Bind(options));

        //services.AddSingleton<IBarService, BarService>();
        //services.AddSingleton<IFooService, FooService>();

    })
    .UseSerilog()
    .Build();