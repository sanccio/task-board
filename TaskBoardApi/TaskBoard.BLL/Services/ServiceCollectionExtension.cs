using Microsoft.Extensions.DependencyInjection;
using TaskBoard.BLL.Services.CardServices;
using TaskBoard.BLL.Services.ColumnServices;
using TaskBoard.BLL.Services.PriorityServices;

namespace TaskBoard.BLL.Services;

public static class ServiceCollectionExtension
{
    public static void AddBllServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapperProfile));
        services.AddScoped<IColumnService, ColumnService>();
        services.AddScoped<ICardService, CardService>();
        services.AddScoped<IPriorityService, PriorityService>();
    }
}
