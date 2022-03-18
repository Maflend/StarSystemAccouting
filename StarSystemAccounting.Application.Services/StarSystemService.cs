using Microsoft.EntityFrameworkCore;
using StarSystemAccouting.Application.DTOs;
using StarSystemAccouting.Application.DTOs.Request.SpaceObject;
using StarSystemAccouting.Application.DTOs.Request.StarSystem;
using StarSystemAccouting.Application.DTOs.Response;
using StarSystemAccouting.Application.Services.Abstractions;
using StarSystemAccouting.Domain;
using StarSystemAccouting.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemAccouting.Application.Services
{
    public class StarSystemService : IStarSystemService
    {
        private readonly ApplicationContext _db;
        private readonly ISpaceObjectService _spaceObjectService;
        private readonly ICenterOfGravityService _centerOfGravityService;

        public StarSystemService(ApplicationContext db, ISpaceObjectService spaceObjectService, ICenterOfGravityService centerOfGravityService)
        {
            _db = db;
            _spaceObjectService = spaceObjectService;
            _centerOfGravityService = centerOfGravityService;
        }

      

        public async Task<ServiceResponse<Guid>> CreateAsync(StarSystemCreateRequest request)
        {
            if (_db.StarSystems.Any(s => s.Name == request.Name))
            {
                return new ServiceResponse<Guid>()
                {
                    Status = false,
                    Message = "Звездная система с таким именем уже существует",
                    Data = Guid.Empty,
                };
            }

            StarSystem entity = new()
            {
                Name = request.Name,
                Age = request.Age,
            };

            await _db.StarSystems.AddAsync(entity);

            await _db.SaveChangesAsync();




            SpaceObjectCreateRequest spaceObjectCreateRequest = new()
            {
                Name = request.CenterOfGravityName,
                Age = request.CenterOfGravityAge,
                Type = request.CenterOfGravityType,
                Diameter = request.CenterOfGravityDiameter,
                Weight = request.CenterOfGravityWeight,
                StarSystemId = entity.Id

            };

            var spaceObjectServiceResponse = await _spaceObjectService.CreateAsync(spaceObjectCreateRequest);
            if (!spaceObjectServiceResponse.Status)
            {
                _db.StarSystems.Remove(entity);
                await _db.SaveChangesAsync();
                return new ServiceResponse<Guid>()
                {
                    Status = false,
                    Message = spaceObjectServiceResponse.Message,
                    Data = Guid.Empty,
                };
            }


            var centerOfGravityServiceResponse = await _centerOfGravityService.SetAsync(entity.Id, spaceObjectServiceResponse.Data);
            if (!centerOfGravityServiceResponse.Status)
            {
                _db.StarSystems.Remove(entity);
                _db.SpaceObjects.Remove(_db.SpaceObjects.First(sobj=>sobj.Id == spaceObjectServiceResponse.Data));
                await _db.SaveChangesAsync();
                return new ServiceResponse<Guid>()
                {
                    Status = false,
                    Message = centerOfGravityServiceResponse.Message,
                    Data = Guid.Empty,
                };
            }

            entity.CenterOfGravityId = spaceObjectServiceResponse.Data;
            await _db.SaveChangesAsync();


            return new ServiceResponse<Guid>()
            {
                Status = true,
                Data = entity.Id
            };
        }

        public async Task<ServiceResponse<Guid>> DeleteAsync(Guid id)
        {
            if(!_db.StarSystems.Any(s=>s.Id == id))
            {
                return new ServiceResponse<Guid>()
                {
                    Status = false,
                    Message = "Звездная система не найдена",
                    Data = new()
                };
            }


            _db.StarSystems.Remove(new StarSystem() { Id = id});
            await _db.SaveChangesAsync();

            return new ServiceResponse<Guid>()
            {
                Status = true,
                Data = id
            };
        }

        public async Task<ServiceResponse<List<StarSystemResponse>>> GetAllAsync()
        { 
            var starSystemEntity = await _db.StarSystems
               .Include(starsyst => starsyst.SpaceObjects)
               .Select(res => new StarSystemResponse { Id = res.Id, Age = res.Age, Name = res.Name, CenterOfGravityName = res.SpaceObjects.First(obj=>obj.Id == res.CenterOfGravityId).Name }).ToListAsync();

            if (starSystemEntity == null)
                return new ServiceResponse<List<StarSystemResponse>>()
                {
                    Status = true,
                    Data = new()
                };

            return new ServiceResponse<List<StarSystemResponse>>()
            {
                Status = true,
                Data = starSystemEntity
            };


        }

        public async Task<ServiceResponse<StarSystemResponse>> GetByIdAsync(Guid id)
        {
            var starSystemEntity = await _db.StarSystems.FirstOrDefaultAsync(s => s.Id == id);

            

            if (starSystemEntity == null)
                return new ServiceResponse<StarSystemResponse>()
                {
                    Status = false,
                    Message = "Звездная система не найдена",
                    Data = new()
                };


            _db.Entry(starSystemEntity).Collection(s => s.SpaceObjects).Query().FirstOrDefault(sobj => sobj.Id == starSystemEntity.CenterOfGravityId);

            StarSystemResponse response = new()
            {
                Id = starSystemEntity.Id,
                Age = starSystemEntity.Age,
                Name = starSystemEntity.Name,
                CenterOfGravityName = starSystemEntity.SpaceObjects.First().Name
            };

            return new ServiceResponse<StarSystemResponse>()
            {
                Status = true,
                Data = response
            };


        }

        public async Task<ServiceResponse<Guid>> UpdateAsync(StarSystemUpdateRequest starSystem)
        {

            if (!_db.StarSystems.Any(s => s.Id == starSystem.Id))
            {
                return new ServiceResponse<Guid>()
                {
                    Status = false,
                    Message = "Звездная система для изменений не найдена",
                    Data = starSystem.Id
                };
            }

            var StarSystemEntity = _db.StarSystems.First(s=>s.Id == starSystem.Id);

            StarSystemEntity.Name = starSystem.Name;
            StarSystemEntity.Age = starSystem.Age;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return new ServiceResponse<Guid>()
                {
                    Status = false,
                    Message = ex.Message,
                    Data = starSystem.Id
                };
            }

            return new ServiceResponse<Guid>()
            {
                Status = true,
                Data = StarSystemEntity.Id
            };
        }
    }
}
