using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoteBookAPI.Migrations
{
    public partial class helloworld1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreateBy",
                table: "SetRefTerms",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "SetRefTerms",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "SetRefTerms",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdateBy",
                table: "SetRefTerms",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreateBy",
                table: "RetTerms",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "RetTerms",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "RetTerms",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdateBy",
                table: "RetTerms",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CreateBy",
                table: "RefSets",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "RefSets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "RefSets",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdateBy",
                table: "RefSets",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("859a0577-76ad-49ef-a111-346e4f978a88"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 12, 17, 20, 40, 151, DateTimeKind.Local).AddTicks(9616));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 12, 17, 20, 40, 151, DateTimeKind.Local).AddTicks(9731));

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(2144));

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("d019119e-245b-45d2-93df-b4cbbdfeac9f"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(2093));

            migrationBuilder.UpdateData(
                table: "PhNumbers",
                keyColumn: "Id",
                keyValue: new Guid("00793011-a986-49f0-879b-86023edaff46"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(900));

            migrationBuilder.UpdateData(
                table: "PhNumbers",
                keyColumn: "Id",
                keyValue: new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(947));

            migrationBuilder.UpdateData(
                table: "RefSets",
                keyColumn: "Id",
                keyValue: new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7"),
                columns: new[] { "CreateBy", "DateCreated" },
                values: new object[] { new Guid("68417748-6864-4866-8d9b-b82ae29da396"), new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(5191) });

            migrationBuilder.UpdateData(
                table: "RefSets",
                keyColumn: "Id",
                keyValue: new Guid("1f1f245d-c63b-42f6-b592-49b5b16bf861"),
                columns: new[] { "CreateBy", "DateCreated" },
                values: new object[] { new Guid("68417748-6864-4866-8d9b-b82ae29da396"), new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(5230) });

            migrationBuilder.UpdateData(
                table: "RefSets",
                keyColumn: "Id",
                keyValue: new Guid("7b135772-658f-4bdf-a01c-cedba350cb41"),
                columns: new[] { "CreateBy", "DateCreated" },
                values: new object[] { new Guid("68417748-6864-4866-8d9b-b82ae29da396"), new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(5277) });

            migrationBuilder.UpdateData(
                table: "RefSets",
                keyColumn: "Id",
                keyValue: new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                columns: new[] { "CreateBy", "DateCreated" },
                values: new object[] { new Guid("68417748-6864-4866-8d9b-b82ae29da396"), new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(4938) });

            migrationBuilder.UpdateData(
                table: "RefSets",
                keyColumn: "Id",
                keyValue: new Guid("e7c0cab2-367b-4b60-805f-8b20cdadc599"),
                columns: new[] { "CreateBy", "DateCreated" },
                values: new object[] { new Guid("68417748-6864-4866-8d9b-b82ae29da396"), new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(5255) });

            migrationBuilder.UpdateData(
                table: "RetTerms",
                keyColumn: "Id",
                keyValue: new Guid("3bbd0a04-40d0-44fb-ba4d-c25d0926d7df"),
                columns: new[] { "CreateBy", "DateCreated" },
                values: new object[] { new Guid("68417748-6864-4866-8d9b-b82ae29da396"), new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(6713) });

            migrationBuilder.UpdateData(
                table: "RetTerms",
                keyColumn: "Id",
                keyValue: new Guid("66ce5b88-684d-4a82-96b6-d9c8bb751687"),
                columns: new[] { "CreateBy", "DateCreated" },
                values: new object[] { new Guid("68417748-6864-4866-8d9b-b82ae29da396"), new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(6985) });

            migrationBuilder.UpdateData(
                table: "RetTerms",
                keyColumn: "Id",
                keyValue: new Guid("a447a151-130e-46df-917b-d09976d2ebb5"),
                columns: new[] { "CreateBy", "DateCreated" },
                values: new object[] { new Guid("68417748-6864-4866-8d9b-b82ae29da396"), new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(6949) });

            migrationBuilder.UpdateData(
                table: "RetTerms",
                keyColumn: "Id",
                keyValue: new Guid("a673bec7-aae1-4cca-b459-fb5d5bbfe3e1"),
                columns: new[] { "CreateBy", "DateCreated" },
                values: new object[] { new Guid("68417748-6864-4866-8d9b-b82ae29da396"), new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(7041) });

            migrationBuilder.UpdateData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("0bd3c11f-c1c5-48f5-8ece-86cfeb5ede88"),
                columns: new[] { "CreateBy", "DateCreated" },
                values: new object[] { new Guid("68417748-6864-4866-8d9b-b82ae29da396"), new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(8838) });

            migrationBuilder.UpdateData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("173487fc-5809-4d64-8a2c-a23403127e30"),
                columns: new[] { "CreateBy", "DateCreated" },
                values: new object[] { new Guid("68417748-6864-4866-8d9b-b82ae29da396"), new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(8978) });

            migrationBuilder.UpdateData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("2aa77699-21f7-442a-8b0d-b6e3f6b9211d"),
                columns: new[] { "CreateBy", "DateCreated" },
                values: new object[] { new Guid("68417748-6864-4866-8d9b-b82ae29da396"), new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(8954) });

            migrationBuilder.UpdateData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("5d14d241-437e-4819-ab01-58563d95c73c"),
                columns: new[] { "CreateBy", "DateCreated" },
                values: new object[] { new Guid("68417748-6864-4866-8d9b-b82ae29da396"), new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(9001) });

            migrationBuilder.UpdateData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("7e9c9d23-7728-4808-975d-d07b42d8e039"),
                columns: new[] { "CreateBy", "DateCreated" },
                values: new object[] { new Guid("68417748-6864-4866-8d9b-b82ae29da396"), new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(8800) });

            migrationBuilder.UpdateData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("a0229113-f803-4403-ba10-b0698d0cbbbe"),
                columns: new[] { "CreateBy", "DateCreated" },
                values: new object[] { new Guid("68417748-6864-4866-8d9b-b82ae29da396"), new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(8925) });

            migrationBuilder.UpdateData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("a1c2cd8c-aae4-463d-b873-841c40f4bf86"),
                columns: new[] { "CreateBy", "DateCreated" },
                values: new object[] { new Guid("68417748-6864-4866-8d9b-b82ae29da396"), new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(8864) });

            migrationBuilder.UpdateData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("d1f520f4-976d-4ec7-a523-24985873a91b"),
                columns: new[] { "CreateBy", "DateCreated" },
                values: new object[] { new Guid("68417748-6864-4866-8d9b-b82ae29da396"), new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(9024) });

            migrationBuilder.UpdateData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("d2ffc955-b24b-411a-8cdb-26516bcfe3db"),
                columns: new[] { "CreateBy", "DateCreated" },
                values: new object[] { new Guid("68417748-6864-4866-8d9b-b82ae29da396"), new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(8568) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 12, 17, 20, 40, 150, DateTimeKind.Local).AddTicks(8214));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 12, 17, 20, 40, 150, DateTimeKind.Local).AddTicks(3342));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "SetRefTerms");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "SetRefTerms");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "SetRefTerms");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "SetRefTerms");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "RetTerms");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "RetTerms");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "RetTerms");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "RetTerms");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "RefSets");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "RefSets");

            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "RefSets");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "RefSets");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("859a0577-76ad-49ef-a111-346e4f978a88"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 12, 13, 53, 28, 343, DateTimeKind.Local).AddTicks(4272));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 12, 13, 53, 28, 343, DateTimeKind.Local).AddTicks(4394));

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 12, 13, 53, 28, 343, DateTimeKind.Local).AddTicks(7115));

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("d019119e-245b-45d2-93df-b4cbbdfeac9f"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 12, 13, 53, 28, 343, DateTimeKind.Local).AddTicks(7061));

            migrationBuilder.UpdateData(
                table: "PhNumbers",
                keyColumn: "Id",
                keyValue: new Guid("00793011-a986-49f0-879b-86023edaff46"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 12, 13, 53, 28, 343, DateTimeKind.Local).AddTicks(5871));

            migrationBuilder.UpdateData(
                table: "PhNumbers",
                keyColumn: "Id",
                keyValue: new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 12, 13, 53, 28, 343, DateTimeKind.Local).AddTicks(5914));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 12, 13, 53, 28, 341, DateTimeKind.Local).AddTicks(9642));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 12, 13, 53, 28, 341, DateTimeKind.Local).AddTicks(3858));
        }
    }
}
