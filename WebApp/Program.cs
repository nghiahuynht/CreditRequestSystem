using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureKestrel((context, options) =>
            {
                // Only apply Kestrel configurations when running in development
                if (context.HostingEnvironment.IsDevelopment())
                {
                    options.Limits.MaxRequestHeadersTotalSize = 100048576; 
                }
            })
            .UseStartup<Startup>();
    }
}
