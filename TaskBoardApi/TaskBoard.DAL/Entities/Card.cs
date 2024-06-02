namespace TaskBoard.DAL.Entities;

public class Card
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public required DateOnly DueDate { get; set; }
    public int ColumnId { get; set; }
    public Column Column { get; set; } = default!;
    public int PriorityId { get; set; }
    public Priority Priority { get; set; } = default!;
}
