using Application.DTOs.Request;
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

            RuleFor(project => project.TicketsPrefix)
                .NotEmpty()
                .Length(4);

            RuleFor(project => project.OwnerId)
                .Length(36);

            RuleFor(project => project.StateId)
                .NotEmpty()
                .Length(36);

            RuleFor(project => project.CompletionDate)
                .GreaterThan(project => project.StartDate);

            RuleFor(project => project.GroupId)
                .Length(36);

            RuleForEach(project => project.AssignedTagsId)
                .NotEmpty()
                .Length(36);
        }
    }
}
