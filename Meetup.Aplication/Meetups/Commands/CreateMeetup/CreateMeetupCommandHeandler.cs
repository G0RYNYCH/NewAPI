using MediatR;
using Meetups.Aplication.Interfaces;
using Meetups.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Meetups.Aplication.Meetups.Commands.CreateMeetup
{// класс на основании того, что неабходимо для создания митапа, содержит в себе логику для создания 
    public class CreateMeetupCommandHandler : IRequestHandler<CreateMeetupCommand, Guid> //указываем интерфейсу тип запроса и тип ответ соответственно
    {
        private readonly IMeetupsDbContext _dbContext;//для сохранения изменений сделаем внедрениение зависимости на контекс бд в данный класс через конструктор

        public CreateMeetupCommandHandler(IMeetupsDbContext dbContext) => _dbContext = dbContext;
        //логика создания содержится в методе hendle
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
