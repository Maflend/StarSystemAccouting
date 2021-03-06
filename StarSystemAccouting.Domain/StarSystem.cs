using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemAccouting.Domain
{
    public class StarSystem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public double Age { get; set; }
        public Guid CenterOfGravityId { get; set; }
        public List<SpaceObject> SpaceObjects { get; set; }
    }
}
