using Finanzauto.Application.Students;
using Microsoft.Extensions.DependencyInjection;

namespace Finanzauto.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();

            return services;
        }
    }
}
