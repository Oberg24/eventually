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
                var events = context.Events
                    .Include(x => x.EventParticipants)
                    .ThenInclude(x => x.User)
                    .Include(x => x.EventTags)
                    .ThenInclude(x => x.Tag)
                    .Include(x => x.Creator)
                    .ToList();

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
