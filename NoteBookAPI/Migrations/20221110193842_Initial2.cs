using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoteBookAPI.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ReftermId",
                table: "RefSets",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefSets_RetTerms_ReftermId",
                table: "RefSets");

            migrationBuilder.DropIndex(
                name: "IX_RefSets_ReftermId",
                table: "RefSets");

            migrationBuilder.DropColumn(
                name: "ReftermId",
                table: "RefSets");
        }
    }
}
