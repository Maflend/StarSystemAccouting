// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StarSystemAccouting.Persistence;

#nullable disable

namespace StarSystemAccouting.Persistence.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220310162439_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("StarSystemAccouting.Domain.SpaceObject", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("Age")
                        .HasColumnType("double precision");

                    b.Property<double>("Diameter")
                        .HasColumnType("double precision");

                    b.Property<string>("StarSystemName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("Name");

                    b.HasIndex("Name");

                    b.HasIndex("StarSystemName");

                    b.ToTable("SpaceObjects");
                });

            modelBuilder.Entity("StarSystemAccouting.Domain.StarSystem", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("Age")
                        .HasColumnType("double precision");

                    b.Property<string>("CenterOfGravityName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Name");

                    b.HasIndex("Name");

                    b.ToTable("StarSystems");
                });

            modelBuilder.Entity("StarSystemAccouting.Domain.SpaceObject", b =>
                {
                    b.HasOne("StarSystemAccouting.Domain.StarSystem", "StarSystem")
                        .WithMany("SpaceObjects")
                        .HasForeignKey("StarSystemName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StarSystem");
                });

            modelBuilder.Entity("StarSystemAccouting.Domain.StarSystem", b =>
                {
                    b.Navigation("SpaceObjects");
                });
#pragma warning restore 612, 618
        }
    }
}
