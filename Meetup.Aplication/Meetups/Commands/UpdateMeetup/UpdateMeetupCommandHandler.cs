using MediatR;
using Meetups.Aplication.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using Meetups.Aplication.Common.Exceptions;
using Microsoft.EntityFrameworkCore;
using Meetups.Domain;

namespace Meetups.Aplication.Meetups.Commands.UpdateMeetup
{
    public class UpdateMeetupCommandHandler : IRequestHandler<UpdateMeetupCommand>
    {
        private readonly IMeetupsDbContext _dbContext;

        public UpdateMeetupCommandHandler(IMeetupsDbContext dbContext) => _dbContext = dbContext;

        //Unit - is a type meaning an empty response
        public async Task<Unit> Handle(UpdateMeetupCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Meetups.FirstOrDefaultAsync(meetup => meetup.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Meetup), request.Id);
            }

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Speaker = request.Speaker;
            entity.Place = request.Place;
            entity.MeetupDate = request.MeetupDate;
            entity.EditTime = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
