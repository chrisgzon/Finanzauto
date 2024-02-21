using Finanzauto.Dominio.Common;
using Finanzauto.Infrastructure.Persistence.Contexts;
using Finanzauto.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Finanzauto.Infrastructure.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FinanzautoDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")!);
            });

            services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            return services;
        }
    }
}
