using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskBoard.BLL.DTOs.Card;
using TaskBoard.DAL;
using TaskBoard.DAL.Entities;

namespace TaskBoard.BLL.Services.CardServices;

public class CardService : ICardService
{
    private readonly TaskBoardDbContext _context;
    private readonly IMapper _mapper;

    public CardService(TaskBoardDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CardDto> CreateCard(CreateCardDto createCardDto)
    {
        Card card = _mapper.Map<CreateCardDto, Card>(createCardDto);

        await _context.AddAsync(card);
        await _context.SaveChangesAsync();

        Priority priority = await _context.Priorities.FindAsync(card.PriorityId) 
            ?? throw new Exception($"The object '{typeof(Card)}' with id '{card.PriorityId}' was not found.");

        card.Priority = priority;

        return _mapper.Map<Card, CardDto>(card);
    }

    public async Task<bool> DeleteCard(int id)
    {
        var сard = _context.Cards.Find(id);

        if (сard is null)
        {
            return false;
        }

        _context.Remove(сard);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task EditCard(int id, UpdateCardDto updateCardDto)
    {
        Card сard = _mapper.Map<UpdateCardDto, Card>(updateCardDto);

        _context.Cards.Update(сard);
        await _context.SaveChangesAsync();
    }

    public async Task<CardDto> GetCardById(int id)
    {
        Card? сard = await _context.Cards
            .Include(c => c.Priority)
            .FirstOrDefaultAsync(c => c.Id == id)
            ?? throw new Exception($"The object '{typeof(Card)}' with id '{id}' was not found.");

        return _mapper.Map<Card, CardDto>(сard);
    }
}
