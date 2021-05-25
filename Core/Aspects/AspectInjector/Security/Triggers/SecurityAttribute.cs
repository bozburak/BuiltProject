using AspectInjector.Broker;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Core.Aspects.AspectInjector.Security.Triggers
{
    [Injection(typeof(SecurityAspect))]
    public class SecurityAttribute : Attribute
    {
        public IEnumerable<string> _roles;
        public IHttpContextAccessor _httpContextAccessor;
        public SecurityAttribute(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = CustomServiceCollection.ServiceProvider.GetService<IHttpContextAccessor>();
        }
    }
}
