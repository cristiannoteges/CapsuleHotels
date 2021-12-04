using AutoMapper;
using CapsuleHotels.Data.Repositories.Contracts;
using CapsuleHotels.Dtos.Entites;
using CapsuleHotels.Dtos.ResourceParameters;
using CapsuleHotels.Model.Entities;
using CapsuleHotels.Services.Business.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapsuleHotels.Services.Business
{
    public class ReservaService : IReservaService
    {
        private readonly IMapper _mapper;
        private readonly IReservaRepository _reservaRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly IHotelService _hotelService;
        private readonly IHabitacionService _habitacionService;
        private readonly ILogger _logger;
        public ReservaService(IMapper mapper,
            IReservaRepository reservaRepository, IUsuarioService usuarioService, IHotelService hotelService, IHabitacionService habitacionService, ILogger<ReservaService> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _reservaRepository = reservaRepository ?? throw new ArgumentNullException(nameof(reservaRepository));
            _usuarioService = usuarioService ?? throw new ArgumentNullException(nameof(usuarioService));
            _hotelService = hotelService ?? throw new ArgumentNullException(nameof(hotelService));
            _habitacionService = habitacionService ?? throw new ArgumentNullException(nameof(habitacionService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        //Esta función no se ha pedido en la prueba pero la he añadido para cuando creemos una reserva, nos devuelva el objeto con los datos de la misma
        public async Task<ReservaDto> GetReservaAsync(int id)
        {
            //Especificamos que queremos los parametros del correo del usuario, hotel y el numero de la habitacion
            var reserva = await _reservaRepository.GetSingleIncludingAsync(x=> x.Id==id, x=> x.Usuario, x=> x.Hotel, x=> x.Habitacion);

            return _mapper.Map<ReservaDto>(reserva);
        }

        public async Task<IEnumerable<ReservaDto>> GetReservasRangoAsync(ReservasSearchResourceParameters reservasSearchResourceParameters)
        {
            //Devolvemos todas las reservas, activas y canceladas, para una empresa en un rango de fechas.
            var reservas = await _reservaRepository.FindByIncludingAsync
               (x => (x.HotelId == reservasSearchResourceParameters.HotelId)
               && (x.CheckIn < reservasSearchResourceParameters.CheckOut && x.CheckOut > reservasSearchResourceParameters.CheckIn),
               x => x.Usuario, 
               x => x.Hotel, 
               x => x.Habitacion);

            return _mapper.Map<IEnumerable<ReservaDto>>(reservas);
        }

        public async Task<ReservaDto> CreateReservaAsync(ReservaForCreationDto reservaForCreationDto)
        {
            //Comprobar si existe usuario
            if (!await _usuarioService.ExisteUsuario(reservaForCreationDto.usuarioId))
            {
                _logger.LogError("Usuario no encontrado");
                return null;
            }
            //Comprobar si existe Hotel
            if (!await _hotelService.ExisteHotel(reservaForCreationDto.hotelId))
            {
                _logger.LogError("Hotel no encontrado");
                return null;
            }
            //Comprobar si hay habitaciones libres
            //Funcion privada que nos devolvera que habitación hay libre para el rango de fechas definido
            var habitacionLibreId = await GetHabitacionReservaLibreAsync(reservaForCreationDto.hotelId, reservaForCreationDto.checkin, reservaForCreationDto.checkout);
            if(habitacionLibreId != 0)
            {                
                //Creo reserva
                var reserva = new Reserva()
                {
                    Fechareserva= DateTime.Now,
                    CheckIn= reservaForCreationDto.checkin,
                    CheckOut = reservaForCreationDto.checkout,
                    UsuarioId=reservaForCreationDto.usuarioId,
                    HotelId=reservaForCreationDto.hotelId,
                    HabitacionId=habitacionLibreId.Value                  
                };

                //Guardamos
                try
                {
                    _reservaRepository.Add(reserva);
                    await _reservaRepository.SaveAsync();
                    return await GetReservaAsync(reserva.Id);
                }
                catch (Exception e)
                {
                    _logger.LogError("No se ha podido guardar la reserva. Error: {Error}", e.Message); 
                    return null;
                }
                
            }
            else
            {
                _logger.LogInformation("No hay habitaciones libres para este hotel en el rango de fehas {checkin} a {checkout}", reservaForCreationDto.checkin, reservaForCreationDto.checkout);
                return null;
            }   
        }        

        public async Task<bool> DeleteReservaAsync(int id)
        {
            var reserva = await _reservaRepository.GetSingleAsync(id);
            if(reserva == null)
            {
                return false;
            }

            reserva.Cancelado = true;
            try
            {
                _reservaRepository.Update(reserva);
                await _reservaRepository.SaveAsync();
            }
            catch (Exception e)
            {
                _logger.LogError("No se ha podido eliminar la reserva. {Error}", e.Message);
                return false;
            }


            return true;
        }

        private async Task<int?> GetHabitacionReservaLibreAsync(int hotelId, DateTime checkin, DateTime checkout)
        {
            var habitaciones = (await _habitacionService.GetHabitacionesAsync(hotelId)).Select(x => x.Id);

            var habitacionesOcupadas = _reservaRepository.GetAllQueryable()
                .Where(x => (x.HotelId == hotelId)
                && (x.CheckIn < checkout && x.CheckOut > checkin)
                && (x.Cancelado == false))
                .Select(y => y.HabitacionId).Distinct();

            return habitaciones.Where(x => !habitacionesOcupadas.Contains(x)).FirstOrDefault();
        }
    }
}
