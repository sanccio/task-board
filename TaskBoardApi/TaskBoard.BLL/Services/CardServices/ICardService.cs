using TaskBoard.BLL.DTOs.Card;

namespace TaskBoard.BLL.Services.CardServices;

public interface ICardService
{
    Task<CardDto> GetCardById(int id);
    Task<CardDto> CreateCard(CreateCardDto createCardDto);
    Task EditCard(int id, UpdateCardDto updateCardDto);
    Task DeleteCard(int id);
}
