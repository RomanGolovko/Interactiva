using BLL.Implementation;
using BLL.Interfaces;
using DAL.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Configuration
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services, string connectionString)
        {
            services.AddDataAccessConfiguration(connectionString)
                .AddTransient<IEmployeesService, EmployeesService>();

            return services;
        }
    }
}
