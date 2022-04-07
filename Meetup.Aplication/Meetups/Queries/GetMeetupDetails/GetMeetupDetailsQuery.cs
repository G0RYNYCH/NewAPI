using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Aplication.Meetups.Queries.GetMeetupDetails
{
    //запрос для получения деталей митапа
    public class GetMeetupDetailsQuery : IRequest<MeetupDetailsViewModel>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
