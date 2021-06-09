using Messenger.Store;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace Messenger.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(config => config.EnableEndpointRouting = false)
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AuthenticationSetup();
            services.AddMessengerDataRepositories();
            services.AddSwaggerGen(setup =>
                {
                    setup.SwaggerDoc("v0.1", new OpenApiInfo
                    {
                        Title = "Messenger API",
                        Version = "0.1",
                    }
                    );

                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    setup.IncludeXmlComments(xmlPath);
                }
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseFileServer();

            app.UseSwagger(setup => setup.RouteTemplate = "/api/doc/{documentName}/apidocs.json");
            app.UseSwaggerUI(setup =>
                {                    
                    setup.SwaggerEndpoint("/api/doc/v0.1/apidocs.json", "Title");
                    setup.RoutePrefix = "api/doc";
                }
            );

            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
