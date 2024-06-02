using Microsoft.EntityFrameworkCore;
using TaskBoard.DAL.Entities;

namespace TaskBoard.DAL;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Column>().HasData(
            new Column { Id = 1, Name = "To Do" },
            new Column { Id = 2, Name = "Planned" });

        modelBuilder.Entity<Priority>().HasData(
            new Priority { Id = 1, Name = "Low" },
            new Priority { Id = 2, Name = "Medium" },
            new Priority { Id = 3, Name = "High" });

        modelBuilder.Entity<Card>().HasData(
            new Card
            {
                Id = 1,
                Title = "Card Name",
                Description = "Task descriptions should be unambiguous, accurate, factual, comprehensible, correct and uniformly designed.",
                DueDate = DateOnly.FromDateTime(DateTime.Now),
                ColumnId = 1,
                PriorityId = 2
            },
            new Card
            {
                Id = 2,
                Title = "Card Name",
                Description = "Task descriptions should be unambiguous, accurate, factual.",
                DueDate = DateOnly.FromDateTime(DateTime.Now),
                ColumnId = 1,
                PriorityId = 3
            },
            new Card
            {
                Id = 3,
                Title = "Card Name",
                Description = "Task descriptions should be unambiguous, accurate, factual.",
                DueDate = DateOnly.FromDateTime(DateTime.Now),
                ColumnId = 2,
                PriorityId = 1
            });
    }
}
