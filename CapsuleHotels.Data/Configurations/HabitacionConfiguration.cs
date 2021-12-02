using CapsuleHotels.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapsuleHotels.Data.Configurations
{
    public class HabitacionConfiguration: IEntityTypeConfiguration<Habitacion>
    {
        public void Configure(EntityTypeBuilder<Habitacion> builder)
        {
            builder.ToTable("Habtacion");

            builder.Property(p => p.NumeroHabitacion)
                .IsRequired();

            builder.Property(p => p.HotelId)
                .IsRequired();
        }
    }
}
