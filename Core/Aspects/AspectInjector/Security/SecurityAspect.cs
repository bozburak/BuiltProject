using System;
using System.Linq;
using AspectInjector.Broker;
using Core.Extensions;
using Microsoft.AspNetCore.Http;

namespace Core.Aspects.AspectInjector.Logging
{
    [Aspect(Scope.Global)]
    [Injection(typeof(SecurityAspect))]
    public class SecurityAspect : Attribute
    {
        [Advice(Kind.Before)]
        public void Handle([Argument(Source.Triggers)] Attribute[] attributes)
        {
            var httpContextAccessor = attributes.OfType<HttpContextAccessor>().FirstOrDefault();
            var roles = attributes.OfType<string[]>().FirstOrDefault();
            var roleClaims = httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception("Authorization Denied");
        }
    }
}
