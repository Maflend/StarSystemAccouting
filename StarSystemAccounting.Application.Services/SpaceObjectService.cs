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
                    Message = "Звездный обьект с таким именем уже существует",
                    Data = Guid.Empty
                };
            }
            SpaceObject spaceObject = new()
            {
                Name = request.Name,
                Age = request.Age,
                Diameter = request.Diameter,
               // Type = request.Type,
                Weight = request.Weight,
                StarSystemId = _db.StarSystems.FirstOrDefault(s=>s.Name == request.StarSystemName).Id
            };

            await _db.SpaceObjects.AddAsync(spaceObject);
            await _db.SaveChangesAsync();

            return new ServiceResponse<Guid>()
            {
                Status = true,
                Data = spaceObject.Id
            };
        }
    }
}
