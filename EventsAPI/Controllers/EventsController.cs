using EventsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {

        EventsContext db;
        public EventsController(EventsContext context)
        {
            db = context;
            if (!db.Events.Any())
            {
                db.Events.Add(new Event { Name = "Event1", Description = "Description1", Author = "ShtormAD" });
                db.Events.Add(new Event { Name = "Event2", Description = "Description2", Author = "не ShtormAD" });
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> Get()
        {
            return await db.Events.ToListAsync();
        }

        //[HttpGet("{id}")]
    }
}
