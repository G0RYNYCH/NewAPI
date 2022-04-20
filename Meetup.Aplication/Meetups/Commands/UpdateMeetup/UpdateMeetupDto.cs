using AutoMapper;
using Meetups.Aplication.Common.Mapping;
using Meetups.Aplication.Meetups.Commands.UpdateMeetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.WebAPI.Models
{
    public class UpdateMeetupDto : IMapWith<UpdateMeetupCommand>
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
            profile.CreateMap<UpdateMeetupDto, UpdateMeetupCommand>();
        }
    }

}
