using Educational.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Educational.Persistence
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<EducationalDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IEducationalDbContext>(provider => provider.GetRequiredService<EducationalDbContext>());

            return services;
        }
    }
}
