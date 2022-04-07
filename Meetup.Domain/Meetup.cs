using System;

namespace Meetups.Domain
{
    public class Meetup
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
