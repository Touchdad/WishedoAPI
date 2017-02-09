﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using WishedoAPI.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WishedoAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        UsersContext db;

		public UsersController(UsersContext context)
		{
			this.db = context;
			if (!db.Users.Any())
			{
				db.Users.Add(new User {Name = "Tom", Age = 26});
				db.Users.Add(new User {Name = "Alice", Age = 31});
				db.SaveChanges();
			}
		}
		// GET: api/values
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return db.Users.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User user = db.Users.FirstOrDefault(x=> x.Id == id);
			if (user == null)
				return NotFound();
			return new ObjectResult(user);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
			if (user == null)
			{
				return BadRequest();
			}

			db.Users.Add(user);
			db.SaveChanges();
			return Ok(user);
        }

        // PUT api/users
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]User user)
        {
			if (user == null)
			{
				return BadRequest();
			}
			if (!db.Users.Any(x => x.Id == user.Id))
			{
				return NotFound();
			}

			db.Update(user);
			db.SaveChanges();
			return Ok(user);
		}

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
			User user = db.Users.FirstOrDefault(x => x.Id == id);
			if ( user == null)
			{
				return NotFound();
			}
			db.Users.Remove(user);
			db.SaveChanges();
			return Ok(user); //ZHOPA!
        }
    }
}
