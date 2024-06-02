using TaskBoard.BLL.DTOs.Card;

namespace TaskBoard.BLL.DTOs.Column;

public class ColumnDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<CardDto> Cards { get; set; } = new List<CardDto>();
}
