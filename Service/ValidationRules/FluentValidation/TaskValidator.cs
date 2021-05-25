using Core.AutoMapper.DTOs;
using FluentValidation;

namespace Service.ValidationRules.FluentValidation
{
    public class TaskValidator : AbstractValidator<TaskDto>
    {
        public TaskValidator()
        {
            RuleFor(t => t.Name).NotEmpty();
            RuleFor(t => t.Status).NotEmpty();
        }
    }
}
