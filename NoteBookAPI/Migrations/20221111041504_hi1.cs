using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoteBookAPI.Migrations
{
    public partial class hi1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefSets_RetTerms_ReftermId",
                table: "RefSets");

            migrationBuilder.DropIndex(
                name: "IX_RefSets_ReftermId",
                table: "RefSets");

            migrationBuilder.DeleteData(
                table: "RetTerms",
                keyColumn: "ReftermId",
                keyValue: new Guid("7b135772-658f-4bdf-a01c-cedba350cb41"));

            migrationBuilder.DropColumn(
                name: "hi",
                table: "RetTerms");

            migrationBuilder.DropColumn(
                name: "ReftermId",
                table: "RefSets");

            migrationBuilder.InsertData(
                table: "RefSets",
                columns: new[] { "TypeId", "Description", "Name" },
                values: new object[] { new Guid("7b135772-658f-4bdf-a01c-cedba350cb41"), "Alternate number", "ALTERNATE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RefSets",
                keyColumn: "TypeId",
                keyValue: new Guid("7b135772-658f-4bdf-a01c-cedba350cb41"));

            migrationBuilder.AddColumn<string>(
                name: "hi",
                table: "RetTerms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ReftermId",
                table: "RefSets",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "RetTerms",
                columns: new[] { "ReftermId", "Description", "Types", "hi" },
                values: new object[] { new Guid("7b135772-658f-4bdf-a01c-cedba350cb41"), "Alternate number", "ALTERNATE", null });

            migrationBuilder.CreateIndex(
                name: "IX_RefSets_ReftermId",
                table: "RefSets",
                column: "ReftermId");

            migrationBuilder.AddForeignKey(
                name: "FK_RefSets_RetTerms_ReftermId",
                table: "RefSets",
                column: "ReftermId",
                principalTable: "RetTerms",
                principalColumn: "ReftermId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
