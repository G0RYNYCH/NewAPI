using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Aplication.Meetups.Commands.CreateMeetup
{
    public class CreateMeetupCommandValidator : AbstractValidator<CreateMeetupCommand>
    {
        public CreateMeetupCommandValidator()
        {
            RuleFor(createMeetupCommand => createMeetupCommand.Name).NotEmpty().MaximumLength(50);
            RuleFor(createMeetupCommand => createMeetupCommand.Description).NotEmpty().MaximumLength(200);
            RuleFor(createMeetupCommand => createMeetupCommand.Place).NotEmpty().MaximumLength(50);
            RuleFor(createMeetupCommand => createMeetupCommand.Speaker).NotEmpty().MaximumLength(50);
            RuleFor(createMeetupCommand => createMeetupCommand.MeetupDate).NotEmpty();
        }
    }
}
