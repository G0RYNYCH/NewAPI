using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Aplication.Meetups.Queries.GetMeetupList
{
    public class GetMeetupListQueryValidator : AbstractValidator<GetMeetupListQuery>
    {
        public GetMeetupListQueryValidator()
        {
           // RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
