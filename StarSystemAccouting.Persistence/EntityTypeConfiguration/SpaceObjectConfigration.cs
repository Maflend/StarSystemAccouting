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
    internal class SpaceObjectConfigration : IEntityTypeConfiguration<SpaceObject>
    {
        public void Configure(EntityTypeBuilder<SpaceObject> builder)
        {

            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Id);
            builder.HasIndex(e => e.Name).IsUnique();

            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Type).IsRequired();
            builder.Property(e => e.Age).IsRequired();
            builder.Property(e => e.Diameter).IsRequired();
            builder.Property(e => e.Weight).IsRequired();
       
            



          

        }
    }
}
