using AutoMapper;
using CapsuleHotels.Data.Repositories.Contracts;
using CapsuleHotels.Services.Business.Contracts;
using System;
using System.Threading.Tasks;

namespace CapsuleHotels.Services.Business
{
    public class HotelService : IHotelService
    {
        private readonly IMapper _mapper;
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IMapper mapper,
            IHotelRepository hotelRepository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _hotelRepository = hotelRepository ?? throw new ArgumentNullException(nameof(hotelRepository));
        }
        public async Task<bool> ExisteHotel(int id)
        {
            var hotel = await _hotelRepository.GetSingleAsync(id);

            return hotel is null ? false : true;
        }
    }
}
