using Microsoft.Extensions.DependencyInjection;
using Core.CrossCuttingConcerns;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using System;

namespace Core.Extensions
{
    public static class CustomServiceCollection
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static void AddDependencyResolvers (this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}