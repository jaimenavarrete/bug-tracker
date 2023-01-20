using Application.DTOs.Request;
using FluentValidation;

namespace Infrastructure.Validators
{
    public class UserValidator : AbstractValidator<UserRequestDto>
    {
        public UserValidator()
        {
            RuleFor(user => user.FirstName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(user => user.LastName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(user => user.UserName)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(user => user.Password)
                .NotEmpty();

            RuleFor(user => user.Biography)
                .MaximumLength(1000);

            RuleFor(user => user.Email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(256);

            RuleFor(user => user.PhoneNumber)
                .MaximumLength(20);

            RuleFor(user => user.Address)
                .MaximumLength(100);

            RuleFor(user => user.ProfileImage)
                .MaximumLength(200);
        }
    }
}
