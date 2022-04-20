using MediatR;
using System;

namespace Meetups.Aplication.Meetups.Commands.CreateMeetup
{
    //the class contains only what is needed to create the meetup
    public class CreateMeetupCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Speaker { get; set; }
        public string Place { get; set; }
        public DateTime MeetupDate { get; set; }
        public DateTime EndTime { get; set; }
    }
}
