﻿using MediatR;
using Meetups.Aplication.Interfaces;
using Meetups.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Meetups.Aplication.Meetups.Commands.CreateMeetup
{
    public class CreateMeetupCommandHandler : IRequestHandler<CreateMeetupCommand, Guid> //specify the type of request and type of response to the interface, respectively
    {
        private readonly IMeetupsDbContext _dbContext;//to save the changes, we will inject the dependency on the database context into this class through the constructor

        public CreateMeetupCommandHandler(IMeetupsDbContext dbContext) => _dbContext = dbContext;
        //the creation logic is contained in the handle method
        public async Task<Guid> Handle(CreateMeetupCommand request, CancellationToken cancellationToken)
        {
            var meetup = new Meetup
            {
                UserId = request.UserId,
                Id = Guid.NewGuid(), //?
                Name = request.Name,
                Description = request.Description,
                Speaker = request.Speaker,
                Place = request.Place,
                MeetupDate = request.MeetupDate
            };
            return meetup.Id;

            await _dbContext.Meetups.AddAsync(meetup, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

    }
}