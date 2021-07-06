﻿using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Models
{
    public class EventsContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public EventsContext(DbContextOptions<EventsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
