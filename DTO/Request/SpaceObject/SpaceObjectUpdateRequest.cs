using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemAccouting.Application.DTOs.Request.SpaceObject
{
    public class SpaceObjectUpdateRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Age { get; set; }
        public double Diameter { get; set; }
        public double Weight { get; set; }
    }
}
