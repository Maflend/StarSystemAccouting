using StarSystemAccouting.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemAccouting.Application.DTOs.Request.StarSystem
{
    public class StarSystemCreateRequest
    {
        public string Name { get; set; }
        public double Age { get; set; }
        public SpaceObjectForStarSystemCreateRequest CenterOfGravity { get; set; }
    }
}
