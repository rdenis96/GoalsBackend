using Microsoft.AspNetCore.Builder;
using NJsonSchema;
using NJsonSchema.Generation;
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
            app.UseCustomSwaggerUi();
        }
    }
}