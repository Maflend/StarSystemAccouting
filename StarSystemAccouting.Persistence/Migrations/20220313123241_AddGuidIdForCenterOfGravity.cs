using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarSystemAccouting.Persistence.Migrations
{
    public partial class AddGuidIdForCenterOfGravity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CenterOfGravityName",
                table: "StarSystems");

            migrationBuilder.AddColumn<Guid>(
                name: "CenterOfGravityId",
                table: "StarSystems",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CenterOfGravityId",
                table: "StarSystems");

            migrationBuilder.AddColumn<string>(
                name: "CenterOfGravityName",
                table: "StarSystems",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
