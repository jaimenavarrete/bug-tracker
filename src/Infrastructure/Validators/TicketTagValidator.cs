using Application.DTOs.Request;
using FluentValidation;

namespace Infrastructure.Validators
{
    public class TicketTagValidator : AbstractValidator<TicketTagRequestDto>
    {
        public TicketTagValidator()
        {
            RuleFor(ticketTag => ticketTag.Name)
                .NotEmpty()
                .MaximumLength(25);

            RuleFor(ticketTag => ticketTag.ProjectId)
                .NotEmpty()
                .Length(36);

            RuleFor(ticketTag => ticketTag.ColorHexCode)
                .NotEmpty()
                .Length(7);
        }
    }
}
