using AutoMapper;
using Meetups.Aplication.Common.Mapping;
using Meetups.Domain;
using System;

namespace Meetups.Aplication.Meetups.Queries.GetMeetupDetails
{
    public class MeetupDetailsViewModel : IMapWith<Meetup> //вьюшку деталей митапа мапит с классом митап
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Speaker { get; set; }
        public string Place { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime MeetupDate { get; set; }
        public DateTime EditTime { get; set; }

        // реализуем метод мапинг из интерфейса, который будет создавать соответствие между классом MeetupDetailsViewModel и классом  Meetup
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Meetup, MeetupDetailsViewModel>();
        }
    }
}
