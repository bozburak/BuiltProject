using AspectInjector.Broker;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using System;
using Core.Aspects.AspectInjector.Logging;
using Microsoft.AspNetCore.Http;

namespace Core.Aspects.AspectInjector.Security.Triggers
{
    [Injection(typeof(SecurityAspect))]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class SecurityAttribute : Attribute
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;
        public SecurityAttribute(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = CustomServiceCollection.ServiceProvider.GetService<IHttpContextAccessor>();
        }
    }
}
