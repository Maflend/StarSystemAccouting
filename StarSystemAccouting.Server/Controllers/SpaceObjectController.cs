using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarSystemAccouting.Application.DTOs.Request.SpaceObject;
using StarSystemAccouting.Application.DTOs.Response;
using StarSystemAccouting.Application.Services.Abstractions;

namespace StarSystemAccouting.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpaceObjectController : ControllerBase
    {
        private readonly ISpaceObjectService _spaceObjectService;

        public SpaceObjectController(ISpaceObjectService spaceObjectService)
        {
            _spaceObjectService = spaceObjectService;
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<SpaceObjectResponse>> GetById(Guid id)
        {
            var spaceObjectServiceResponse = await _spaceObjectService.GetById(id);
            if (!spaceObjectServiceResponse.Status)
                return BadRequest(spaceObjectServiceResponse.Message);

            return Ok(spaceObjectServiceResponse.Data);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<SpaceObjectResponse>>> GetAll()
        {
            var spaceObjectServiceResponse = await _spaceObjectService.GetAll();
            if(!spaceObjectServiceResponse.Status)
                return BadRequest(spaceObjectServiceResponse.Message);

            return Ok(spaceObjectServiceResponse.Data);
        }

        [HttpGet("GetAllByStarSystemId")]
        public async Task<ActionResult<List<SpaceObjectResponse>>> GetAllByStarSystemId(Guid StarSystemId)
        {
            var spaceObjectServiceResponse = await _spaceObjectService.GetAllByStarSystemId(StarSystemId);
            if (!spaceObjectServiceResponse.Status)
                return BadRequest(spaceObjectServiceResponse.Message);

            return Ok(spaceObjectServiceResponse.Data);
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Guid>> Create(SpaceObjectCreateRequest request)
        {
            var spaceObjectServiceResponse = await _spaceObjectService.CreateAsync(request);
            if (!spaceObjectServiceResponse.Status)
                return BadRequest(spaceObjectServiceResponse.Message);

            return Ok(spaceObjectServiceResponse.Data);
        }

        [HttpPost("Update")]
        public async Task<ActionResult<Guid>> Update(SpaceObjectUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var spaceObjectServiceResponse = await _spaceObjectService.UpdateAsync(request);
            if (!spaceObjectServiceResponse.Status)
                return BadRequest(spaceObjectServiceResponse.Message);

            return Ok(spaceObjectServiceResponse.Data);
        }


        [HttpDelete("Delete")]
        public async Task<ActionResult<Guid>> Delete(Guid id)
        {
            var spaceObjectServiceResponse = await _spaceObjectService.DeleteAsync(id);
            if (!spaceObjectServiceResponse.Status)
                return BadRequest(spaceObjectServiceResponse.Message);

            return Ok(spaceObjectServiceResponse.Data);
        }
        
    }
}
