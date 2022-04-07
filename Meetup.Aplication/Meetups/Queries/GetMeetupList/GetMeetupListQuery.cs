using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Aplication.Meetups.Queries.GetMeetupList
{
    public class GetMeetupListQuery : IRequest<MeetupListViewModel>
    {
        public Guid UserId { get; set; }
    }
}
