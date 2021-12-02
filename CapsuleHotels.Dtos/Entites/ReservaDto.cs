using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapsuleHotels.Dtos.Entites
{
    public class ReservaDto
    {
        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public DateTime Fechareserva { get; set; }
        public bool Cancelado { get; set; }

        public int UsuarioId { get; set; }        
        public string UsuarioMail { get; set; }
        public int HotelId { get; set; }
        public string HotelNombre { get; set; }
        public int HabitacionId { get; set; }
        public int HabitacionNumeroHabitacion{ get; set; }
    }
}
