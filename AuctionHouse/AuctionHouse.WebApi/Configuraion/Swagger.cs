﻿using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace AuctionHouse.WebApi.Configuraion
{
    /// <summary>
    ///     Contains extension methods for Swagger configuration.
    /// </summary>
    public static class Swagger
    {
        /// <summary>
        ///     Adds swagger to service collection.
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <returns></returns>
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Version = "v1",
                    Title = "Auction House API",
                    Description = "Auction House API"
                });
                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"Bearer", new string[] { }},
                };

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
                c.AddSecurityRequirement(security);
                c.OrderActionsBy(apiDesc => $"{apiDesc.GroupName}_{apiDesc.HttpMethod}");
                c.IncludeXmlComments(GetXmlCommentsPath());
            });

            return services;
        }

        /// <summary>
        ///     Uses swagger in application builder.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <returns></returns>
        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Auction House v1");
            });
            return app;
        }

        /// <summary>
        ///     Gets the xml documentation path.
        /// </summary>
        /// <returns></returns>
        private static string GetXmlCommentsPath()
        {
            var basePath = System.AppContext.BaseDirectory;
            var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
            return Path.Combine(basePath, fileName);
        }
    }
}