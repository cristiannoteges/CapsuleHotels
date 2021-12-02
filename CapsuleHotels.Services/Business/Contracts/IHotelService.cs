using System.Threading.Tasks;

namespace CapsuleHotels.Services.Business.Contracts
{
    public interface IHotelService
    {
        Task<bool> ExisteHotel(int id);
    }
}
