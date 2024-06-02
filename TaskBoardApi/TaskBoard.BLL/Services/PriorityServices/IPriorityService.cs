using TaskBoard.BLL.DTOs.Card;

namespace TaskBoard.BLL.Services.PriorityServices;

public interface IPriorityService
{
    Task<IEnumerable<PriorityDto>> GetAllPriorities();
}
