using Educational.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Educational.FileSystem
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddFileSystem(this IServiceCollection services)
        {
            return services.AddTransient<IFileProvider, FileProvider>();
        }
    }
}
