using AspectInjector.Broker;
using Core.CrossCuttingConcerns;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using System;

namespace Core.Aspects.AspectInjector.Caching.Triggers
{
    [Injection(typeof(CacheAspect))]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class CacheAttribute : Attribute
    {
        private static readonly Lazy<MemoryCacheManager> lazy = new Lazy<MemoryCacheManager>(() => new MemoryCacheManager(new Microsoft.Extensions.Caching.Memory.MemoryCache(new Microsoft.Extensions.Caching.Memory.MemoryCacheOptions())));
        public ICacheManager _cacheManager;
        public int _duration;
        public string _key;
        public CacheAttribute(string key, int duration = 60)
        {
            _key = key;
            _duration = duration;
            _cacheManager = lazy.Value;
        }
    }
}
