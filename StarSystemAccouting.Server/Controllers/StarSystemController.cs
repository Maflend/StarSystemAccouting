using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarSystemAccouting.Application.DTOs.Request;
using StarSystemAccouting.Application.DTOs.Request.SpaceObject;
using StarSystemAccouting.Application.DTOs.Request.StarSystem;
using StarSystemAccouting.Application.DTOs.Response;
using StarSystemAccouting.Application.Services.Abstractions;
using System.Net;

namespace StarSystemAccouting.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarSystemController : ControllerBase
    {
        private readonly IStarSystemService _starSystemService;
        private readonly ISpaceObjectService _spaceObjectService;
        private readonly ICenterOfGravityService _centerOfGravityService;

        public StarSystemController(IStarSystemService starSystemService, ISpaceObjectService spaceObjectService, ICenterOfGravityService centerOfGravityService)
        {
            _starSystemService = starSystemService;
            _spaceObjectService = spaceObjectService;
            _centerOfGravityService = centerOfGravityService;
        }

        [HttpGet("/GetById")]
        public async Task<ActionResult<StarSystemResponse>> GetById(Guid id)
        {
            var starSystemServiceResponse = await _starSystemService.GetByIdAsync(id);

            if(!starSystemServiceResponse.Status)
                return BadRequest(starSystemServiceResponse.Message);

            return Ok(starSystemServiceResponse.Data);
        }


        [HttpGet("/GetAll")]
        public async Task<ActionResult<StarSystemResponse>> GetAll()
        {
            var starSystemServiceResponse = await _starSystemService.GetAllAsync();

            if (!starSystemServiceResponse.Status)
                return BadRequest(starSystemServiceResponse.Message);

            return Ok(starSystemServiceResponse.Data);
        }



        [HttpPost("/Create")]
        public async Task<ActionResult<Guid>> Create(StarSystemCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var starSystemServiceResponse = await _starSystemService.CreateAsync(request);
            if (!starSystemServiceResponse.Status)
            {
                return BadRequest(starSystemServiceResponse.Message);
            }

            return Ok(starSystemServiceResponse.Data);

        }

        [HttpDelete]
        public async Task<ActionResult<string>> Delete(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                return BadRequest("string is empty");
            }

            var response = await _starSystemService.DeleteAsync(name);

            if(!response.Status)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);
        }
        [HttpPost("/Update")]
        public async Task<ActionResult<Guid>> Update(StarSystemUpdateRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _starSystemService.UpdateAsync(request);

            if(!response.Status)
            {
                return BadRequest(response.Message);
            }

            return Ok(response.Data);
        }
    }
}
