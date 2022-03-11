using Microsoft.EntityFrameworkCore;
using StarSystemAccouting.Application;
using StarSystemAccouting.Domain;
using StarSystemAccouting.Persistence.EntityTypeConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemAccouting.Persistence
{
    public class AppContext : DbContext, IAppContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options) { }
        public DbSet<SpaceObject> SpaceObjects { get; set; }
        public DbSet<StarSystem> StarSystems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SpaceObjectConfigration());
            modelBuilder.ApplyConfiguration(new StarSystemConfiguration());
        }
    }
}
