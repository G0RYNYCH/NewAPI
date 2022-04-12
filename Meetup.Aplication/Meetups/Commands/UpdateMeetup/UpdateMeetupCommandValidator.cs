using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Aplication.Meetups.Commands.UpdateMeetup
{
    public class UpdateMeetupCommandValidator : AbstractValidator<UpdateMeetupCommand>
    {
        public UpdateMeetupCommandValidator()
        {
            RuleFor(updateMeetupCommand => updateMeetupCommand.Id).NotEqual(Guid.Empty);
            //RuleFor(updateMeetupCommand => updateMeetupCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateMeetupCommand => updateMeetupCommand.Name).NotEmpty().MaximumLength(50);
            RuleFor(updateMeetupCommand => updateMeetupCommand.Description).NotEmpty().MaximumLength(200);
            RuleFor(updateMeetupCommand => updateMeetupCommand.Place).NotEmpty().MaximumLength(50);
            RuleFor(updateMeetupCommand => updateMeetupCommand.Speaker).NotEmpty().MaximumLength(50);
            RuleFor(updateMeetupCommand => updateMeetupCommand.MeetupDate).NotEmpty();
        }
        
    }
}
