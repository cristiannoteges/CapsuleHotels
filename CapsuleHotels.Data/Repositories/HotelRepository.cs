using CapsuleHotels.Data.Repositories.Contracts;
using CapsuleHotels.Model.Entities;

namespace CapsuleHotels.Data.Repositories
{
    public class HotelRepository :EntityBaseRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(CapsuleHotelsContext context) : base(context)
        {

        }
    }
}
