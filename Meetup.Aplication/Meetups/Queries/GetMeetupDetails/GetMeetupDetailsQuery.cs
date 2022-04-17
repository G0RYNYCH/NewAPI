using MediatR;
using System;

namespace Meetups.Aplication.Meetups.Queries.GetMeetupDetails
{
    public class GetMeetupDetailsQuery : IRequest<MeetupDetailsViewModel>
    {
        public Guid Id { get; set; }
    }
}
