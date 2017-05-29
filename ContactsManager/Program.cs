using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ContactsManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .UseUrls("http://*:5000")
                .UseApplicationInsights()
                .Build();

            host.Run();
        }
    }
}
