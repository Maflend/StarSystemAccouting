using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemAccouting.Domain
{
    public class SpaceObject
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Age { get; set; }
        public double Diameter { get; set; }
        public double Weight { get; set; }
        public string StarSystemName { get; set; }
        public StarSystem StarSystem { get; set; }
    }
}
