using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CompartiMOSS.Xamarin.MobileAppService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                 .ConfigureAppConfiguration((hostingContext, config) =>
                 {
                     var env = hostingContext.HostingEnvironment;
                     config.AddJsonFile("appsettings.json", true)
                         .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);
                     config.AddEnvironmentVariables();
                 })
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}