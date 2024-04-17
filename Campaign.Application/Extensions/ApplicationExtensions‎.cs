using Microsoft.Extensions.DependencyInjection;

namespace Campaign.Application.Extensions
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddApplicationConfiguration(this IServiceCollection services)
        {
            return services;
        }
    }
}
