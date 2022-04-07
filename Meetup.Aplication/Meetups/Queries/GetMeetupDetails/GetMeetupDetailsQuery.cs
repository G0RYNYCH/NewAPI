using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Aplication.Meetups.Queries.GetMeetupDetails
{
    //a request to to get meetup's details
    public class GetMeetupDetailsQuery : IRequest<MeetupDetailsViewModel>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
