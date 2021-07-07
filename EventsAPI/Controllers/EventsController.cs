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
    /**
     * Контроллер для работы с мероприятиями
     */
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {

        EventsContext db;
        public EventsController(EventsContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> Get()
        {
            return await db.Events.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetItem(long id)
        {
            var ev = await db.Events.FindAsync(id);
            if (ev == null) return NotFound();
            return ev;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Event ev)
        {
            db.Events.Add(ev);
            await db.SaveChangesAsync();
            return CreatedAtAction(nameof(GetItem), new { id = ev.Id }, ev);
        }
    }
}
