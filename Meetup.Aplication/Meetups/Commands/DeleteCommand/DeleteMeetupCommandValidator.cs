using FluentValidation;
using Meetups.Aplication.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Meetups.Aplication.Meetups.Commands.DeleteCommand
{
    public class DeleteMeetupCommandValidator : AbstractValidator<DeleteMeetupCommand>
    {
        private readonly IMeetupsDbContext _dbContext;

        public DeleteMeetupCommandValidator(IMeetupsDbContext dbContext) => _dbContext = dbContext;

        public DeleteMeetupCommandValidator()
        {
            RuleFor(deleteMeetupCommand => deleteMeetupCommand.Id)
                .NotEqual(Guid.Empty)
                .WithMessage(deleteMeetupCommand => $"The Meetup Id {deleteMeetupCommand.Id} must not be null")
                .DependentRules(() =>
                {
                    RuleFor(deleteMeetupCommand => deleteMeetupCommand.Id)
                        .MustAsync(Exists)
                        .WithMessage(deleteMeetupCommand => $"The meetup with Id {deleteMeetupCommand.Id} was not found.");
                });
        }

        private async Task<bool> Exists(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Meetups.FindAsync(id, cancellationToken);

            return entity != null;
        }
    }
}
