using AutoMapper;
using CapsuleHotels.Dtos.Entites;
using CapsuleHotels.Model.Entities;

namespace CapsuleHotels.Services.Mappings
{
    public class HotelProfile : Profile
    {
        public HotelProfile()
        {
            CreateMap<Hotel, HotelDto>();
        }
    }
}
