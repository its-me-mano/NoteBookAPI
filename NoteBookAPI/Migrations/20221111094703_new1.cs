using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoteBookAPI.Migrations
{
    public partial class new1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetDtos",
                table: "AssetDtos");

            migrationBuilder.DropColumn(
                name: "PhNo",
                table: "PhNumbers");

            migrationBuilder.DropColumn(
                name: "CountryType",
                table: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "PhNumbers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AssetId",
                table: "AssetDtos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Country",
                table: "Addresses",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetDtos",
                table: "AssetDtos",
                column: "AssetId");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("859a0577-76ad-49ef-a111-346e4f978a88"),
                column: "Country",
                value: new Guid("1f1f245d-c63b-42f6-b592-49b5b16bf861"));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                column: "Country",
                value: new Guid("1f1f245d-c63b-42f6-b592-49b5b16bf861"));

            migrationBuilder.UpdateData(
                table: "PhNumbers",
                keyColumn: "PhId",
                keyValue: new Guid("00793011-a986-49f0-879b-86023edaff46"),
                column: "PhoneNumber",
                value: "8925250061");

            migrationBuilder.UpdateData(
                table: "PhNumbers",
                keyColumn: "PhId",
                keyValue: new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                column: "PhoneNumber",
                value: "9488977667");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetDtos",
                table: "AssetDtos");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "PhNumbers");

            migrationBuilder.DropColumn(
                name: "AssetId",
                table: "AssetDtos");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "PhNo",
                table: "PhNumbers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryType",
                table: "Addresses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetDtos",
                table: "AssetDtos",
                column: "fieldId");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("859a0577-76ad-49ef-a111-346e4f978a88"),
                column: "CountryType",
                value: new Guid("1f1f245d-c63b-42f6-b592-49b5b16bf861"));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                column: "CountryType",
                value: new Guid("1f1f245d-c63b-42f6-b592-49b5b16bf861"));

            migrationBuilder.UpdateData(
                table: "PhNumbers",
                keyColumn: "PhId",
                keyValue: new Guid("00793011-a986-49f0-879b-86023edaff46"),
                column: "PhNo",
                value: "8925250061");

            migrationBuilder.UpdateData(
                table: "PhNumbers",
                keyColumn: "PhId",
                keyValue: new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                column: "PhNo",
                value: "9488977667");
        }
    }
}
