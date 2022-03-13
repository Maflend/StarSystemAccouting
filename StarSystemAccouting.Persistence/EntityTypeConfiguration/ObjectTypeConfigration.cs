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
    public class ObjectTypeConfigration : IEntityTypeConfiguration<ObjectType>
    {
        public void Configure(EntityTypeBuilder<ObjectType> builder)
        {
            builder.HasKey(e => e.Name);
            builder.HasIndex(e => e.Name).IsUnique();

            builder.HasMany(e => e.SpaceObjects).WithOne(sobj => sobj.ObjectType).HasForeignKey(sobj => sobj.Type);
        }
    }
}
