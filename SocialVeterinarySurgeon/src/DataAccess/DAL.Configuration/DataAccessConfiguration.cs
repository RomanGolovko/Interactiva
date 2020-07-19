using DAL.Implementation.EF.Configuration;
using DAL.Implementation.EF.Repositories;
using DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Model;

namespace DAL.Configuration
{
    public static class DataAccessConfiguration
    {
        public static IServiceCollection AddDataAccessConfiguration(this IServiceCollection services, string connectionString)
        {
            services.AddEFConfiguration(connectionString)
                    .AddTransient<IBaseRepository<Employee>, EmployeesRepository>()
                    .AddTransient<IBaseRepository<Pet>, PetsRepository>();

            return services;
        }
    }
}
