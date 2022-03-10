using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemAccouting.Domain
{
    public class StarSystem
    {
        public string Name { get; set; }
        public double Age { get; set; }
        public SpaceObject CenterOfGravity { get; set; }
        public List<SpaceObject> SpaceObjects { get; set; }
    }
}
