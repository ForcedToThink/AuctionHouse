﻿using AuctionHouse.WebApi.Configuraion;
using AuctionHouse.WebApi.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuctionHouse.WebApi
{
    /// <summary>
    ///     The Startup.
    /// </summary>
    public class Startup
    {
        /// <summary>
        ///     Creates an instance of <see cref="Startup"/>
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        ///     The Configuration.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        ///     Configures the application services.
        /// </summary>
        /// <param name="services">Service collection.</param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddJwtAuthentication(Configuration);
            services.AddSwagger();
            services.AddDatabase(Configuration);
            services.AddDependencies();
            services.AddMvc(options =>
                    {
                        options.Filters.Add(new CustomAuthorizeFilter(new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser().Build()));
                    })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        /// <summary>
        ///     Configures application.
        /// </summary>
        /// <param name="app">Application builder.</param>
        /// <param name="env">Hosting environment.</param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
                builder.WithOrigins("http://localhost:4200")
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            app.UseAuthentication();
            app.UseMvc();
            app.UseSwaggerConfiguration();
        }
    }
}
