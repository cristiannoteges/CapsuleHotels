using System.Threading.Tasks;

namespace CapsuleHotels.Services.Business.Contracts
{
    public interface IUsuarioService
    {
        Task<bool> ExisteUsuario(int id);
    }
}
