using AutoMapper;
using CapsuleHotels.Data.Repositories.Contracts;
using CapsuleHotels.Services.Business.Contracts;
using System;
using System.Threading.Tasks;

namespace CapsuleHotels.Services.Business
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IMapper mapper,
            IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
        }
        public async Task<bool> ExisteUsuario(int id)
        {
            var usuario = await _usuarioRepository.GetSingleAsync(id);

            return usuario is null ? false: true;
        }
    }
}
