using Microsoft.AspNetCore.Hosting; 
using Microsoft.Extensions.Hosting;
using System;

namespace NewWorldWars
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var bot = new Bot();
            bot.RunAsync().GetAwaiter().GetResult();
        }

        public static IHostBuilder CreateWebHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
