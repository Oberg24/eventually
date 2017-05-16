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
			
			using(var context = new Models.EventuallyContext()) {
				return Ok(context.Events.ToList());
			}
		}

		[HttpGet]
		[Route("tags/{ids}")]
		public async Task<IActionResult> GetByTags(string ids) {

			var test = ids.Split(',').ToList();
			
			using (var context = new Models.EventuallyContext()) {

				var eventTags = new List<Models.EventTag>();

				foreach (var item in test) {
					eventTags.AddRange(context.EventTags.Where(x => x.Tag.Id == int.Parse(item)));
				}
				
				var events = context.Events.ToList();

				var toReturn = new List<Models.Event>();
					
				//foreach (var _event in events) {
				//	toReturn.Add(_event.EventTags)
				//}

				return Ok(toReturn.ToList());
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
