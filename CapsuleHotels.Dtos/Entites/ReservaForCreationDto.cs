using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapsuleHotels.Dtos.Entites
{
    public class ReservaForCreationDto
    {
        public int usuarioId { get; set; }
        public int hotelId { get; set; }
        public DateTime checkin { get; set; }
        public DateTime checkout { get; set; }
    }
}
