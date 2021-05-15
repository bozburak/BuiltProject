using System;
using Core.CrossCuttingConcerns;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class CustomServiceCollection
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static void AddDependencyResolvers (this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}