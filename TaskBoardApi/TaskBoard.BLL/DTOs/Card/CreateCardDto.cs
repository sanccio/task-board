namespace TaskBoard.BLL.DTOs.Card;

public class CreateCardDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateOnly DueDate { get; set; }
    public int ColumnId { get; set; }
    public int PriorityId { get; set; }
}
