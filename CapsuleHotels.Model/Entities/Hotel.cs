using CapsuleHotels.Model.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapsuleHotels.Model.Entities
{
    public class Hotel : Entity
    {
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public int NumHabitaciones { get; set; }
    }
}
