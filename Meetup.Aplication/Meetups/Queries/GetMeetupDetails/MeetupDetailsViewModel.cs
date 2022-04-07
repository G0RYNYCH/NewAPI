using AutoMapper;
using Meetups.Aplication.Common.Mapping;
using Meetups.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Aplication.Meetups.Queries.GetMeetupDetails
{
    public class MeetupDetailsViewModel : IMapWith<Meetup> //вьюшку деталей митапа мапить с классом митап
    {
        // класс содержит те  же поля , что и класс митап, кроме айди пользователя
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Speaker { get; set; }
        public string Place { get; set; }
        public DateTime MeetupDate { get; set; }
        public DateTime EditTime { get; set; }

        // реализуем метод мапинг из интерфейса, который будет создавать соответствие между классом MeetupDetailsViewModel и классом  Meetup
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Meetup, MeetupDetailsViewModel>()
                .ForMember(meetupVm => meetupVm.Name, x => x.MapFrom(meetup => meetup.Name))
                .ForMember(meetupVm => meetupVm.Description, x => x.MapFrom(meetup => meetup.Description))
                .ForMember(meetupVm => meetupVm.Speaker, x => x.MapFrom(meetup => meetup.Speaker))
                .ForMember(meetupVm => meetupVm.Place, x => x.MapFrom(meetup => meetup.Place))
                .ForMember(meetupVm => meetupVm.MeetupDate, x => x.MapFrom(meetup => meetup.MeetupDate))
                .ForMember(meetupVm => meetupVm.EditTime, x => x.MapFrom(meetup => meetup.EditTime));
        }
    }
}
