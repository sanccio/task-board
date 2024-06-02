using Microsoft.EntityFrameworkCore;
using TaskBoard.DAL.Entities;

namespace TaskBoard.DAL;

public class TaskBoardDbContext : DbContext
{
    public TaskBoardDbContext(DbContextOptions<TaskBoardDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Card> Cards { get; set; }
    public DbSet<Priority> Priorities { get; set; }
    public DbSet<Column> Columns { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Seed();
    }
}
