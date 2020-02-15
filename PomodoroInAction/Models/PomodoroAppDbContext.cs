using Microsoft.EntityFrameworkCore;

namespace PomodoroInAction.Models
{
    public class PomodoroAppDbContext : DbContext
    {
        public PomodoroAppDbContext(DbContextOptions options) : base(options)
        { 
        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<KanbanContainer> Containers { get; set; }
    }
}
