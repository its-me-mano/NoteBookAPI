using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoteBookAPI.Migrations
{
    public partial class helo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssetDtos",
                columns: table => new
                {
                    fieldId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetDtos", x => x.fieldId);
                    table.ForeignKey(
                        name: "FK_AssetDtos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImageStores",
                columns: table => new
                {
                    FileId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    File = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageStores", x => x.FileId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssetDtos_UserId",
                table: "AssetDtos",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssetDtos");

            migrationBuilder.DropTable(
                name: "ImageStores");
        }
    }
}
