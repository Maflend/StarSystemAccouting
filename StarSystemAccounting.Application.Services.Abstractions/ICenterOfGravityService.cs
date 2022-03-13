using StarSystemAccouting.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemAccouting.Application.Services.Abstractions
{
    public interface ICenterOfGravityService
    {
        Task<ServiceResponse<Guid>> SetAsync(Guid starSystemId, Guid spaceObjectId);
    }
}
