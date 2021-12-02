using AutoMapper;
using CapsuleHotels.Dtos.Entites;
using CapsuleHotels.Model.Entities;

namespace CapsuleHotels.Services.Mappings
{
    public class ReservaProfile : Profile
    {
        public ReservaProfile()
        {
            CreateMap<Reserva, ReservaDto>()
            .ForMember(dest => dest.UsuarioMail, opt => opt.MapFrom(src => src.Usuario.Mail))
            .ForMember(dest => dest.HotelNombre, opt => opt.MapFrom(src => src.Hotel.Nombre))
            .ForMember(dest => dest.HabitacionNumeroHabitacion, opt => opt.MapFrom(src => src.Habitacion.NumeroHabitacion));
        }
    }
}
