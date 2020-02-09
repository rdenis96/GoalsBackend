﻿using MainServer.Extensions;
using MainServer.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MainServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.SslPort = 44350;
                options.EnableEndpointRouting = false;
            })
            .AddJsonOptions(options =>
            {
            }).SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddSwaggerDocument();

            //services.Configure<GeneralSettings>(Configuration.GetSection(nameof(GeneralSettings)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.EnvironmentName == Environments.Development)
            {
                app.UseDeveloperExceptionPage();
                app.UseErrorHandler();
                app.UseCustomSwaggerUi();
            }
            app.UseStaticFiles();
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}