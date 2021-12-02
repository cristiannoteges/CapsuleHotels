using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapsuleHotels.Dtos.Entites
{
    public class HabitacionDto
    {
        public int Id { get; set; }
        public int NumeroHabitacion { get; set; }

        public int HotelId { get; set; }
        public virtual HotelDto Hotel { get; set; }
    }
}
