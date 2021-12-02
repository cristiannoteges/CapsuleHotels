using CapsuleHotels.Services.Business;
using CapsuleHotels.Services.Business.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace CapsuleHotels.Services.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddServicesServices(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                //AutoMapper
                .AddAutoMapper(typeof(ServicesCollectionExtensions).Assembly)
                //Business
                .AddScoped<IUsuarioService, UsuarioService>()
                .AddScoped<IHotelService, HotelService>()
                .AddScoped<IHabitacionService, HabitacionService>()
                .AddScoped<IReservaService, ReservaService>();
        }
    }
}
