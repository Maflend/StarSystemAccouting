using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarSystemAccouting.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSystemAccouting.Persistence.EntityTypeConfiguration
{
    public class SpaceObjectTypeConfigration : IEntityTypeConfiguration<SpaceObjectType>
    {
        public void Configure(EntityTypeBuilder<SpaceObjectType> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Name).IsUnique();

            builder.HasMany(e => e.SpaceObjects).WithOne(sobj => sobj.Type).HasForeignKey(sobj => sobj.TypeId);
        }
    }
}
