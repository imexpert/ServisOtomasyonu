using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Avr.ServisOtomasyonu.Api
{
    public class Program
    {
        static IConfiguration Configuration;

        public static readonly string Namespace = typeof(Program).Namespace;
        public static readonly string AppName = Namespace.Split(".")[0];

        [Obsolete]
        public static void Main(string[] args)
        {
            Configuration = GetConfiguration();

            CreateMSSqlLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .UseSerilog();

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            return builder.Build();
        }

        [Obsolete]
        public static void CreateMSSqlLogger()
        {

            var connectionString = Configuration["ConnectionString"];
            var tableName = "Logs";

            var columnOption = new ColumnOptions();
            columnOption.Store.Remove(StandardColumn.MessageTemplate);

            columnOption.AdditionalDataColumns = new Collection<DataColumn>
                            {
                                new DataColumn {DataType = typeof (string), ColumnName = "OtherData"},
                            };

            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Warning()
                            .MinimumLevel.Override("SerilogDemo", LogEventLevel.Information)
                            .WriteTo.MSSqlServer(connectionString, tableName,
                                    columnOptions: columnOption

                                    )
                            .CreateLogger();
        }
    }
}
