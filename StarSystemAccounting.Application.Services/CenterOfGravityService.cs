using Microsoft.EntityFrameworkCore;
using StarSystemAccouting.Application.DTOs;
using StarSystemAccouting.Application.Services.Abstractions;
using StarSystemAccouting.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemAccouting.Application.Services
{
    public class CenterOfGravityService : ICenterOfGravityService
    {
        private readonly ApplicationContext _db;

        public CenterOfGravityService(ApplicationContext db)
        {
            _db = db;
        }
        public async Task<ServiceResponse<Guid>> SetAsync(Guid starSystemId, Guid spaceObjectId)
        {
            var starSystemEntity = await _db.StarSystems.Include(s=>s.SpaceObjects).FirstAsync(s => s.Id == starSystemId);
            if (starSystemEntity == null)
                return new ServiceResponse<Guid>
                {
                    Status = false,
                    Message = "Звездная система не существует",
                    Data = new()
                };


            var spaceObject =  starSystemEntity.SpaceObjects.FirstOrDefault(sobj => sobj.Id == spaceObjectId);

            if (spaceObject == null)
                return new ServiceResponse<Guid>
                {
                    Status = false,
                    Message = "Космический обьект в заданной звездной системе не существует",
                    Data = new()
                };

            if (spaceObject.Type != "Звезда" && spaceObject.Type != "Черная дыра")
                return new ServiceResponse<Guid>
                {
                    Status = false,
                    Message = "Тип космического обьекта должен быть Звезда / Черная дыра",
                    Data = new()
                };

            starSystemEntity.CenterOfGravityId = spaceObjectId;

            await _db.SaveChangesAsync();

            return new ServiceResponse<Guid>
            {
                Status = true,

                Data = spaceObjectId
            };
        }
    }
}
