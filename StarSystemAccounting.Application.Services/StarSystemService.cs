using StarSystemAccouting.Application.DTOs;
using StarSystemAccouting.Application.DTOs.Request;
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
        private readonly IAppContext _db;

        public StarSystemService(IAppContext db)
        {
            _db = db;
        }
        public async Task<ServiceResponse<StarSystemResponse>> CreateAsync(StarSystemRequest request)
        {
            if (_db.StarSystems.Any(s => s.Name == request.Name))
            {
                return new ServiceResponse<StarSystemResponse>()
                {
                    Status = false,
                    Message = "Звездная система с таким именем уже существует",
                    Data = new(),
                };
            }

            SpaceObject spaceObject = new()
            {
                Name = request.CenterOfGravity.Name,
                Age = request.CenterOfGravity.Age,
                Diameter = request.CenterOfGravity.Diameter,
                Type = request.CenterOfGravity.Type,
                Weight = request.CenterOfGravity.Weight,
                StarSystemName = request.CenterOfGravity.StarSystemName
            };

            StarSystem entity = new()
            {
                Name = request.Name,
                Age = request.Age,
                CenterOfGravityName = request.CenterOfGravity.Name,
            };

            await _db.StarSystems.AddAsync(entity);
            await _db.SpaceObjects.AddAsync(spaceObject);
            await _db.SaveChangesAsync(new CancellationToken());

            StarSystemResponse response = new()
            {
                Name = entity.Name,
                Age = entity.Age,
                CenterOfGravityName = entity.CenterOfGravityName
            };


            return new ServiceResponse<StarSystemResponse>()
            {
                Status = true,
                Data = response
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

        public Task<ServiceResponse<string>> UpdateAsync(StarSystemRequest starSystem)
        {
            throw new NotImplementedException();
        }
    }
}
