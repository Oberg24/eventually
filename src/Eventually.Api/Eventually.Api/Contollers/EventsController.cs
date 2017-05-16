using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventually.Api.Contollers {
	[Route("api/events")]
	public class EventsController : Controller {
		[HttpGet]
		public async Task<IActionResult> Get() {
			var _event = new { EventId = 2 };
			return Ok(_event);
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetById(int id) {
			var idToReturn = id;
			var _event = new { EventId = idToReturn };
			return Ok(_event);
		}

		[HttpPost]
		[Route("{id}")]
		public async Task<IActionResult> Add(int id) {
			var idToReturn = id;
			var _event = new { EventId = idToReturn };
			return Ok(_event);
		}


	}
}
