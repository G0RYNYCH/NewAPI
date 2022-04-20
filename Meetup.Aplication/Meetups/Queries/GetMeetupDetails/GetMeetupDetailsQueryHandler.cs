using AutoMapper;
using MediatR;
using Meetups.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Meetups.Aplication.Meetups.Queries.GetMeetupDetails
{
    public class GetMeetupDetailsQueryHandler : IRequestHandler<GetMeetupDetailsQuery, MeetupDetailsViewModel>
    {
        private readonly MeetupsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetMeetupDetailsQueryHandler(MeetupsDbContext dbContext, IMapper mapper)
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
