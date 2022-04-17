using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Meetups.Aplication.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Meetups.Aplication.Meetups.Queries.GetMeetupList
{
    public class GetMeetupsListQueryHandler : IRequestHandler<GetMeetupsListQuery, MeetupsListViewModel>
    {
        private readonly IMeetupsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMeetupsListQueryHandler(IMeetupsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<MeetupsListViewModel> Handle(GetMeetupsListQuery request, CancellationToken cancellationToken)
        {
            var meetupQuery = await _dbContext.Meetups
                .ProjectTo<MeetupsDto>(_mapper.ConfigurationProvider)//extension method from the library that projects the collection according to the given configuration
                .ToListAsync(cancellationToken);

            return new MeetupsListViewModel { Meetups = meetupQuery };
        }
    }
}
