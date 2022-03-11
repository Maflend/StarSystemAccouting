using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemAccouting.Domain
{
    public class StarSystem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Age { get; set; }
        public string CenterOfGravityName { get; set; }
        public List<SpaceObject> SpaceObjects { get; set; }
    }
}
