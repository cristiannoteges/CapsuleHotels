using CapsuleHotels.Dtos.Entites;
using CapsuleHotels.Model.Entities;
using AutoMapper;

namespace CapsuleHotels.Services.Mappings
{
    public class HabitacionProfile :Profile
    {
        public HabitacionProfile()
        {
            CreateMap<Habitacion, HabitacionDto>();
        }
    }
}
