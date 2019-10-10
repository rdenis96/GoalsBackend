using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MainServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            System.Net.ServicePointManager.DefaultConnectionLimit = 10000;
            ThreadPool.SetMinThreads(8, 8);
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseEnvironment("Development")
                //.UseIISIntegration()
                //.UseKestrel(options =>
                //{
                //    options.AddServerHeader = false;
                //    options.Limits.MaxConcurrentConnections = 10000;
                //    options.Limits.MaxConcurrentUpgradedConnections = 10000;
                //    options.Limits.MaxRequestBodySize = 500 * 1024;
                //    options.Limits.MinRequestBodyDataRate = new MinDataRate(bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
                //    options.Limits.MinResponseDataRate = new MinDataRate(bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));

                //    options.Listen(new IPEndPoint(IPAddress.Any, 44350), listenOptions =>
                //    {
                //        //var httpsConnectionAdapterOptions = new HttpsConnectionAdapterOptions()
                //        //{
                //        //    SslProtocols = System.Security.Authentication.SslProtocols.Tls | System.Security.Authentication.SslProtocols.Tls11 | System.Security.Authentication.SslProtocols.Tls12,
                //        //    ServerCertificate = new X509Certificate2("", "")
                //        //};
                //        //listenOptions.UseHttps(httpsConnectionAdapterOptions);
                //    });
                //})
                .UseStartup<Startup>();
    }
}