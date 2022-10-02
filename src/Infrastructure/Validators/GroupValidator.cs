using Application.DTOs.Request;
using FluentValidation;

namespace Infrastructure.Validators
{
    public class GroupValidator : AbstractValidator<GroupRequestDto>
    {
        public GroupValidator()
        {
            RuleFor(group => group.Name)
                .NotEmpty()
                .MaximumLength(75);
        }
    }
}
