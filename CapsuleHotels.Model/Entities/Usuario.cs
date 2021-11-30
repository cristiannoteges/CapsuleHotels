using CapsuleHotels.Model.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapsuleHotels.Model.Entities
{
    public class Usuario : DeletionAuditedEntity
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Mail { get; set; }
        public string Direccion { get; set; }
    }
}
