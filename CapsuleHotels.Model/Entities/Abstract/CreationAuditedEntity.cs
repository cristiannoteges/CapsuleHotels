using CapsuleHotels.Model.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapsuleHotels.Model.Entities.Abstract
{
    public abstract class CreationAuditedEntity : Entity, ICreationAuditedEntity
    {
        public DateTime FechaCreacion { get; set; }
        public Guid UsuarioCreacionId { get; set; }
    }
}
