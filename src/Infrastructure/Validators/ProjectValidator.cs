using Application.DTOs;
using FluentValidation;

namespace Infrastructure.Validators
{
    public class ProjectValidator : AbstractValidator<ProjectRequestDto>
    {
        public ProjectValidator()
        {
            RuleFor(project => project.Name)
                .NotEmpty()
                .MaximumLength(75);

            RuleFor(project => project.OwnerId)
                .MaximumLength(36);

            RuleFor(project => project.StateId)
                .NotEmpty()
                .MaximumLength(36);

            RuleFor(project => project.CompletionDate)
                .GreaterThan(project => project.StartDate);

            RuleFor(project => project.GroupId)
                .MaximumLength(36);
        }
    }
}
