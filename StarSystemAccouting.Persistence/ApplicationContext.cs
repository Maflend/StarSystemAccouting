using Microsoft.EntityFrameworkCore;

using StarSystemAccouting.Domain;
using StarSystemAccouting.Persistence.EntityTypeConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemAccouting.Persistence
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {

        }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<SpaceObject> SpaceObjects { get; set; }
        public DbSet<StarSystem> StarSystems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SpaceObjectConfigration());
            modelBuilder.ApplyConfiguration(new StarSystemConfiguration());
        }
    }
}
