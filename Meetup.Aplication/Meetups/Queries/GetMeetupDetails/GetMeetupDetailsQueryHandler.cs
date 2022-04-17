﻿using AutoMapper;
using MediatR;
using Meetups.Aplication.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Meetups.Aplication.Meetups.Queries.GetMeetupDetails
{
    public class GetMeetupDetailsQueryHandler : IRequestHandler<GetMeetupDetailsQuery, MeetupDetailsViewModel>
    {
        private readonly IMeetupsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMeetupDetailsQueryHandler(IMeetupsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<MeetupDetailsViewModel> Handle(GetMeetupDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Meetups.FirstOrDefaultAsync(meetup => meetup.Id == request.Id, cancellationToken);

            return _mapper.Map<MeetupDetailsViewModel>(entity);
        }
    }
}
