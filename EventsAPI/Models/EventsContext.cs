using Microsoft.EntityFrameworkCore;

namespace EventsAPI.Models
{
    /**
     * Контекст модели данных для работы с БД
     */
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
