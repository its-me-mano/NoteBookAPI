using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoteBookAPI.Migrations
{
    public partial class final2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "RefSets");

            migrationBuilder.DropColumn(
                name: "email",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "RefSets",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Emails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StateName",
                table: "Addresses",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("859a0577-76ad-49ef-a111-346e4f978a88"),
                columns: new[] { "DateCreated", "StateName" },
                values: new object[] { new DateTime(2023, 1, 9, 18, 55, 3, 356, DateTimeKind.Local).AddTicks(9908), "tamilnadu" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                columns: new[] { "DateCreated", "StateName" },
                values: new object[] { new DateTime(2023, 1, 9, 18, 55, 3, 357, DateTimeKind.Local).AddTicks(13), "tamilnadu" });

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                columns: new[] { "DateCreated", "EmailAddress" },
                values: new object[] { new DateTime(2023, 1, 9, 18, 55, 3, 357, DateTimeKind.Local).AddTicks(2499), "itsmemano@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("d019119e-245b-45d2-93df-b4cbbdfeac9f"),
                columns: new[] { "DateCreated", "EmailAddress" },
                values: new object[] { new DateTime(2023, 1, 9, 18, 55, 3, 357, DateTimeKind.Local).AddTicks(2404), "itsmemano123@gmail.com" });

            migrationBuilder.UpdateData(
                table: "PhNumbers",
                keyColumn: "Id",
                keyValue: new Guid("00793011-a986-49f0-879b-86023edaff46"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 9, 18, 55, 3, 357, DateTimeKind.Local).AddTicks(1213));

            migrationBuilder.UpdateData(
                table: "PhNumbers",
                keyColumn: "Id",
                keyValue: new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 9, 18, 55, 3, 357, DateTimeKind.Local).AddTicks(1260));

            migrationBuilder.UpdateData(
                table: "RefSets",
                keyColumn: "Id",
                keyValue: new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7"),
                column: "Key",
                value: "WORK");

            migrationBuilder.UpdateData(
                table: "RefSets",
                keyColumn: "Id",
                keyValue: new Guid("1f1f245d-c63b-42f6-b592-49b5b16bf861"),
                column: "Key",
                value: "INDIA");

            migrationBuilder.UpdateData(
                table: "RefSets",
                keyColumn: "Id",
                keyValue: new Guid("7b135772-658f-4bdf-a01c-cedba350cb41"),
                column: "Key",
                value: "ALTERNATE");

            migrationBuilder.UpdateData(
                table: "RefSets",
                keyColumn: "Id",
                keyValue: new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                column: "Key",
                value: "PERSONAL");

            migrationBuilder.UpdateData(
                table: "RefSets",
                keyColumn: "Id",
                keyValue: new Guid("e7c0cab2-367b-4b60-805f-8b20cdadc599"),
                column: "Key",
                value: "UNITED_STATES");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 9, 18, 55, 3, 355, DateTimeKind.Local).AddTicks(8798));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 9, 18, 55, 3, 355, DateTimeKind.Local).AddTicks(2646));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "RefSets");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Emails");

            migrationBuilder.DropColumn(
                name: "StateName",
                table: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "RefSets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Emails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("859a0577-76ad-49ef-a111-346e4f978a88"),
                columns: new[] { "DateCreated", "State" },
                values: new object[] { new DateTime(2023, 1, 9, 15, 52, 55, 132, DateTimeKind.Local).AddTicks(3800), "tamilnadu" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                columns: new[] { "DateCreated", "State" },
                values: new object[] { new DateTime(2023, 1, 9, 15, 52, 55, 132, DateTimeKind.Local).AddTicks(3890), "tamilnadu" });

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                columns: new[] { "DateCreated", "email" },
                values: new object[] { new DateTime(2023, 1, 9, 15, 52, 55, 132, DateTimeKind.Local).AddTicks(6470), "itsmemano@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("d019119e-245b-45d2-93df-b4cbbdfeac9f"),
                columns: new[] { "DateCreated", "email" },
                values: new object[] { new DateTime(2023, 1, 9, 15, 52, 55, 132, DateTimeKind.Local).AddTicks(6366), "itsmemano123@gmail.com" });

            migrationBuilder.UpdateData(
                table: "PhNumbers",
                keyColumn: "Id",
                keyValue: new Guid("00793011-a986-49f0-879b-86023edaff46"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 9, 15, 52, 55, 132, DateTimeKind.Local).AddTicks(5055));

            migrationBuilder.UpdateData(
                table: "PhNumbers",
                keyColumn: "Id",
                keyValue: new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 9, 15, 52, 55, 132, DateTimeKind.Local).AddTicks(5100));

            migrationBuilder.UpdateData(
                table: "RefSets",
                keyColumn: "Id",
                keyValue: new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7"),
                column: "Name",
                value: "WORK");

            migrationBuilder.UpdateData(
                table: "RefSets",
                keyColumn: "Id",
                keyValue: new Guid("1f1f245d-c63b-42f6-b592-49b5b16bf861"),
                column: "Name",
                value: "INDIA");

            migrationBuilder.UpdateData(
                table: "RefSets",
                keyColumn: "Id",
                keyValue: new Guid("7b135772-658f-4bdf-a01c-cedba350cb41"),
                column: "Name",
                value: "ALTERNATE");

            migrationBuilder.UpdateData(
                table: "RefSets",
                keyColumn: "Id",
                keyValue: new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                column: "Name",
                value: "PERSONAL");

            migrationBuilder.UpdateData(
                table: "RefSets",
                keyColumn: "Id",
                keyValue: new Guid("e7c0cab2-367b-4b60-805f-8b20cdadc599"),
                column: "Name",
                value: "UNITED_STATES");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 9, 15, 52, 55, 131, DateTimeKind.Local).AddTicks(2592));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 9, 15, 52, 55, 130, DateTimeKind.Local).AddTicks(7662));
        }
    }
}
