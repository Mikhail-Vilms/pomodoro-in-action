using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PomodoroInAction.Models
{
    public class PomodoroAppDbContext : IdentityDbContext
    {
        public PomodoroAppDbContext(DbContextOptions options) : base(options)
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AppUserBoard>()
                .HasKey(record => new { record.AppUserId, record.BoardId });

            modelBuilder.Entity<AppUserBoard>()
                .HasOne(record => record.AppUser)
                .WithMany(user => user.AppUserBoards)
                .HasForeignKey(record => record.AppUserId);

            modelBuilder.Entity<AppUserBoard>()
                .HasOne(record => record.Board)
                .WithMany(board => board.AppUserBoards)
                .HasForeignKey(record => record.BoardId);
        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<KanbanContainer> Containers { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserBoard> AppUserBoards { get; set; }
    }
}
