using MediatR;
using Meetups.Aplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        //Unit - это тип, означающий пустой ответ
        public async Task<Unit> Handle(UpdateMeetupCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Meetups.FirstOrDefaultAsync(meetup => meetup.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
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
