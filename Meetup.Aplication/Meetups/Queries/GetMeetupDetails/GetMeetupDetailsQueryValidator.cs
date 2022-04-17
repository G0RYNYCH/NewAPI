using FluentValidation;
using Meetups.Aplication.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Meetups.Aplication.Meetups.Queries.GetMeetupDetails
{
    public class GetMeetupDetailsQueryValidator : AbstractValidator<GetMeetupDetailsQuery>
    {
        private readonly IMeetupsDbContext _dbContext;

        public GetMeetupDetailsQueryValidator()
        {
            RuleFor(meetup => meetup.Id).NotEqual(Guid.Empty)
                .WithMessage(meetup => $"The Meetup Id {meetup.Id} must not be null")
                .DependentRules(() =>
                {
                    RuleFor(meetup => meetup.Id)
                        .MustAsync(Exists)
                        .WithMessage(meetup => $"The meetup with Id {meetup.Id} was not found.");
                });
        }

        private async Task<bool> Exists(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Meetups.FindAsync(id, cancellationToken);

            return entity != null;
        }
    }
}
