using System;
using System.Collections.Generic;
using System.Text;

namespace CapsuleHotels.Model.Entities.Contracts
{
    public interface ICreationAuditedEntity
    {
        DateTime FechaCreacion { get; set; }
        Guid UsuarioCreacionId { get; set; }
    }
}
