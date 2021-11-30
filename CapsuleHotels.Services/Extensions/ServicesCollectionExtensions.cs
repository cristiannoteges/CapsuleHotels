using CapsuleHotels.Services.Business;
using CapsuleHotels.Services.Business.Contracts;
using CapsuleHotels.Services.PropertyMapping;
using CapsuleHotels.Services.PropertyMapping.Contracts;
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
                //PropertyMapping
                .AddTransient<IPropertyMappingService, PropertyMappingService>()
                //Business
                .AddScoped<IUsuarioService, UsuarioService>();
        }
    }
}
