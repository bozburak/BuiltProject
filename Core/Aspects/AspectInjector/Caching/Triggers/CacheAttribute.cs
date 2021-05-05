using AspectInjector.Broker;
using Core.CrossCuttingConcerns;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using System;

namespace Core.Aspects.AspectInjector.Caching.Triggers
{
    [Injection(typeof(CacheAspect))]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class CacheAttribute : Attribute
    {
        public int _duration;
        public string _key;
        public ICacheManager _cacheManager;
        public CacheAttribute(string key, int duration = 60)
        {
            _key = key;
            _duration = duration;
            _cacheManager = CustomServiceCollection.ServiceProvider.GetService<ICacheManager>();
        }
    }
}
