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
        public DateTime EndTime { get; set; }
        public DateTime MeetupDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Meetup, MeetupsDto>();
        }
    }
}
