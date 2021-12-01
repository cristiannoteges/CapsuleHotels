using CapsuleHotels.Model.Entities.Abstract;
using System;

namespace CapsuleHotels.Model.Entities
{
    public class Reserva : Entity
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut{ get; set; }
        public DateTime Fechareserva { get; set; }
        public bool Cancelado { get; set; }

        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }
        public int HabitacionId { get; set; }
        public virtual Habitacion Habitacion { get; set; }
    }
}
