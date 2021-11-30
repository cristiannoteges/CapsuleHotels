using CapsuleHotels.Model.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapsuleHotels.Data.Configurations.Extensions
{
    public static class EntityTypeBuilderExtensions
    {
        public static void ConfigureByConvention(this EntityTypeBuilder builder)
        {
            builder.TryConfigureCreationAuditedEntity();
            builder.TryConfigureModificationAuditedEntity();
            builder.TryConfigureDeletionAuditedEntity();
        }

        public static void TryConfigureCreationAuditedEntity(this EntityTypeBuilder builder)
        {
            if (builder.Metadata.ClrType.IsAssignableTo(typeof(ICreationAuditedEntity)))
            {
                builder.Property(nameof(ICreationAuditedEntity.FechaCreacion))
                    .IsRequired()
                    .HasColumnName(nameof(ICreationAuditedEntity.FechaCreacion));

                builder.Property(nameof(ICreationAuditedEntity.UsuarioCreacionId))
                    .IsRequired()
                    .HasColumnName(nameof(ICreationAuditedEntity.UsuarioCreacionId));
            }
        }

        public static void TryConfigureModificationAuditedEntity(this EntityTypeBuilder builder)
        {
            if (builder.Metadata.ClrType.IsAssignableTo(typeof(IModificationAuditedEntity)))
            {
                builder.Property(nameof(IModificationAuditedEntity.FechaModificacion))
                    .IsRequired(false)
                    .HasColumnName(nameof(IModificationAuditedEntity.FechaModificacion));

                builder.Property(nameof(IModificationAuditedEntity.UsuarioModificacionId))
                    .IsRequired(false)
                    .HasColumnName(nameof(IModificationAuditedEntity.UsuarioModificacionId));
            }
        }

        public static void TryConfigureDeletionAuditedEntity(this EntityTypeBuilder builder)
        {
            if (builder.Metadata.ClrType.IsAssignableTo(typeof(IDeletionAuditedEntity)))
            {
                builder.Property(nameof(IDeletionAuditedEntity.EsBorrado))
                    .IsRequired()
                    .HasDefaultValue(false)
                    .HasColumnName(nameof(IDeletionAuditedEntity.EsBorrado));

                builder.Property(nameof(IDeletionAuditedEntity.FechaBorrado))
                    .IsRequired(false)
                    .HasColumnName(nameof(IDeletionAuditedEntity.FechaBorrado));

                builder.Property(nameof(IDeletionAuditedEntity.UsuarioBorradoId))
                    .IsRequired(false)
                    .HasColumnName(nameof(IDeletionAuditedEntity.UsuarioBorradoId));
            }
        }
    }
}
