using CapsuleHotels.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapsuleHotels.Data.Configurations
{
    public class ReservaConfiguration : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder) 
        { 
            builder.ToTable("Reserva");

            builder.Property(p => p.CheckIn)
                .IsRequired();

            builder.Property(p => p.CheckOut)
                .IsRequired();

            builder.Property(p => p.Fechareserva)
                .IsRequired();

            builder.Property(p => p.Cancelado)
                .IsRequired()
                .HasDefaultValue(false);

            builder.Property(p => p.UsuarioId)
                .IsRequired();

            builder.Property(p => p.HotelId)
                .IsRequired();

            builder.Property(p => p.HabitacionId)
                .IsRequired();
        }
    }
}
