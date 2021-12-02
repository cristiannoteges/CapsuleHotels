namespace CapsuleHotels.Dtos.Entites
{
    public class HotelDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Pais { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public int NumHabitaciones { get; set; }
    }
}
