using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventually.Api.Models
{
    public class EventParticipant
    {
        public int Id { get; set; }
        public Event Event { get; set; }
        public User User { get; set; }
    }
}
