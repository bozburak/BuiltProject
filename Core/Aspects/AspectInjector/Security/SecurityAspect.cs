using System;
using System.Collections.Generic;
using System.Linq;
using AspectInjector.Broker;
using Core.Aspects.AspectInjector.Security.Triggers;
using Core.Extensions;

namespace Core.Aspects.AspectInjector.Security
{
    [Aspect(Scope.Global)]
    public class SecurityAspect
    {
        [Advice(Kind.Before)]
        public void Handle([Argument(Source.Triggers)] Attribute[] attributes)
        {
            var securityAttiribute = attributes.OfType<SecurityAttribute>().FirstOrDefault();
            var roleClaims = securityAttiribute._httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in securityAttiribute._roles)
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
