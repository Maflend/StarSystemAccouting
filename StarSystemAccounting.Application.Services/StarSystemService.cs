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

        public StarSystemService(ApplicationContext db, ISpaceObjectService spaceObjectService)
        {
            _db = db;
            _spaceObjectService = spaceObjectService;
        }

        public async Task<ServiceResponse<Guid>> SetCenterOfGravity(Guid starSystemId, Guid spaceObjectId)
        {
            var starSystemEntity = await _db.StarSystems.FirstAsync(s => s.Id == starSystemId);
            if (starSystemEntity == null)
                return new ServiceResponse<Guid>
                {
                    Status = false,
                    Message = "Звездная система не существует",
                    Data = new()
                };



            var spaceObject = await _db.SpaceObjects.FirstAsync(sobj => sobj.Id == spaceObjectId);

            if (spaceObject == null)
                return new ServiceResponse<Guid>
                {
                    Status = false,
                    Message = "Космический обьект не существует",
                    Data = new()
                };

            if (spaceObject.Type != "Звезда" )
                return new ServiceResponse<Guid>
                {
                    Status = false,
                    Message = "Космический обьект не существует",
                    Data = new()    // подумать че вернуть
                };


            starSystemEntity.CenterOfGravityId = spaceObjectId;
            return new ServiceResponse<Guid>
            {
                Status = true,
                
                Data = new()
            };
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
                Weight = request.CenterOfGravityWeight
            };

            var spaceObjectServiceResponse = await _spaceObjectService.CreateAsync(spaceObjectCreateRequest);

            var s = await SetCenterOfGravity(entity.Id, spaceObjectServiceResponse.Data);
            if (!s.Status)
            {
                return new ServiceResponse<Guid>()
                {
                    Status = false,
                    Message = s.Message,
                    Data = Guid.Empty,
                };
            }




            return new ServiceResponse<Guid>()
            {
                Status = true,
                Data = entity.Id
            };
        }

        public async Task<ServiceResponse<string>> DeleteAsync(string name)
        {
            if(!_db.StarSystems.Any(s=>s.Name == name))
            {
                return new ServiceResponse<string>()
                {
                    Status = false,
                    Message = "Звездная система с таким именем не существует",
                    Data = name
                };
            }


            _db.StarSystems.Remove(new StarSystem() { Name = name });
            await _db.SaveChangesAsync(new CancellationToken());

            return new ServiceResponse<string>()
            {
                Status = true,
                Data = name
            };
        }

        public Task<ServiceResponse<StarSystemResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<StarSystemResponse>> GetByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<string>> UpdateAsync(StarSystemUpdateRequest starSystem)
        {
            if(!_db.StarSystems.Any(s=>s.Name == starSystem.Name))
            {
                return new ServiceResponse<string>()
                {
                    Status = false,
                    Message = "Звездная система с таким именем не существует",
                    Data = starSystem.Name
                };
            }

            var StarSystemEntity = _db.StarSystems.First(s=>s.Name == starSystem.Name);

            _db.Entry(StarSystemEntity).Collection(s => s.SpaceObjects).Query().Where(sobj => sobj.Id == StarSystemEntity.CenterOfGravityId).Load();

            StarSystemEntity.Name = starSystem.Name;
            StarSystemEntity.Age = starSystem.Age;

            await _db.SaveChangesAsync(new CancellationToken());

            return new ServiceResponse<string>()
            {
                Status = true,
                Data = StarSystemEntity.Name
            };
        }
    }
}
