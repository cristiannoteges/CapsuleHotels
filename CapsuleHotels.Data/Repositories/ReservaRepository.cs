using CapsuleHotels.Data.Repositories.Contracts;
using CapsuleHotels.Model.Entities;

namespace CapsuleHotels.Data.Repositories
{
    public class ReservaRepository: EntityBaseRepository<Reserva>, IReservaRepository
    {
        public ReservaRepository(CapsuleHotelsContext context) : base(context)
        {

        }
    }
}
