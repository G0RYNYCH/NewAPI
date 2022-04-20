using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Meetups.Persistence;

namespace Meetups.Aplication.Meetups.Commands.UpdateMeetup
{
    public class UpdateMeetupCommandHandler : IRequestHandler<UpdateMeetupCommand>
    {
        private readonly MeetupsDbContext _dbContext;

        public UpdateMeetupCommandHandler(MeetupsDbContext dbContext) => _dbContext = dbContext;

        //Unit - is a type meaning an empty response
        public async Task<Unit> Handle(UpdateMeetupCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Meetups.FirstOrDefaultAsync(meetup => meetup.Id == request.Id, cancellationToken);

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Speaker = request.Speaker;
            entity.Place = request.Place;
            entity.EndTime = request.EndTime;
            entity.MeetupDate = request.MeetupDate;
            entity.EditTime = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
