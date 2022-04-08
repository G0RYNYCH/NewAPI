﻿using AutoMapper;
using Meetups.Aplication.Common.Mapping;
using Meetups.Aplication.Meetups.Commands.CreateMeetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.WebAPI.Models
{
    //c клиента будут приходить данные от пользователя (пользователь не знает свой Id), нужно создать отдельную модель Dto и смапить ее с методом создания митапа.
    public class CreateMeetupDto : IMapWith<CreateMeetupCommand>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Speaker { get; set; }
        public string Place { get; set; }
        public DateTime MeetupDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateMeetupDto, CreateMeetupCommand>()
                .ForMember(meetupCommand => meetupCommand.Name, x => x.MapFrom(meetupDto => meetupDto.Name))
                .ForMember(meetupCommand => meetupCommand.Description, x => x.MapFrom(meetupDto => meetupDto.Description))
                .ForMember(meetupCommand => meetupCommand.Speaker, x => x.MapFrom(meetupDto => meetupDto.Speaker))
                .ForMember(meetupCommand => meetupCommand.Place, x => x.MapFrom(meetupDto => meetupDto.Place))
                .ForMember(meetupCommand => meetupCommand.MeetupDate, x => x.MapFrom(meetupDto => meetupDto.MeetupDate));
        }
    }
}
