using AspectInjector.Broker;
using System;
using System.Diagnostics;

namespace Core.Aspects.AspectInjector.Logging
{
    [Aspect(Scope.Global)]
    [Injection(typeof(LogAspect))]
    public class LogAspect : Attribute
    {
        [Advice(Kind.Around)]
        public object Handle([Argument(Source.Name)] string name, [Argument(Source.Arguments)] object[] arguments, [Argument(Source.Target)] Func<object[], object> method)
        {
            Debug.WriteLine($"Executing method {name}");
            var sw = Stopwatch.StartNew();
            var result = method(arguments);
            sw.Stop();
            Debug.WriteLine($"Executed method {name} in {sw.ElapsedMilliseconds} ms");
            return result;
        }
    }
}
