using CapsuleHotels.Data.Configurations.Extensions;
using CapsuleHotels.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapsuleHotels.Data.Configurations
{
    public class UsuarioConfiguration:IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario", "Usuarios");
            builder.ConfigureByConvention();
            builder.Property(p => p.Nombre)
                .HasMaxLength(20);
            builder.Property(p => p.Apellidos)
                .HasMaxLength(70);
            //Todo: el mail debe de ser unico
        }
    }
}
