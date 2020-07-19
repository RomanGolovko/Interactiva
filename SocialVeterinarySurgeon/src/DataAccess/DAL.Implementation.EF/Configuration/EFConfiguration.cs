using DAL.Implementation.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Implementation.EF.Configuration
{
    public static class EFConfiguration
    {
        public static IServiceCollection AddEFConfiguration(this IServiceCollection services, string connectionString)
        {
            ///TODO: filled connection string
            var connection = connectionString ?? "connectionString";

            services.AddDbContext<AppContext>(opt => opt.UseSqlServer(connection, x => x.MigrationsAssembly("WebUI")));

            return services;
        }
    }
}
