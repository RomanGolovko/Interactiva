using BLL.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace WebUI.Configuration
{
    public static class WebUIConfiguration
    {
        public static IServiceCollection AddWebUIConfiguration(this IServiceCollection services, string connectionString)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddCors();
            services.AddHealthChecks();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Social Veterinary Surgeon", Version = "v1" });
            });

            services.AddServicesConfiguration(connectionString);

            return services;
        }

        public static void UseAPIConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseCors(builder => builder.AllowAnyOrigin());

            app.UseHealthChecks("/healthcheck");

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Social Veterinary Surgeon V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles();
            if (!env.IsDevelopment())
                app.UseSpaStaticFiles();

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                    spa.UseAngularCliServer(npmScript: "start");
            });
        }
    }
}
