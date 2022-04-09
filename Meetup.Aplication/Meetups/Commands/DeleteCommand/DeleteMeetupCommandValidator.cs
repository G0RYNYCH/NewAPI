using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Aplication.Meetups.Commands.DeleteCommand
{
    public class DeleteMeetupCommandValidator : AbstractValidator<DeleteMeetupCommand>
    {
        public DeleteMeetupCommandValidator()
        {
            RuleFor(deleteMeetupCommand => deleteMeetupCommand.Id).NotEqual(Guid.Empty);
            RuleFor(deleteMeetupCommand => deleteMeetupCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
