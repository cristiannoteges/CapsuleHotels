using CapsuleHotels.Data.Repositories;
using CapsuleHotels.Data.Repositories.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace CapsuleHotels.Data.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddScoped<IHotelRepository, HotelRepository>()
                .AddScoped<IUsuarioRepository, UsuarioRepository>()
                .AddScoped<IHabitacionRepository, HabitacionRepository>()
                .AddScoped<IReservaRepository, ReservaRepository>(); 
        }
    }
}
