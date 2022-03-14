using Microsoft.EntityFrameworkCore;
using StarSystemAccouting.Application.DTOs;
using StarSystemAccouting.Application.DTOs.Request.SpaceObject;
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
    public class SpaceObjectService : ISpaceObjectService
    {
        private readonly ApplicationContext _db;

        public SpaceObjectService(ApplicationContext db)
        {
            _db = db;
        }


        public async Task<ServiceResponse<SpaceObjectResponse>> GetById(Guid id)
        {
            var spaceObjectEntity = await _db.SpaceObjects.FirstOrDefaultAsync(sobj => sobj.Id == id);
            if (spaceObjectEntity == null)
                return new ServiceResponse<SpaceObjectResponse>()
                {
                    Status = false,
                    Message = "Космический обьект не найден",
                    Data = new()
                };


            SpaceObjectResponse response = new()
            {
                Id = spaceObjectEntity.Id,
                Name = spaceObjectEntity.Name,
                Age = spaceObjectEntity.Age,
                Diameter = spaceObjectEntity.Diameter,
                Type = spaceObjectEntity.Type,
                Weight = spaceObjectEntity.Weight,
                StarSystemId = spaceObjectEntity.StarSystemId
            };


            return new ServiceResponse<SpaceObjectResponse>()
            {
                Status = true,
                Data = response
            };
        }

        public async Task<ServiceResponse<Guid>> CreateAsync(SpaceObjectCreateRequest request)
        {
            
            if (_db.SpaceObjects.Any(s => s.Name == request.Name))
            {
                return new ServiceResponse<Guid>()
                {
                    Status = false,
                    Message = "Космический обьект с таким именем уже существует",
                    Data = Guid.Empty
                };
            }
            if (!_db.ObjectType.Any(t => t.Name == request.Type))
            {
                return new ServiceResponse<Guid>()
                {
                    Status = false,
                    Message = "Неверный тип космического обьекта",
                    Data = Guid.Empty
                };
            }
            SpaceObject spaceObject = new()
            {
                Name = request.Name,
                Age = request.Age,
                Diameter = request.Diameter,
                Type = request.Type,
                Weight = request.Weight
                
            };

            var starSystem = await _db.StarSystems.FirstOrDefaultAsync(s => s.Id == request.StarSystemId);
            if (starSystem == null)
                return new ServiceResponse<Guid>()
                {
                    Status = false,
                    Message = "Не удалось найти звездную систему",
                    Data = Guid.Empty
                };

            spaceObject.StarSystemId = starSystem.Id;

           
            await _db.SpaceObjects.AddAsync(spaceObject);
            try
            {
                await _db.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return new ServiceResponse<Guid>()
                {
                    Status = false,
                    Message = ex.Message
                };
            }

            return new ServiceResponse<Guid>()
            {
                Status = true,
                Data = spaceObject.Id
            };
        }

     
    }
}
