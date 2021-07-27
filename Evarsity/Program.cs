using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Evarsity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .UseContentRoot(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                .Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.Sources.Clear();

                    var env = hostingContext.HostingEnvironment;

                    config.AddIniFile("MyIniConfig.ini", optional: true, reloadOnChange: true)
                          .AddIniFile($"MyIniConfig.{env.EnvironmentName}.ini",
                                         optional: true, reloadOnChange: true);

                    config.AddEnvironmentVariables();                 

                    if (args != null)
                    {
                        config.AddCommandLine(args);
                    }
                })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
            
    }
}
