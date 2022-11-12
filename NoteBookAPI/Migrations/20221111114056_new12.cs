using Microsoft.EntityFrameworkCore.Migrations;

namespace NoteBookAPI.Migrations
{
    public partial class new12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssetDtos_Users_UserId",
                table: "AssetDtos");

            migrationBuilder.DropIndex(
                name: "IX_AssetDtos_UserId",
                table: "AssetDtos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AssetDtos_UserId",
                table: "AssetDtos",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssetDtos_Users_UserId",
                table: "AssetDtos",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
