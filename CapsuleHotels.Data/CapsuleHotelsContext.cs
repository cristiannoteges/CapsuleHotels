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
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        }
    }
}
