using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Aplication.Meetups.Commands.CreateMeetup
{
    //the class contains only what is needed to create the meetup
    public class CreateMeetupCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Speaker { get; set; }
        public string Place { get; set; }
        public DateTime MeetupDate { get; set; }
    }
}
