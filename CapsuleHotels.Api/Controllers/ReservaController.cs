using CapsuleHotels.Api.Controllers.Abstract;
using CapsuleHotels.Dtos.Entites;
using CapsuleHotels.Dtos.ResourceParameters;
using CapsuleHotels.Services.Business.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapsuleHotels.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ApiControllerBase
    {
        private readonly IReservaService _reservaService;

        public ReservaController(IReservaService reservaService)
        {
            _reservaService = reservaService ?? throw new ArgumentNullException(nameof(reservaService));
        }

        //Get: api/Reserva/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ReservaDto>> GetReservaAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var reserva = await _reservaService.GetReservaAsync(id);

            if (reserva == null)
            {
                return NotFound();
            }

            return Ok(reserva);
        }

        //Get: api/Reservas
        [HttpGet]
        public async Task<ActionResult<ReservaDto>> GetReservasRangoAsync([FromQuery]ReservasSearchResourceParameters reservaSearchResourceParameters)
        {
            if (reservaSearchResourceParameters == null || reservaSearchResourceParameters.CheckIn > reservaSearchResourceParameters.CheckOut)
            {
                return BadRequest();
            }

            var reservas = await _reservaService.GetReservasRangoAsync(reservaSearchResourceParameters);

            if (reservas == null)
            {
                return NotFound();
            }

            return Ok(reservas);
        }

        // Post: api/Reserva
        [HttpPost]
        public async Task<ActionResult<ReservaDto>> CreateReservaAsync([FromBody] ReservaForCreationDto reservaForCreationDto)
        {
            if (reservaForCreationDto == null)
            {
                return BadRequest();
            }

            var reserva = await _reservaService.CreateReservaAsync(reservaForCreationDto);

            return Ok(reserva);
        }

        //Delete: api/Reserva/{id}
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteReservaAsync(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            bool result = await _reservaService.DeleteReservaAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }        
    }
}
