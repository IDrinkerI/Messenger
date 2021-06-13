using Messenger.DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Messenger.Api
{
    internal sealed class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(config => config.EnableEndpointRouting = false)
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AuthenticationSetup();
            services.AddMessengerDataRepositories();
            services.AddSwaggerGenCustom();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseFileServer();

            app.UseSwagger(setup => setup.RouteTemplate = "/api/doc/{documentName}/apidoc.json");
            app.UseSwaggerUI(setup =>
                {
                    setup.SwaggerEndpoint("/api/doc/v1/apidoc.json", "Messenger API");
                    setup.RoutePrefix = "api/doc";
                }
            );

            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
