using Core.Models;
using FluentValidation;

namespace Service.ValidationRules.FluentValidation
{
    public class TaskValidator : AbstractValidator<Task>
    {
        public TaskValidator()
        {
            RuleFor(t => t.Name).NotEmpty();
            RuleFor(t => t.Status).NotEmpty();
            RuleFor(t => t.CategoryId).NotEmpty();
            RuleFor(t => t.IsDeleted).NotEmpty();
        }
    }
}
