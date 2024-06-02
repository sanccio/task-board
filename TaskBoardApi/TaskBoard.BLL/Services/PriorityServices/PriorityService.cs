using AutoMapper;
using TaskBoard.BLL.DTOs.Card;
using TaskBoard.DAL.Entities;
using TaskBoard.DAL;
using Microsoft.EntityFrameworkCore;

namespace TaskBoard.BLL.Services.PriorityServices;

public class PriorityService : IPriorityService
{
    private readonly TaskBoardDbContext _context;
    private readonly IMapper _mapper;

    public PriorityService(TaskBoardDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PriorityDto>> GetAllPriorities()
    {
        var columns = await _context.Priorities.ToListAsync();

        return _mapper.Map<IEnumerable<Priority>, IEnumerable<PriorityDto>>(columns);
    }
}
