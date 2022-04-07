﻿using MediatR;
using Meetups.Aplication.Common.Exceptions;
using Meetups.Aplication.Interfaces;
using Meetups.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Meetups.Aplication.Meetups.Commands.DeleteCommand
{
    public class DeleteMeetupCommandHandler : IRequestHandler<DeleteMeetupCommand>
    {
        private readonly IMeetupsDbContext _dbContext;

        public DeleteMeetupCommandHandler(IMeetupsDbContext dbContext) => _dbContext = dbContext;

        //Unit - это тип, означающий пустой ответ
        public async Task<Unit> Handle(DeleteMeetupCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Meetups.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Meetup), request.Id);
            }

            _dbContext.Meetups.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
