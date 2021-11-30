using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapsuleHotels.Dtos.Entites
{
    public class UsuarioForUpdateDto
    {
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Mail { get; set; }
        public string Direccion { get; set; }
        public Guid? UsuarioModificacionId { get; set; }
    }
}
