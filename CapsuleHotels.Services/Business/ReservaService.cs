using AutoMapper;
using CapsuleHotels.Data.Repositories.Contracts;
using CapsuleHotels.Dtos.Entites;
using CapsuleHotels.Dtos.ResourceParameters;
using CapsuleHotels.Model.Entities;
using CapsuleHotels.Services.Business.Contracts;
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

        public ReservaService(IMapper mapper,
            IReservaRepository reservaRepository, IUsuarioService usuarioService, IHotelService hotelService, IHabitacionService habitacionService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _reservaRepository = reservaRepository ?? throw new ArgumentNullException(nameof(reservaRepository));
            _usuarioService = usuarioService ?? throw new ArgumentNullException(nameof(usuarioService));
            _hotelService = hotelService ?? throw new ArgumentNullException(nameof(hotelService));
            _habitacionService = habitacionService ?? throw new ArgumentNullException(nameof(habitacionService));
        }

        public async Task<ReservaDto> GetReservaAsync(int id)
        {
            var reserva = await _reservaRepository.GetSingleIncludingAsync(x=> x.Id==id, x=>x.Usuario, x=> x.Hotel, x=> x.Habitacion);

            return _mapper.Map<ReservaDto>(reserva);
        }

        public async Task<IEnumerable<ReservaDto>> GetReservasRangoAsync(ReservasSearchResourceParameters reservasSearchResourceParameters)
        {
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
                return null;
            }
            //Comprobar si existe Hotel
            if (!await _hotelService.ExisteHotel(reservaForCreationDto.hotelId))
            {
                return null;
            }
            //Comprobar si hay habitaciones libres
            var habitacionLibreId = await GetHabitacionReservaLibreAsync(reservaForCreationDto.hotelId, reservaForCreationDto.checkin, reservaForCreationDto.checkout);
            if(habitacionLibreId.HasValue)
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
                _reservaRepository.Add(reserva);
                await _reservaRepository.SaveAsync();
                return await GetReservaAsync(reserva.Id);
            }
            else
            {
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

            _reservaRepository.Update(reserva);
            await _reservaRepository.SaveAsync();

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
