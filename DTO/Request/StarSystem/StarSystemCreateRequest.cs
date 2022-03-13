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


        public string CenterOfGravityName { get; set; }
        public string CenterOfGravityType { get; set; }
        public double CenterOfGravityAge { get; set; }
        public double CenterOfGravityDiameter { get; set; }
        public double CenterOfGravityWeight { get; set; }
    }
}
