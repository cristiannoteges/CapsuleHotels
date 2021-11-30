using CapsuleHotels.Data.Repositories.Contracts;
using CapsuleHotels.Model.Entities;

namespace CapsuleHotels.Data.Repositories
{
    public class UsuarioRepository : EntityBaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(CapsuleHotelsContext context) : base(context)
        {

        }
    }
}
