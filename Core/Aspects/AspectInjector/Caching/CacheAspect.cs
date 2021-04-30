using AspectInjector.Broker;
using Core.Aspects.AspectInjector.Caching.Triggers;
using Core.CrossCuttingConcerns;
using System;
using System.Linq;

namespace Core.Aspects.AspectInjector.Caching
{
    [Aspect(Scope.Global)]
    public class CacheAspect
    {

        [Advice(Kind.Around)]
        public object Handle([Argument(Source.Triggers)] Attribute[] attributes, [Argument(Source.Arguments)] object[] arguments, [Argument(Source.Target)] Func<object[], object> method)
        {
            object result = null;
            var trigger = attributes.OfType<CacheAttribute>().FirstOrDefault();
            var isExist = trigger._cacheManager.IsSet(trigger._key);
            if (isExist)
            {
                result = trigger._cacheManager.Get(trigger._key);
            }
            else
            {
                result = method(arguments);
                trigger._cacheManager.Set(trigger._key, result, trigger._duration);
            }
            return result;
        }
    }
}