using Application.DTOs.Request;
using FluentValidation;

namespace Infrastructure.Validators
{
    public class ProjectStateValidator : AbstractValidator<ProjectStateRequestDto>
    {
        public ProjectStateValidator()
        {
            RuleFor(projectState => projectState.Name)
                .NotEmpty()
                .MaximumLength(25);

            RuleFor(projectState => projectState.GroupId)
                .NotEmpty()
                .Length(36);

            RuleFor(projectState => projectState.ColorHexCode)
                .NotEmpty()
                .Length(7);
        }
    }
}
