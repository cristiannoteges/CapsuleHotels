﻿using CapsuleHotels.Model.Entities.Abstract;

namespace CapsuleHotels.Model.Entities
{
    public class Habitacion:Entity
    {
        public int NumeroHabitacion { get; set; }
        
        public int HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }
    }
}
