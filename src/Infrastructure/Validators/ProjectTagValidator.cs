using Application.DTOs.Request;
using FluentValidation;

namespace Infrastructure.Validators
{
    public class ProjectTagValidator : AbstractValidator<ProjectTagRequestDto>
    {
        public ProjectTagValidator()
        {
            RuleFor(projectTag => projectTag.Name)
                .NotEmpty()
                .MaximumLength(25);

            RuleFor(projectTag => projectTag.GroupId)
                .Length(36);

            RuleFor(projectTag => projectTag.ColorHexCode)
                .NotEmpty()
                .Length(7);
        }
    }
}
