using AutoMapper;
using CapsuleHotels.Dtos.Entites;
using CapsuleHotels.Model.Entities;

namespace CapsuleHotels.Services.Mappings
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
        }
    }
}
