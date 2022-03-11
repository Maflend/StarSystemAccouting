using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StarSystemAccouting.Persistence.Migrations
{
    public partial class AddGuidKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpaceObjects_StarSystems_StarSystemName",
                table: "SpaceObjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StarSystems",
                table: "StarSystems");

            migrationBuilder.DropIndex(
                name: "IX_StarSystems_Name",
                table: "StarSystems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpaceObjects",
                table: "SpaceObjects");

            migrationBuilder.DropIndex(
                name: "IX_SpaceObjects_Name",
                table: "SpaceObjects");

            migrationBuilder.DropIndex(
                name: "IX_SpaceObjects_StarSystemName",
                table: "SpaceObjects");

            migrationBuilder.DropColumn(
                name: "StarSystemName",
                table: "SpaceObjects");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "StarSystems",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "SpaceObjects",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StarSystemId",
                table: "SpaceObjects",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_StarSystems",
                table: "StarSystems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpaceObjects",
                table: "SpaceObjects",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StarSystems_Id",
                table: "StarSystems",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StarSystems_Name",
                table: "StarSystems",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpaceObjects_Id",
                table: "SpaceObjects",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SpaceObjects_Name",
                table: "SpaceObjects",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpaceObjects_StarSystemId",
                table: "SpaceObjects",
                column: "StarSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpaceObjects_StarSystems_StarSystemId",
                table: "SpaceObjects",
                column: "StarSystemId",
                principalTable: "StarSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpaceObjects_StarSystems_StarSystemId",
                table: "SpaceObjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StarSystems",
                table: "StarSystems");

            migrationBuilder.DropIndex(
                name: "IX_StarSystems_Id",
                table: "StarSystems");

            migrationBuilder.DropIndex(
                name: "IX_StarSystems_Name",
                table: "StarSystems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SpaceObjects",
                table: "SpaceObjects");

            migrationBuilder.DropIndex(
                name: "IX_SpaceObjects_Id",
                table: "SpaceObjects");

            migrationBuilder.DropIndex(
                name: "IX_SpaceObjects_Name",
                table: "SpaceObjects");

            migrationBuilder.DropIndex(
                name: "IX_SpaceObjects_StarSystemId",
                table: "SpaceObjects");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StarSystems");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SpaceObjects");

            migrationBuilder.DropColumn(
                name: "StarSystemId",
                table: "SpaceObjects");

            migrationBuilder.AddColumn<string>(
                name: "StarSystemName",
                table: "SpaceObjects",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StarSystems",
                table: "StarSystems",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpaceObjects",
                table: "SpaceObjects",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_StarSystems_Name",
                table: "StarSystems",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_SpaceObjects_Name",
                table: "SpaceObjects",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_SpaceObjects_StarSystemName",
                table: "SpaceObjects",
                column: "StarSystemName");

            migrationBuilder.AddForeignKey(
                name: "FK_SpaceObjects_StarSystems_StarSystemName",
                table: "SpaceObjects",
                column: "StarSystemName",
                principalTable: "StarSystems",
                principalColumn: "Name",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
