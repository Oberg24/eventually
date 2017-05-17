using Eventually.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventually.Api.Contollers {
	[Route("api/events")]
	public class EventsController : Controller {
		[HttpGet]
		public async Task<IActionResult> Get() {
			
			using(var context = new Models.EventuallyContext()) {
                var events = context.Events.ToList();
                return Ok(events);
			}
		}

		[HttpGet]
		[Route("tags/{ids}")]
		public async Task<IActionResult> GetByTags(string ids) {

			var tagIdList = ids.Split(',').ToList();
			
			using (var context = new Models.EventuallyContext()) {
                
                var eventTags = context.EventTags.Where(x => tagIdList.Contains(x.Tag.Id.ToString()));
                var events = eventTags.Select(x => x.Event).Distinct();
                return Ok(events.ToList());
			}
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetById(int id) {
			
			using (var context = new Models.EventuallyContext()) {
				return Ok(context.Events.Single(x => x.Id == id));	
			}
			
		}

        [HttpGet]
        [Route("{eventId}/tags")]
        public async Task<IActionResult> GetEventTags(int eventId)
        {
            using (var context = new EventuallyContext())
            {
                var eventTags = context.EventTags.Where(x => x.Event.Id == eventId);
                var tags = eventTags.Select(x => x.Tag);
                return Ok(tags.ToList());
            }
        }

		[HttpGet]
		[Route("{eventId}/participants")]
		public async Task<IActionResult> GetEventParticipants(int eventId) {
			using (var context = new EventuallyContext()) {
				var eventParticipants = context.EventParticipants.Where(x => x.Event.Id == eventId);
				var participants = eventParticipants.Select(x => x.User);
				return Ok(participants.ToList());
			}
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> DeleteById(int id) {

			using (var context = new Models.EventuallyContext()) {
				context.Events.Remove(new Models.Event() { Id = id });
				context.SaveChanges();
				return Ok(id);
			}

		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] Models.Event eventToAdd) {
			
			using(var context = new Models.EventuallyContext()) {
				context.Events.Add(eventToAdd);
				context.SaveChanges();
			}

			var _event = new { EventId = eventToAdd.Id };
			return Ok(_event);
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody] Models.Event eventToAdd) {

			using (var context = new Models.EventuallyContext()) {
				context.Events.Update(eventToAdd);
				context.SaveChanges();
			}

			var _event = new { EventId = eventToAdd.Id };
			return Ok(_event);
		}

	}
}
