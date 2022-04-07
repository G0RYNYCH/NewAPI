﻿using MediatR;
using Meetups.Aplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetups.Aplication.Meetups.Commands.UpdateMeetup
{
    //все, что нужно для обновления митапа
    public class UpdateMeetupCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Speaker { get; set; }
        public string Place { get; set; }
        public DateTime MeetupDate { get; set; }
        public DateTime EditTime { get; set; }
    }
}
