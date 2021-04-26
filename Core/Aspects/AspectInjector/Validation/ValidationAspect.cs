using AspectInjector.Broker;
using Core.Aspects.AspectInjector.Validation.Triggers;
using Core.CrossCuttingConcerns.Validation;
using FluentValidation;
using System;
using System.Linq;

namespace Core.Aspects.AspectInjector.Validation
{
    [Aspect(Scope.Global)]
    public class ValidationAspect
    {
        [Advice(Kind.Before)]
        public void Validate([Argument(Source.Triggers)] Attribute[] attributes, [Argument(Source.Arguments)] object[] arguments)
        {
            foreach (var trigger in attributes.OfType<ValidationAttribute>())
            {
                var validator = (IValidator)Activator.CreateInstance(trigger._validatorType);
                ValidationTool.Validate(validator, arguments[0]);
            }
        }
    }
}
