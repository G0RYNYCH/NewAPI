using FluentValidation;
using Meetups.Aplication.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Meetups.Aplication.Meetups.Commands.UpdateMeetup
{
    public class UpdateMeetupCommandValidator : AbstractValidator<UpdateMeetupCommand>
    {
        private readonly IMeetupsDbContext _dbContext;

        public UpdateMeetupCommandValidator(IMeetupsDbContext dbContext) => _dbContext = dbContext;

        public UpdateMeetupCommandValidator()
        {
            RuleFor(updateMeetupCommand => updateMeetupCommand.Id)
                .NotEqual(Guid.Empty)
                .WithMessage(updateMeetupCommand => $"The Meetup Id {updateMeetupCommand.Id} must not be null")
                .DependentRules(() =>
                    {
                        RuleFor(updateMeetupCommand => updateMeetupCommand.Id)
                            .MustAsync(Exists)
                            .WithMessage(updateMeetupCommand => $"The meetup with Id {updateMeetupCommand.Id} was not found.");
                    });
            RuleFor(updateMeetupCommand => updateMeetupCommand.Name)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Name is compalsory to fill in with up to 50 symbols");
            RuleFor(updateMeetupCommand => updateMeetupCommand.Description)
                .NotEmpty()
                .MaximumLength(200)
                .WithMessage("Description is compalsory to fill in with up to 200 symbols");
            RuleFor(updateMeetupCommand => updateMeetupCommand.Place)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Place is compalsory to fill in with up to 50 symbols");
            RuleFor(updateMeetupCommand => updateMeetupCommand.Speaker)
                .NotEmpty()
                .MaximumLength(50)
                .WithMessage("Speaker is compalsory to fill in with up to 50 symbols");
            RuleFor(updateMeetupCommand => updateMeetupCommand.MeetupDate)
                .NotEmpty().GreaterThan(DateTime.Now).WithMessage("The past is not need planing");
        }

        private async Task<bool> Exists(Guid Id, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Meetups.FindAsync(Id, cancellationToken);

            return entity != null;
        }

    }
}
