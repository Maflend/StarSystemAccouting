using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarSystemAccouting.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StarSystems",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<double>(type: "double precision", nullable: false),
                    CenterOfGravityName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarSystems", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "SpaceObjects",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<double>(type: "double precision", nullable: false),
                    Diameter = table.Column<double>(type: "double precision", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    StarSystemName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpaceObjects", x => x.Name);
                    table.ForeignKey(
                        name: "FK_SpaceObjects_StarSystems_StarSystemName",
                        column: x => x.StarSystemName,
                        principalTable: "StarSystems",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpaceObjects_Name",
                table: "SpaceObjects",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_SpaceObjects_StarSystemName",
                table: "SpaceObjects",
                column: "StarSystemName");

            migrationBuilder.CreateIndex(
                name: "IX_StarSystems_Name",
                table: "StarSystems",
                column: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpaceObjects");

            migrationBuilder.DropTable(
                name: "StarSystems");
        }
    }
}
