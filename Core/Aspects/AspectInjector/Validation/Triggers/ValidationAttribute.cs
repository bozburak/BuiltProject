using AspectInjector.Broker;
using FluentValidation;
using System;

namespace Core.Aspects.AspectInjector.Validation.Triggers
{
    [Injection(typeof(ValidationAspect))]
    public class ValidationAttribute : Attribute
    {
        public Type _validatorType;
        public ValidationAttribute(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("This is not validation class");
            }

            _validatorType = validatorType;
        }

    }
}
