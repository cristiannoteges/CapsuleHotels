using CapsuleHotels.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapsuleHotels.Data.Configurations
{
    public class UsuarioConfiguration:IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.Property(p => p.Nombre)
                .HasMaxLength(20);

            builder.Property(p => p.Apellidos)
                .HasMaxLength(70);

            builder.Property(p => p.Mail)
                .IsRequired()
                .HasMaxLength(250);

            //Unico
            builder.HasIndex(p => p.Mail)
                .IsUnique();
        }
    }
}
