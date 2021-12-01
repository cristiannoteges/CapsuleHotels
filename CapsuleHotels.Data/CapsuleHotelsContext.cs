using CapsuleHotels.Data.Configurations;
using CapsuleHotels.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CapsuleHotels.Data
{
    public class CapsuleHotelsContext : DbContext
    {
        public CapsuleHotelsContext(DbContextOptions<CapsuleHotelsContext> options) : base(options)
        {

        }
        #region DbSet
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Hotel> Hoteles { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new HotelConfiguration());
            modelBuilder.ApplyConfiguration(new HabitacionConfiguration());
            modelBuilder.ApplyConfiguration(new ReservaConfiguration());
        }
    }
}
