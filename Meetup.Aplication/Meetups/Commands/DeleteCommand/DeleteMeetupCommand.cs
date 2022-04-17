using MediatR;
using System;

namespace Meetups.Aplication.Meetups.Commands.DeleteCommand
{
    public class DeleteMeetupCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
