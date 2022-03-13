using Microsoft.EntityFrameworkCore;
using StarSystemAccouting.Application.DTOs;
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

        public StarSystemService(ApplicationContext db)
        {
            _db = db;
        }
        public async Task<ServiceResponse<StarSystemResponse>> CreateAsync(StarSystemCreateRequest request)
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

            StarSystem entity = new()
            {
                Name = request.Name,
                Age = request.Age,
                CenterOfGravityName = request.CenterOfGravity.Name
            };
            SpaceObject spaceObject = new()
            {
                Name = request.CenterOfGravity.Name,
                Age = request.CenterOfGravity.Age,
                Diameter = request.CenterOfGravity.Diameter,
                Type = request.CenterOfGravity.Type,
                Weight = request.CenterOfGravity.Weight,
                StarSystemId = entity.Id
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

            var entity = _db.StarSystems.First(s=>s.Name == starSystem.Name);

            _db.Entry(entity).Collection(s => s.SpaceObjects).Query().Where(sobj => sobj.Name == entity.CenterOfGravityName).Load();

            entity.Name = starSystem.Name;
            entity.Age = starSystem.Age;
            entity.CenterOfGravityName = starSystem.CenterOfGravity;
            entity.SpaceObjects.First().Name = starSystem.CenterOfGravity;
            await _db.SaveChangesAsync(new CancellationToken());

            return new ServiceResponse<string>()
            {
                Status = true,
                Data = entity.Name
            };
        }
    }
}
