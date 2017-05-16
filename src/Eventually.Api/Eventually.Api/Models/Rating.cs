﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventually.Api.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int Stars { get; set; }

        public User User { get; set; }
        public Event Event { get; set; }
    }
}
