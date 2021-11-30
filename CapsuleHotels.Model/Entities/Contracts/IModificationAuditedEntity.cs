using System;
using System.Collections.Generic;
using System.Text;

namespace CapsuleHotels.Model.Entities.Contracts
{
    public interface IModificationAuditedEntity
    {
        DateTime? FechaModificacion { get; set; }
        Guid? UsuarioModificacionId { get; set; }
    }
}
