using Application.DTOs.Request;
using FluentValidation;

namespace Infrastructure.Validators
{
    public class TicketStateValidator : AbstractValidator<TicketStateRequestDto>
    {
        public TicketStateValidator()
        {
            RuleFor(ticketState => ticketState.Name)
                .NotEmpty()
                .MaximumLength(25);

            RuleFor(ticketState => ticketState.ProjectId)
                .NotEmpty()
                .Length(36);

            RuleFor(ticketState => ticketState.ColorHexCode)
                .NotEmpty()
                .Length(7);
        }
    }
}