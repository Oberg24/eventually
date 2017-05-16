using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventually.Api.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CreationDate { get; set; }

        public IEnumerable<EventTag> EventTags { get; set; }
        public IEnumerable<EventParticipant> EventParticipants { get; set; }
        public User Creator { get; set; }
    }
}
