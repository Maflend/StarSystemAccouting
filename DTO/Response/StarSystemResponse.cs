using StarSystemAccouting.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemAccouting.Application.DTOs.Response
{
    public class StarSystemResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Age { get; set; }
        public string CenterOfGravityName { get; set; }
    }
}
