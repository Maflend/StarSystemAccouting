using StarSystemAccouting.Application.DTOs;
using StarSystemAccouting.Application.DTOs.Request.StarSystem;
using StarSystemAccouting.Application.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StarSystemAccouting.Application.Services.Abstractions
{
    public interface IStarSystemService
    {
        Task<ServiceResponse<List<StarSystemResponse>>> GetAllAsync();
        Task<ServiceResponse<StarSystemResponse>> GetByIdAsync(Guid id);
        Task<ServiceResponse<Guid>> CreateAsync(StarSystemCreateRequest starSystem);
        Task<ServiceResponse<Guid>> UpdateAsync(StarSystemUpdateRequest starSystem);
        Task<ServiceResponse<string>> DeleteAsync(string name);
    }
}
