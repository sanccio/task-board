using Microsoft.AspNetCore.Mvc;
using TaskBoard.BLL.DTOs.Card;
using TaskBoard.BLL.Services.CardServices;

namespace TaskBoard.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CardsController(ICardService cardService) : ControllerBase
{
    private readonly ICardService _cardService = cardService;

    [HttpGet("{id}")]
    public async Task<IActionResult> GetСard(int id)
    {
        var result = await _cardService.GetCardById(id);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateСard([FromBody] CreateCardDto createСardDto)
    {
        var result = await _cardService.CreateCard(createСardDto);

        return CreatedAtAction(nameof(GetСard), new { id = result.Id }, result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteСard(int id)
    {
        bool isDeleted = await _cardService.DeleteCard(id);

        if (!isDeleted)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> EditСard(int id, [FromBody] UpdateCardDto updateСardDto)
    {
        if (id != updateСardDto.Id)
        {
            return BadRequest();
        }

        await _cardService.EditCard(id, updateСardDto);

        return NoContent();
    }
}
