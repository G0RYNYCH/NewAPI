using MediatR;
using System;

namespace Meetups.Aplication.Meetups.Queries.GetMeetupDetails
{
    //a request to get meetup's details
    public class GetMeetupDetailsQuery : IRequest<MeetupDetailsViewModel>
    {
        public Guid Id { get; set; }
    }
}
