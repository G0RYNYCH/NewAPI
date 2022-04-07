using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Meetups.Aplication.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Meetups.Aplication.Meetups.Queries.GetMeetupList
{
    public class GetMeetupListQueryHandler : IRequestHandler<GetMeetupListQuery, MeetupListViewModel>
    {
        private readonly IMeetupsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMeetupListQueryHandler(IMeetupsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<MeetupListViewModel> Handle(GetMeetupListQuery request, CancellationToken cancellationToken)
        {
            var meetupQuery = await _dbContext.Meetups
                .Where(meetup => meetup.UserId == request.UserId)
                .ProjectTo<MeetupDto>(_mapper.ConfigurationProvider)//метод расширения из библиотеки, который проецирует коллекцию в соостветствии с заданной конфигурацией
                .ToListAsync(cancellationToken);

            return new MeetupListViewModel { Meetups = meetupQuery };
        }
    }
}
