using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarSystemAccouting.Application.DTOs.Request.SpaceObject;
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

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(SpaceObjectCreateRequest request)
        {
            var spaceObjectServiceResponse = await _spaceObjectService.CreateAsync(request);
            if (!spaceObjectServiceResponse.Status)
                return BadRequest(spaceObjectServiceResponse.Message);

            return Ok(spaceObjectServiceResponse.Data);
        }
    }
}
