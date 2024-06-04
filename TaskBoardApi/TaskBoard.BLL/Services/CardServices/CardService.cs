using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TaskBoard.BLL.DTOs.Card;
using TaskBoard.BLL.Exceptions;
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
            ?? throw new ObjectNotFoundException(nameof(Priority), card.PriorityId);

        card.Priority = priority;

        return _mapper.Map<Card, CardDto>(card);
    }

    public async Task DeleteCard(int id)
    {
        Card? card = await _context.Cards.FindAsync(id)
            ?? throw new ObjectNotFoundException(nameof(Card), id);

        _context.Remove(card);
        await _context.SaveChangesAsync();
    }

    public async Task EditCard(int id, UpdateCardDto updateCardDto)
    {
        Card? card = await _context.Cards.FindAsync(id)
            ?? throw new ObjectNotFoundException(nameof(Card), id);

        _mapper.Map(updateCardDto, card);

        _context.Cards.Update(card);
        await _context.SaveChangesAsync();
    }

    public async Task<CardDto> GetCardById(int id)
    {
        Card? сard = await _context.Cards
            .Include(c => c.Priority)
            .FirstOrDefaultAsync(c => c.Id == id)
            ?? throw new ObjectNotFoundException(nameof(Card), id);

        return _mapper.Map<Card, CardDto>(сard);
    }
}
