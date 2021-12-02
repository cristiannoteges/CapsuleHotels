using AutoMapper;
using CapsuleHotels.Data.Repositories.Contracts;
using CapsuleHotels.Dtos.Entites;
using CapsuleHotels.Services.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CapsuleHotels.Services.Business
{
    public class HabitacionService: IHabitacionService
    {
        private readonly IMapper _mapper;
        private readonly IHabitacionRepository _habitacionRepository;

        public HabitacionService(IMapper mapper,
            IHabitacionRepository habitacionRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _habitacionRepository = habitacionRepository ?? throw new ArgumentNullException(nameof(habitacionRepository));
        }

        public async Task<IEnumerable<HabitacionDto>> GetHabitacionesAsync(int hotelId)
        {
            var habitaciones = (await _habitacionRepository.FindByAsync(x => x.HotelId == hotelId)).AsEnumerable();

            return _mapper.Map<IEnumerable<HabitacionDto>>(habitaciones);
        }
    }
}
