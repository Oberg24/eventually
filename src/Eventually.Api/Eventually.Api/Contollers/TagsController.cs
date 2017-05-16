using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventually.Api.Contollers {
	[Route("api/tags")]
	public class TagsController : Controller {
		[HttpGet]
		public async Task<IActionResult> Get() {
			
			using(var context = new Models.EventuallyContext()) {
				return Ok(context.Tags.ToList());
			}
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<IActionResult> GetById(int id) {
			
			using (var context = new Models.EventuallyContext()) {
				return Ok(context.Tags.Single(x => x.Id == id));	
			}
			
		}

		[HttpDelete]
		[Route("{id}")]
		public async Task<IActionResult> DeleteById(int id) {

			using (var context = new Models.EventuallyContext()) {
				context.Tags.Remove(new Models.Tag() { Id = id });
				context.SaveChanges();
				return Ok(id);
			}

		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] Models.Tag tagToAdd) {
			
			using(var context = new Models.EventuallyContext()) {
				context.Tags.Add(tagToAdd);
				context.SaveChanges();
			}

			var tagId = new { TagId = tagToAdd.Id };
			return Ok(tagId);
		}

		[HttpPut]
		public async Task<IActionResult> Update([FromBody] Models.Tag tagToAdd) {

			using (var context = new Models.EventuallyContext()) {
				context.Tags.Update(tagToAdd);
				context.SaveChanges();
			}

			var tagId = new { TagId = tagToAdd.Id };
			return Ok(tagId);
		}

	}
}
