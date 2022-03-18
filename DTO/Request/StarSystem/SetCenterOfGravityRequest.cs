using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemAccouting.Application.DTOs.Request.StarSystem
{
    public class SetCenterOfGravityRequest
    {
        public Guid StarSystemId { get; set; }
        public Guid SpaceObjectId { get; set; }
    }
}
