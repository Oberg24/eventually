using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventually.Api.Models {
	public class EventTag {
		public int Id { get; set; }
		public Event Event { get; set; }
		public Tag Tag { get; set; }

	}
}
