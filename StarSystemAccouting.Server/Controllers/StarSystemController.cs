using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarSystemAccouting.Application.DTOs.Request;
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
        public async Task<ActionResult<StarSystemResponse>> Create(StarSystemRequest request)
        {
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //var response = await _starSystemService.CreateAsync(request);

            //if(!response.Status)
            //{
            //    return BadRequest(response.Message);
            //}
            //return Ok(response);

         
            var response = await _starSystemService.CreateAsync(request);

            return Ok(response);

        }
    }
}
