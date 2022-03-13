using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemAccouting.Domain
{
    public class ObjectType
    {
        public string Name { get; set; }
        public List<SpaceObject> SpaceObjects { get; set; }
    }
}
