using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Taxi.Web.Data.Entities;

namespace Taxi.Web.Data
{
    public class DataContext : IdentityDbContext<UserEntity>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<TaxyEntity> Taxis { get; set; }
        public DbSet<ViajeEntity> Viajes { get; set; }
        public DbSet<ViajeDetalleEntity> ViajesDetalles { get; set; }
        public DbSet<UserGroupEntity> UserGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaxyEntity>()
            .HasIndex(t => t.Placa)
            .IsUnique();

        }

    }
}
