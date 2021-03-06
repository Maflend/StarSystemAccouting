using StarSystemAccouting.Application.DTOs;
using StarSystemAccouting.Application.DTOs.Request.SpaceObject;
using StarSystemAccouting.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemAccouting.Application.Services.Abstractions
{
    public interface ISpaceObjectService
    {
        Task<ServiceResponse<SpaceObjectResponse>> GetById(Guid id);
        Task<ServiceResponse<List<SpaceObjectWithStarSystemNameResponse>>> GetAll();
        Task<ServiceResponse<List<SpaceObjectResponse>>> GetAllByStarSystemId(Guid id);
        Task<ServiceResponse<Guid>> CreateAsync(SpaceObjectCreateRequest spaceObject);
        Task<ServiceResponse<Guid>> UpdateAsync(SpaceObjectUpdateRequest request);
        Task<ServiceResponse<Guid>> DeleteAsync(Guid id);

    }
}
