using clean_arch.common.Extensions;
using clean_arch.infrastructure;
using clean_arch_2022.Seed;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using System.IO;
using System.Net;

namespace clean_arch_2022
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = GetConfiguration();


            Log.Information("Configuring web host ({ApplicationContext})...", Program.AppName);
            var host = BuildWebHost(configuration, args);

            Log.Information("Applying migrations ({ApplicationContext})...", Program.AppName);
            host.MigrateDbContext<ApplicationDbContext>((context, services) =>
            {
                var env = services.GetService<IWebHostEnvironment>();
                var settings = services.GetService<IOptions<AppSettings>>();
                var logger = services.GetService<ILogger<ApplicationDbContextSeed>>();

                new ApplicationDbContextSeed()
                    .SeedAsync(context, env, settings, logger)
                    .Wait();
            });

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            return builder.Build();
        }

        static IWebHost BuildWebHost(IConfiguration configuration, string[] args) =>
          WebHost.CreateDefaultBuilder(args)
          .CaptureStartupErrors(false)
          .ConfigureKestrel(options =>
          {
              var (httpPort, grpcPort) = GetDefinedPorts(configuration);
              options.Listen(IPAddress.Any, httpPort, listenOptions =>
              {
                  listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
                  //listenOptions.UseHttps();
              });

              options.Listen(IPAddress.Any, grpcPort, listenOptions =>
              {
                  listenOptions.Protocols = HttpProtocols.Http2;
              });
          })
          .ConfigureAppConfiguration(x => x.AddConfiguration(configuration))
          .UseStartup<Startup>()
          .UseContentRoot(Directory.GetCurrentDirectory())
          //.UseSerilog((builderContext, config) =>
          //{
          //    config
          //        .Enrich.WithProperty("ApplicationContext", Program.AppName)
          //        .Enrich.FromLogContext()
          //        .ReadFrom.Configuration(builderContext.Configuration);
          //})
          .Build();


        static (int httpPort, int grpcPort) GetDefinedPorts(IConfiguration config)
        {
            var grpcPort = config.GetValue("GRPC_PORT", 5001);
            var port = config.GetValue("PORT", 80);
            return (port, grpcPort);
        }

        public static string Namespace = typeof(Startup).Namespace;
        public static string AppName = "Test App";
    }
}
