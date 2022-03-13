using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemAccouting.Domain
{
    public class SpaceObject
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public double Age { get; set; }
        public double Diameter { get; set; }
        public double Weight { get; set; }

        public Guid TypeId { get; set; }
        public SpaceObjectType Type { get; set; }
        public Guid StarSystemId { get; set; }
        public StarSystem StarSystem { get; set; }
    }
}
