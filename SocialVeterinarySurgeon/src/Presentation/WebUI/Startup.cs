using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebUI.Configuration;

namespace WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWebUIConfiguration(Configuration["ConnectionString:DefaultConnection"]);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseAPIConfiguration(env);
        }
    }
}
