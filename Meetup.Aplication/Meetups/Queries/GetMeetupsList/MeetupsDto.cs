using AutoMapper;
using Meetups.Aplication.Common.Mapping;
using Meetups.Domain;
using System;

namespace Meetups.Aplication.Meetups.Queries.GetMeetupList
{
    public class MeetupsDto : IMapWith<Meetup>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Speaker { get; set; }
        public string Place { get; set; }
        public DateTime MeetupDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Meetup, MeetupsDto>()
                .ForMember(meetupDto => meetupDto.Id, x => x.MapFrom(meetup => meetup.Id))
                .ForMember(meetupDto => meetupDto.Name, x => x.MapFrom(meetup => meetup.Name))
                .ForMember(meetupDto => meetupDto.Description, x => x.MapFrom(meetup => meetup.Description))
                .ForMember(meetupDto => meetupDto.Speaker, x => x.MapFrom(meetup => meetup.Speaker))
                .ForMember(meetupDto => meetupDto.Place, x => x.MapFrom(meetup => meetup.Place))
                .ForMember(meetupDto => meetupDto.MeetupDate, x => x.MapFrom(meetup => meetup.MeetupDate));
        }
    }
}
