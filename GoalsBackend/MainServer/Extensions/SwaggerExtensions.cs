using Microsoft.AspNetCore.Builder;
using NJsonSchema;
using NJsonSchema.Generation;
using NSwag.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MainServer.Extensions
{
    public static class SwaggerExtensions
    {
        public static void UseCustomSwaggerUi(this IApplicationBuilder app)
        {
            app.UseSwaggerUi3(typeof(Startup).GetTypeInfo().Assembly, settings =>
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling = PropertyNameHandling.CamelCase;
                settings.GeneratorSettings.DefaultEnumHandling = EnumHandling.Integer;
                //settings.GeneratorSettings.OperationProcessors.Add(new NSwagOperationProcessor());
                settings.GeneratorSettings.IsAspNetCore = true;
            });
        }
    }
}