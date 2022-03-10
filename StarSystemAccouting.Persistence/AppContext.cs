using Microsoft.EntityFrameworkCore;
using StarSystemAccouting.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemAccouting.Persistence
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options) { }
        public DbSet<SpaceObject> SpaceObjects { get; set; }
        public DbSet<StarSystem> StarSystems { get; set; }
    }
}
