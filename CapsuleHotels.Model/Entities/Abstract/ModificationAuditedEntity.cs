using CapsuleHotels.Model.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapsuleHotels.Model.Entities.Abstract
{
    public abstract class ModificationAuditedEntity : CreationAuditedEntity, IModificationAuditedEntity
    {
        public DateTime? FechaModificacion { get; set; }
        public Guid? UsuarioModificacionId { get; set; }
    }
}
