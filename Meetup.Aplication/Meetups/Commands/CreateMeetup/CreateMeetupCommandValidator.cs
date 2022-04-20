using FluentValidation;
using System;

namespace Meetups.Aplication.Meetups.Commands.CreateMeetup
{
    public class CreateMeetupCommandValidator : AbstractValidator<CreateMeetupCommand>
    {
        public CreateMeetupCommandValidator()
        {
            RuleFor(createMeetupCommand => createMeetupCommand.Name)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Name is compalsory to fill in with up to 50 symbols");
            RuleFor(createMeetupCommand => createMeetupCommand.Description)
                .NotEmpty()
                .MaximumLength(200)
                .WithMessage("Description is compalsory to fill in with up to 200 symbols");
            RuleFor(createMeetupCommand => createMeetupCommand.Place)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Place is compalsory to fill in with up to 50 symbols");
            RuleFor(createMeetupCommand => createMeetupCommand.Speaker)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Speaker is compalsory to fill in with up to 50 symbols");
            RuleFor(createMeetupCommand => createMeetupCommand.EndTime)
                .NotEmpty()
                .GreaterThan(createMeetupCommand => createMeetupCommand.MeetupDate)
                .WithMessage("The past is not need planing");
            RuleFor(createMeetupCommand => createMeetupCommand.MeetupDate)
                .NotEmpty()
                .GreaterThan(DateTime.Now)
                .WithMessage("The past is not need planing");
        }
    }
}
