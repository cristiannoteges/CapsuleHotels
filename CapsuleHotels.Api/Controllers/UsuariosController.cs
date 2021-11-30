using CapsuleHotels.Api.Controllers.Abstract;
using CapsuleHotels.Services.Business.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CapsuleHotels.Api.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ApiControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService ?? throw new ArgumentNullException(nameof(usuarioService));
        }
    }
}
