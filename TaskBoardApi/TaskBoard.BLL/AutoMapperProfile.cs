using AutoMapper;
using TaskBoard.BLL.DTOs.Card;
using TaskBoard.BLL.DTOs.Column;
using TaskBoard.DAL.Entities;

namespace TaskBoard.BLL;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Column, ColumnDto>();
        CreateMap<CreateColumnDto, Column>();
        CreateMap<UpdateColumnDto, Column>();

        CreateMap<Card, CardDto>();
        CreateMap<CreateCardDto, Card>();
        CreateMap<UpdateCardDto, Card>();

        CreateMap<Priority, PriorityDto>().ReverseMap();
    }
}
