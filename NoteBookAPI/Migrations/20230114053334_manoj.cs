﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoteBookAPI.Migrations
{
    public partial class manoj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("859a0577-76ad-49ef-a111-346e4f978a88"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 11, 3, 34, 388, DateTimeKind.Local).AddTicks(363));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 11, 3, 34, 388, DateTimeKind.Local).AddTicks(455));

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 11, 3, 34, 388, DateTimeKind.Local).AddTicks(2850));

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("d019119e-245b-45d2-93df-b4cbbdfeac9f"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 11, 3, 34, 388, DateTimeKind.Local).AddTicks(2797));

            migrationBuilder.UpdateData(
                table: "PhNumbers",
                keyColumn: "Id",
                keyValue: new Guid("00793011-a986-49f0-879b-86023edaff46"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 11, 3, 34, 388, DateTimeKind.Local).AddTicks(1625));

            migrationBuilder.UpdateData(
                table: "PhNumbers",
                keyColumn: "Id",
                keyValue: new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 11, 3, 34, 388, DateTimeKind.Local).AddTicks(1670));

            migrationBuilder.UpdateData(
                table: "RefSets",
                keyColumn: "Id",
                keyValue: new Guid("3bbd0a04-40d0-44fb-ba4d-c25d0926d7df"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 11, 3, 34, 388, DateTimeKind.Local).AddTicks(5742));

            migrationBuilder.UpdateData(
                table: "RefSets",
                keyColumn: "Id",
                keyValue: new Guid("66ce5b88-684d-4a82-96b6-d9c8bb751687"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 11, 3, 34, 388, DateTimeKind.Local).AddTicks(6086));

            migrationBuilder.UpdateData(
                table: "RefSets",
                keyColumn: "Id",
                keyValue: new Guid("a447a151-130e-46df-917b-d09976d2ebb5"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 11, 3, 34, 388, DateTimeKind.Local).AddTicks(6045));

            migrationBuilder.UpdateData(
                table: "RefSets",
                keyColumn: "Id",
                keyValue: new Guid("a673bec7-aae1-4cca-b459-fb5d5bbfe3e1"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 11, 3, 34, 388, DateTimeKind.Local).AddTicks(6114));

            migrationBuilder.UpdateData(
                table: "RefTerms",
                keyColumn: "Id",
                keyValue: new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 11, 3, 34, 388, DateTimeKind.Local).AddTicks(7799));

            migrationBuilder.UpdateData(
                table: "RefTerms",
                keyColumn: "Id",
                keyValue: new Guid("1f1f245d-c63b-42f6-b592-49b5b16bf861"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 11, 3, 34, 388, DateTimeKind.Local).AddTicks(7833));

            migrationBuilder.UpdateData(
                table: "RefTerms",
                keyColumn: "Id",
                keyValue: new Guid("7b135772-658f-4bdf-a01c-cedba350cb41"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 11, 3, 34, 388, DateTimeKind.Local).AddTicks(7875));

            migrationBuilder.UpdateData(
                table: "RefTerms",
                keyColumn: "Id",
                keyValue: new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 11, 3, 34, 388, DateTimeKind.Local).AddTicks(7572));

            migrationBuilder.UpdateData(
                table: "RefTerms",
                keyColumn: "Id",
                keyValue: new Guid("e7c0cab2-367b-4b60-805f-8b20cdadc599"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 11, 3, 34, 388, DateTimeKind.Local).AddTicks(7855));

            migrationBuilder.UpdateData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("0bd3c11f-c1c5-48f5-8ece-86cfeb5ede88"),
                columns: new[] { "DateCreated", "RefSetid", "ReftermId" },
                values: new object[] { new DateTime(2023, 1, 14, 11, 3, 34, 388, DateTimeKind.Local).AddTicks(9840), new Guid("a447a151-130e-46df-917b-d09976d2ebb5"), new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc") });

            migrationBuilder.UpdateData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("173487fc-5809-4d64-8a2c-a23403127e30"),
                columns: new[] { "DateCreated", "RefSetid", "ReftermId" },
                values: new object[] { new DateTime(2023, 1, 14, 11, 3, 34, 388, DateTimeKind.Local).AddTicks(9937), new Guid("66ce5b88-684d-4a82-96b6-d9c8bb751687"), new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7") });

            migrationBuilder.UpdateData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("2aa77699-21f7-442a-8b0d-b6e3f6b9211d"),
                columns: new[] { "DateCreated", "RefSetid", "ReftermId" },
                values: new object[] { new DateTime(2023, 1, 14, 11, 3, 34, 388, DateTimeKind.Local).AddTicks(9915), new Guid("66ce5b88-684d-4a82-96b6-d9c8bb751687"), new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc") });

            migrationBuilder.UpdateData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("5d14d241-437e-4819-ab01-58563d95c73c"),
                columns: new[] { "DateCreated", "RefSetid", "ReftermId" },
                values: new object[] { new DateTime(2023, 1, 14, 11, 3, 34, 388, DateTimeKind.Local).AddTicks(9959), new Guid("a673bec7-aae1-4cca-b459-fb5d5bbfe3e1"), new Guid("1f1f245d-c63b-42f6-b592-49b5b16bf861") });

            migrationBuilder.UpdateData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("7e9c9d23-7728-4808-975d-d07b42d8e039"),
                columns: new[] { "DateCreated", "RefSetid", "ReftermId" },
                values: new object[] { new DateTime(2023, 1, 14, 11, 3, 34, 388, DateTimeKind.Local).AddTicks(9765), new Guid("3bbd0a04-40d0-44fb-ba4d-c25d0926d7df"), new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7") });

            migrationBuilder.UpdateData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("a0229113-f803-4403-ba10-b0698d0cbbbe"),
                columns: new[] { "DateCreated", "RefSetid", "ReftermId" },
                values: new object[] { new DateTime(2023, 1, 14, 11, 3, 34, 388, DateTimeKind.Local).AddTicks(9890), new Guid("a447a151-130e-46df-917b-d09976d2ebb5"), new Guid("7b135772-658f-4bdf-a01c-cedba350cb41") });

            migrationBuilder.UpdateData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("a1c2cd8c-aae4-463d-b873-841c40f4bf86"),
                columns: new[] { "DateCreated", "RefSetid", "ReftermId" },
                values: new object[] { new DateTime(2023, 1, 14, 11, 3, 34, 388, DateTimeKind.Local).AddTicks(9867), new Guid("a447a151-130e-46df-917b-d09976d2ebb5"), new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7") });

            migrationBuilder.UpdateData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("d1f520f4-976d-4ec7-a523-24985873a91b"),
                columns: new[] { "DateCreated", "RefSetid", "ReftermId" },
                values: new object[] { new DateTime(2023, 1, 14, 11, 3, 34, 388, DateTimeKind.Local).AddTicks(9981), new Guid("a673bec7-aae1-4cca-b459-fb5d5bbfe3e1"), new Guid("e7c0cab2-367b-4b60-805f-8b20cdadc599") });

            migrationBuilder.UpdateData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("d2ffc955-b24b-411a-8cdb-26516bcfe3db"),
                columns: new[] { "DateCreated", "RefSetid", "ReftermId" },
                values: new object[] { new DateTime(2023, 1, 14, 11, 3, 34, 388, DateTimeKind.Local).AddTicks(9535), new Guid("3bbd0a04-40d0-44fb-ba4d-c25d0926d7df"), new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 11, 3, 34, 386, DateTimeKind.Local).AddTicks(8564));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 11, 3, 34, 386, DateTimeKind.Local).AddTicks(3606));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("859a0577-76ad-49ef-a111-346e4f978a88"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 10, 57, 2, 936, DateTimeKind.Local).AddTicks(4510));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 10, 57, 2, 936, DateTimeKind.Local).AddTicks(4608));

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 10, 57, 2, 936, DateTimeKind.Local).AddTicks(6961));

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("d019119e-245b-45d2-93df-b4cbbdfeac9f"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 10, 57, 2, 936, DateTimeKind.Local).AddTicks(6910));

            migrationBuilder.UpdateData(
                table: "PhNumbers",
                keyColumn: "Id",
                keyValue: new Guid("00793011-a986-49f0-879b-86023edaff46"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 10, 57, 2, 936, DateTimeKind.Local).AddTicks(5773));

            migrationBuilder.UpdateData(
                table: "PhNumbers",
                keyColumn: "Id",
                keyValue: new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 10, 57, 2, 936, DateTimeKind.Local).AddTicks(5816));

            migrationBuilder.UpdateData(
                table: "RefSets",
                keyColumn: "Id",
                keyValue: new Guid("3bbd0a04-40d0-44fb-ba4d-c25d0926d7df"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 10, 57, 2, 936, DateTimeKind.Local).AddTicks(9622));

            migrationBuilder.UpdateData(
                table: "RefSets",
                keyColumn: "Id",
                keyValue: new Guid("66ce5b88-684d-4a82-96b6-d9c8bb751687"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 10, 57, 2, 936, DateTimeKind.Local).AddTicks(9901));

            migrationBuilder.UpdateData(
                table: "RefSets",
                keyColumn: "Id",
                keyValue: new Guid("a447a151-130e-46df-917b-d09976d2ebb5"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 10, 57, 2, 936, DateTimeKind.Local).AddTicks(9862));

            migrationBuilder.UpdateData(
                table: "RefSets",
                keyColumn: "Id",
                keyValue: new Guid("a673bec7-aae1-4cca-b459-fb5d5bbfe3e1"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 10, 57, 2, 936, DateTimeKind.Local).AddTicks(9924));

            migrationBuilder.UpdateData(
                table: "RefTerms",
                keyColumn: "Id",
                keyValue: new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 10, 57, 2, 937, DateTimeKind.Local).AddTicks(1619));

            migrationBuilder.UpdateData(
                table: "RefTerms",
                keyColumn: "Id",
                keyValue: new Guid("1f1f245d-c63b-42f6-b592-49b5b16bf861"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 10, 57, 2, 937, DateTimeKind.Local).AddTicks(1653));

            migrationBuilder.UpdateData(
                table: "RefTerms",
                keyColumn: "Id",
                keyValue: new Guid("7b135772-658f-4bdf-a01c-cedba350cb41"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 10, 57, 2, 937, DateTimeKind.Local).AddTicks(1693));

            migrationBuilder.UpdateData(
                table: "RefTerms",
                keyColumn: "Id",
                keyValue: new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 10, 57, 2, 937, DateTimeKind.Local).AddTicks(1404));

            migrationBuilder.UpdateData(
                table: "RefTerms",
                keyColumn: "Id",
                keyValue: new Guid("e7c0cab2-367b-4b60-805f-8b20cdadc599"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 10, 57, 2, 937, DateTimeKind.Local).AddTicks(1674));

            migrationBuilder.UpdateData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("0bd3c11f-c1c5-48f5-8ece-86cfeb5ede88"),
                columns: new[] { "DateCreated", "RefSetid", "ReftermId" },
                values: new object[] { new DateTime(2023, 1, 14, 10, 57, 2, 937, DateTimeKind.Local).AddTicks(3514), new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"), new Guid("a447a151-130e-46df-917b-d09976d2ebb5") });

            migrationBuilder.UpdateData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("173487fc-5809-4d64-8a2c-a23403127e30"),
                columns: new[] { "DateCreated", "RefSetid", "ReftermId" },
                values: new object[] { new DateTime(2023, 1, 14, 10, 57, 2, 937, DateTimeKind.Local).AddTicks(3607), new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7"), new Guid("66ce5b88-684d-4a82-96b6-d9c8bb751687") });

            migrationBuilder.UpdateData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("2aa77699-21f7-442a-8b0d-b6e3f6b9211d"),
                columns: new[] { "DateCreated", "RefSetid", "ReftermId" },
                values: new object[] { new DateTime(2023, 1, 14, 10, 57, 2, 937, DateTimeKind.Local).AddTicks(3585), new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"), new Guid("66ce5b88-684d-4a82-96b6-d9c8bb751687") });

            migrationBuilder.UpdateData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("5d14d241-437e-4819-ab01-58563d95c73c"),
                columns: new[] { "DateCreated", "RefSetid", "ReftermId" },
                values: new object[] { new DateTime(2023, 1, 14, 10, 57, 2, 937, DateTimeKind.Local).AddTicks(3664), new Guid("1f1f245d-c63b-42f6-b592-49b5b16bf861"), new Guid("a673bec7-aae1-4cca-b459-fb5d5bbfe3e1") });

            migrationBuilder.UpdateData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("7e9c9d23-7728-4808-975d-d07b42d8e039"),
                columns: new[] { "DateCreated", "RefSetid", "ReftermId" },
                values: new object[] { new DateTime(2023, 1, 14, 10, 57, 2, 937, DateTimeKind.Local).AddTicks(3478), new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7"), new Guid("3bbd0a04-40d0-44fb-ba4d-c25d0926d7df") });

            migrationBuilder.UpdateData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("a0229113-f803-4403-ba10-b0698d0cbbbe"),
                columns: new[] { "DateCreated", "RefSetid", "ReftermId" },
                values: new object[] { new DateTime(2023, 1, 14, 10, 57, 2, 937, DateTimeKind.Local).AddTicks(3559), new Guid("7b135772-658f-4bdf-a01c-cedba350cb41"), new Guid("a447a151-130e-46df-917b-d09976d2ebb5") });

            migrationBuilder.UpdateData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("a1c2cd8c-aae4-463d-b873-841c40f4bf86"),
                columns: new[] { "DateCreated", "RefSetid", "ReftermId" },
                values: new object[] { new DateTime(2023, 1, 14, 10, 57, 2, 937, DateTimeKind.Local).AddTicks(3538), new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7"), new Guid("a447a151-130e-46df-917b-d09976d2ebb5") });

            migrationBuilder.UpdateData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("d1f520f4-976d-4ec7-a523-24985873a91b"),
                columns: new[] { "DateCreated", "RefSetid", "ReftermId" },
                values: new object[] { new DateTime(2023, 1, 14, 10, 57, 2, 937, DateTimeKind.Local).AddTicks(3690), new Guid("e7c0cab2-367b-4b60-805f-8b20cdadc599"), new Guid("a673bec7-aae1-4cca-b459-fb5d5bbfe3e1") });

            migrationBuilder.UpdateData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("d2ffc955-b24b-411a-8cdb-26516bcfe3db"),
                columns: new[] { "DateCreated", "RefSetid", "ReftermId" },
                values: new object[] { new DateTime(2023, 1, 14, 10, 57, 2, 937, DateTimeKind.Local).AddTicks(3253), new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"), new Guid("3bbd0a04-40d0-44fb-ba4d-c25d0926d7df") });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 10, 57, 2, 935, DateTimeKind.Local).AddTicks(3480));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 14, 10, 57, 2, 934, DateTimeKind.Local).AddTicks(8255));
        }
    }
}
