using CapsuleHotels.Data.Repositories.Contracts;
using CapsuleHotels.Model.Entities;

namespace CapsuleHotels.Data.Repositories
{
    public class HabitacionRepository:EntityBaseRepository<Habitacion>, IHabitacionRepository
    {
        public HabitacionRepository(CapsuleHotelsContext context) : base(context)
        {

        }
    }
}
