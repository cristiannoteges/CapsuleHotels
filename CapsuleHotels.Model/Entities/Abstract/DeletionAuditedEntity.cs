using CapsuleHotels.Model.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapsuleHotels.Model.Entities.Abstract
{
    public abstract class DeletionAuditedEntity : ModificationAuditedEntity, IDeletionAuditedEntity
    {
        public bool EsBorrado { get; set; }
        public DateTime? FechaBorrado { get; set; }
        public Guid? UsuarioBorradoId { get; set ; }
    }
}
