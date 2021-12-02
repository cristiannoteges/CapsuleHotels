using CapsuleHotels.Dtos.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CapsuleHotels.Services.Business.Contracts
{
    public interface IHabitacionService
    {
        Task<IEnumerable<HabitacionDto>> GetHabitacionesAsync(int hotelId);
    }
}
