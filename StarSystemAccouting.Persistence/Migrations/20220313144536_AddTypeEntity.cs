using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarSystemAccouting.Persistence.Migrations
{
    public partial class AddTypeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ObjectType",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectType", x => x.Name);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpaceObjects_Type",
                table: "SpaceObjects",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectType_Name",
                table: "ObjectType",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SpaceObjects_ObjectType_Type",
                table: "SpaceObjects",
                column: "Type",
                principalTable: "ObjectType",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpaceObjects_ObjectType_Type",
                table: "SpaceObjects");

            migrationBuilder.DropTable(
                name: "ObjectType");

            migrationBuilder.DropIndex(
                name: "IX_SpaceObjects_Type",
                table: "SpaceObjects");
        }
    }
}
