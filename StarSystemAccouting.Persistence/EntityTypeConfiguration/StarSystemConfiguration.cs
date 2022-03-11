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
    internal class StarSystemConfiguration : IEntityTypeConfiguration<StarSystem>
    {
        public void Configure(EntityTypeBuilder<StarSystem> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasIndex(e => e.Id);
            builder.HasIndex(e => e.Name).IsUnique();

            builder.Property(e => e.Name).IsRequired();
            builder.Property(e => e.Age).IsRequired();
            builder.Property(e => e.CenterOfGravityName).IsRequired();


            builder.HasMany(e => e.SpaceObjects).WithOne(s => s.StarSystem).HasForeignKey(e => e.StarSystemName);
            
        }
    }
}
