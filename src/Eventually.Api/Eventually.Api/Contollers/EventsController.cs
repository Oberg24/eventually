using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventually.Api.Contollers
{
    [Route("api/events")]
    public class EventsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var _event = new { EventId = 2 };
            return Ok(_event);
        }
    }
}
