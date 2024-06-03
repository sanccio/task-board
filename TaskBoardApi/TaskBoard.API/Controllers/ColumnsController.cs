using Microsoft.AspNetCore.Mvc;
using TaskBoard.BLL.DTOs.Column;
using TaskBoard.BLL.Services.ColumnServices;

namespace TaskBoard.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ColumnsController(IColumnService columnService) : ControllerBase
{
    private readonly IColumnService _columnService = columnService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ColumnDto>>> GetColumns()
    {
        var columns = await _columnService.GetAllColumns();

        return Ok(columns);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetColumn(int id)
    {
        var result = await _columnService.GetColumnById(id);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateColumn([FromBody] CreateColumnDto createColumnDto)
    {
        var result = await _columnService.CreateColumn(createColumnDto);

        return CreatedAtAction(nameof(GetColumn), new { id = result.Id }, result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteColumn(int id)
    {
        await _columnService.DeleteColumn(id);

        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> EditColumn(int id, [FromBody] UpdateColumnDto updateColumnDto)
    {
        if (id != updateColumnDto.Id)
        {
            return BadRequest();
        }

        await _columnService.EditColumn(id, updateColumnDto);

        return NoContent();
    }
}
