using System;
using System.Collections.Generic;
using System.Text;

namespace CapsuleHotels.Model.Entities.Contracts
{
    public interface IDeletionAuditedEntity
    {
        bool EsBorrado { get; set; }
        DateTime? FechaBorrado { get; set; }
        Guid? UsuarioBorradoId { get; set; }
    }
}
