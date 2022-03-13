using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarSystemAccouting.Application.DTOs.Request;
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

        public StarSystemController(IStarSystemService starSystemService)
        {
            _starSystemService = starSystemService;
        }
        [HttpPost]
        public async Task<ActionResult<StarSystemResponse>> Create(StarSystemCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _starSystemService.CreateAsync(request);

            if (!response.Status)
            {
                return BadRequest(response.Message);
            }

            return Ok(response);

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
        public async Task<ActionResult<string>> Update(StarSystemUpdateRequest request)
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

            return Ok(response);
        }
    }
}
