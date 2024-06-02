using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskBoard.BLL.DTOs.Column;
using TaskBoard.DAL;
using TaskBoard.DAL.Entities;

namespace TaskBoard.BLL.Services.ColumnServices;

public class ColumnService : IColumnService
{
    private readonly TaskBoardDbContext _context;
    private readonly IMapper _mapper;

    public ColumnService(TaskBoardDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ColumnDto> CreateColumn(CreateColumnDto createColumnDto)
    {
        Column column = _mapper.Map<CreateColumnDto, Column>(createColumnDto);

        await _context.AddAsync(column);
        await _context.SaveChangesAsync();

        return _mapper.Map<Column, ColumnDto>(column);
    }

    public async Task<bool> DeleteColumn(int id)
    {
        var column = _context.Columns.Find(id);

        if (column is null) 
        {
            return false; 
        }

        _context.Remove(column);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task EditColumn(int id, UpdateColumnDto updateColumnDto)
    {
        var column = _mapper.Map<UpdateColumnDto, Column>(updateColumnDto);

        _context.Columns.Update(column);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ColumnDto>> GetAllColumns()
    {
        var columns = await _context.Columns
            .Include(c => c.Cards)
            .ThenInclude(c => c.Priority)
            .ToListAsync();

        return _mapper.Map<IEnumerable<Column>, IEnumerable<ColumnDto>>(columns);
    }

    public async Task<ColumnDto> GetColumnById(int id)
    {
        Column? column = await _context.Columns
            .Include(c => c.Cards)
            .ThenInclude(c => c.Priority)
            .FirstOrDefaultAsync(c => c.Id == id) 
            ?? throw new Exception($"The object '{typeof(Column)}' with id '{id}' was not found.");

        return _mapper.Map<Column, ColumnDto>(column);
    }
}
