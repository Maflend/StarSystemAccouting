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

    
            await _db.SpaceObjects.AddAsync(spaceObject);

            var starSystem = await _db.StarSystems.FirstAsync(s => s.Id == request.StarSystemId);
            spaceObject.StarSystemId = starSystem.Id;



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
