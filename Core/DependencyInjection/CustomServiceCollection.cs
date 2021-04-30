using Microsoft.Extensions.DependencyInjection;
using Core.CrossCuttingConcerns;
using Core.CrossCuttingConcerns.Caching.Microsoft;

namespace Core.DependencyInjection
{
    public static class CustomServiceCollection
    {
        public static IServiceCollection AddDependencyResolvers (this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();

            return ServiceTool.Create(services);
        }
    }
}
