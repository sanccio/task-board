using TaskBoard.BLL.DTOs.Column;

namespace TaskBoard.BLL.Services.ColumnServices;

public interface IColumnService
{
    Task<IEnumerable<ColumnDto>> GetAllColumns();
    Task<ColumnDto> GetColumnById(int id);
    Task<ColumnDto> CreateColumn(CreateColumnDto createColumnDto);
    Task EditColumn(int id, UpdateColumnDto updateColumnDto);
    Task<bool> DeleteColumn(int id);
}
