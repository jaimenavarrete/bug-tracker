using Application.DTOs.Request;
using FluentValidation;

namespace Infrastructure.Validators
{
    public class TicketValidator : AbstractValidator<TicketRequestDto>
    {
        public TicketValidator()
        {
            RuleFor(ticket => ticket.Name)
                .NotEmpty()
                .MaximumLength(75);

            RuleFor(ticket => ticket.SubmitterId)
                .NotEmpty()
                .Length(36);

            RuleFor(ticket => ticket.StateId)
                .NotEmpty()
                .Length(36);

            RuleFor(ticket => ticket.AssignedUserId)
                .Length(36);

            RuleFor(ticket => ticket.ProjectId)
                .NotEmpty()
                .Length(36);

            RuleForEach(ticket => ticket.AssignedTagsId)
                .NotEmpty()
                .Length(36);
        }
    }
}