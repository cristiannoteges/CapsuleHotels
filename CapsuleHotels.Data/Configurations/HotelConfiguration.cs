using CapsuleHotels.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapsuleHotels.Data.Configurations
{
    public class HotelConfiguration: IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.ToTable("Hotel");

            builder.Property(p => p.Nombre)
                .HasMaxLength(50);

            builder.Property(p => p.Pais)
                .HasMaxLength(50);

            builder.Property(p => p.Latitud)
                .HasColumnType("decimal(22,19)");

            builder.Property(p => p.Longitud)
                .HasColumnType("decimal(22,19)");

            builder.Property(p => p.Descripcion)
                .HasMaxLength(2000);

            builder.Property(p => p.Activo)
                .IsRequired()
                .HasDefaultValue(true);

            builder.Property(p => p.NumHabitaciones)
                .IsRequired()
                .HasDefaultValue(1);
        }
    }
}
