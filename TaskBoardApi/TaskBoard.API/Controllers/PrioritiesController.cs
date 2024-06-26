﻿using Microsoft.AspNetCore.Mvc;
using TaskBoard.BLL.DTOs.Card;
using TaskBoard.BLL.Services.PriorityServices;

namespace TaskBoard.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PrioritiesController(IPriorityService priorityService) : ControllerBase
{
    readonly private IPriorityService _priorityService = priorityService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PriorityDto>>> GetPriorities()
    {
        var result = await _priorityService.GetAllPriorities();

        return Ok(result);
    }
}
