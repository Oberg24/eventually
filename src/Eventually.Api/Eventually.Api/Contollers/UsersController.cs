using Eventually.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventually.Api.Contollers
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using (var context = new EventuallyContext())
            {
                return Ok(context.Users.ToList());
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            using (var context = new EventuallyContext())
            {
                var user = await context.Users.FindAsync(id);
                return Ok(user);
            }
        }
    }
}
