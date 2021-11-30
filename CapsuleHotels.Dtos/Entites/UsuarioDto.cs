using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapsuleHotels.Dtos.Entites
{
    public class UsuarioDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Mail { get; set; }
        public string Direccion { get; set; }

        public DateTime FechaCreacion { get; set; }
        public Guid UsuarioCreacionId { get; set; }

        public DateTime? FechaModificacion { get; set; }
        public Guid? UsuarioModificacionId { get; set; }

        public bool EsBorrado { get; set; }
        public DateTime? FechaBorrado { get; set; }
        public Guid? UsuarioBorradoId { get; set; }
    }
}
