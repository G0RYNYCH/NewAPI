using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Aplication.Meetups.Queries.GetMeetupDetails
{
    public class GetMeetupDetailsQueryValidator : AbstractValidator<GetMeetupDetailsQuery>
    {
        public GetMeetupDetailsQueryValidator()
        {
            RuleFor(meetup => meetup.Id).NotEqual(Guid.Empty);
        }
    }
}
