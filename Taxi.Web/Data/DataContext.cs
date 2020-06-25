using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi.Web.Data.Entities;

namespace Taxi.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options)
        {
        }

        public DbSet<TaxyEntity> Taxis { get; set; }
        public DbSet<ViajeEntity> Viajes { get; set; }
        public DbSet<ViajeDetalleEntity> ViajesDetalles { get; set; }
    }
}
