using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoteBookAPI.Migrations
{
    public partial class helloworld : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SetRefTerms",
                table: "SetRefTerms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RetTerms",
                table: "RetTerms");

            migrationBuilder.DeleteData(
                table: "RetTerms",
                keyColumn: "ReftermId",
                keyValue: new Guid("3bbd0a04-40d0-44fb-ba4d-c25d0926d7df"));

            migrationBuilder.DeleteData(
                table: "RetTerms",
                keyColumn: "ReftermId",
                keyValue: new Guid("66ce5b88-684d-4a82-96b6-d9c8bb751687"));

            migrationBuilder.DeleteData(
                table: "RetTerms",
                keyColumn: "ReftermId",
                keyValue: new Guid("a447a151-130e-46df-917b-d09976d2ebb5"));

            migrationBuilder.DeleteData(
                table: "RetTerms",
                keyColumn: "ReftermId",
                keyValue: new Guid("a673bec7-aae1-4cca-b459-fb5d5bbfe3e1"));

            migrationBuilder.DeleteData(
                table: "SetRefTerms",
                keyColumn: "SetRefTermId",
                keyValue: new Guid("0bd3c11f-c1c5-48f5-8ece-86cfeb5ede88"));

            migrationBuilder.DeleteData(
                table: "SetRefTerms",
                keyColumn: "SetRefTermId",
                keyValue: new Guid("173487fc-5809-4d64-8a2c-a23403127e30"));

            migrationBuilder.DeleteData(
                table: "SetRefTerms",
                keyColumn: "SetRefTermId",
                keyValue: new Guid("2aa77699-21f7-442a-8b0d-b6e3f6b9211d"));

            migrationBuilder.DeleteData(
                table: "SetRefTerms",
                keyColumn: "SetRefTermId",
                keyValue: new Guid("5d14d241-437e-4819-ab01-58563d95c73c"));

            migrationBuilder.DeleteData(
                table: "SetRefTerms",
                keyColumn: "SetRefTermId",
                keyValue: new Guid("7e9c9d23-7728-4808-975d-d07b42d8e039"));

            migrationBuilder.DeleteData(
                table: "SetRefTerms",
                keyColumn: "SetRefTermId",
                keyValue: new Guid("a0229113-f803-4403-ba10-b0698d0cbbbe"));

            migrationBuilder.DeleteData(
                table: "SetRefTerms",
                keyColumn: "SetRefTermId",
                keyValue: new Guid("a1c2cd8c-aae4-463d-b873-841c40f4bf86"));

            migrationBuilder.DeleteData(
                table: "SetRefTerms",
                keyColumn: "SetRefTermId",
                keyValue: new Guid("d1f520f4-976d-4ec7-a523-24985873a91b"));

            migrationBuilder.DeleteData(
                table: "SetRefTerms",
                keyColumn: "SetRefTermId",
                keyValue: new Guid("d2ffc955-b24b-411a-8cdb-26516bcfe3db"));

            migrationBuilder.DropColumn(
                name: "SetRefTermId",
                table: "SetRefTerms");

            migrationBuilder.DropColumn(
                name: "ReftermId",
                table: "RetTerms");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "SetRefTerms",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "RetTerms",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SetRefTerms",
                table: "SetRefTerms",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RetTerms",
                table: "RetTerms",
                column: "Id");

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

            migrationBuilder.InsertData(
                table: "RetTerms",
                columns: new[] { "Id", "Description", "Key" },
                values: new object[,]
                {
                    { new Guid("3bbd0a04-40d0-44fb-ba4d-c25d0926d7df"), @"Types of addresses
                ", "ADDRESS_TYPE" },
                    { new Guid("a673bec7-aae1-4cca-b459-fb5d5bbfe3e1"), @"Types of countries
                ", "COUNTRY" },
                    { new Guid("66ce5b88-684d-4a82-96b6-d9c8bb751687"), @"Types of emails
                ", "EMAIL_ADDRESS_TYPE" },
                    { new Guid("a447a151-130e-46df-917b-d09976d2ebb5"), @"Types of phonenumber
                ", "PHONE_NUMBER_TYPE" }
                });

            migrationBuilder.InsertData(
                table: "SetRefTerms",
                columns: new[] { "Id", "RefSetid", "ReftermId" },
                values: new object[,]
                {
                    { new Guid("a1c2cd8c-aae4-463d-b873-841c40f4bf86"), new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7"), new Guid("a447a151-130e-46df-917b-d09976d2ebb5") },
                    { new Guid("a0229113-f803-4403-ba10-b0698d0cbbbe"), new Guid("7b135772-658f-4bdf-a01c-cedba350cb41"), new Guid("a447a151-130e-46df-917b-d09976d2ebb5") },
                    { new Guid("2aa77699-21f7-442a-8b0d-b6e3f6b9211d"), new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"), new Guid("66ce5b88-684d-4a82-96b6-d9c8bb751687") },
                    { new Guid("7e9c9d23-7728-4808-975d-d07b42d8e039"), new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7"), new Guid("3bbd0a04-40d0-44fb-ba4d-c25d0926d7df") },
                    { new Guid("5d14d241-437e-4819-ab01-58563d95c73c"), new Guid("1f1f245d-c63b-42f6-b592-49b5b16bf861"), new Guid("a673bec7-aae1-4cca-b459-fb5d5bbfe3e1") },
                    { new Guid("d1f520f4-976d-4ec7-a523-24985873a91b"), new Guid("e7c0cab2-367b-4b60-805f-8b20cdadc599"), new Guid("a673bec7-aae1-4cca-b459-fb5d5bbfe3e1") },
                    { new Guid("d2ffc955-b24b-411a-8cdb-26516bcfe3db"), new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"), new Guid("3bbd0a04-40d0-44fb-ba4d-c25d0926d7df") },
                    { new Guid("0bd3c11f-c1c5-48f5-8ece-86cfeb5ede88"), new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"), new Guid("a447a151-130e-46df-917b-d09976d2ebb5") },
                    { new Guid("173487fc-5809-4d64-8a2c-a23403127e30"), new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7"), new Guid("66ce5b88-684d-4a82-96b6-d9c8bb751687") }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SetRefTerms",
                table: "SetRefTerms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RetTerms",
                table: "RetTerms");

            migrationBuilder.DeleteData(
                table: "RetTerms",
                keyColumn: "Id",
                keyValue: new Guid("3bbd0a04-40d0-44fb-ba4d-c25d0926d7df"));

            migrationBuilder.DeleteData(
                table: "RetTerms",
                keyColumn: "Id",
                keyValue: new Guid("66ce5b88-684d-4a82-96b6-d9c8bb751687"));

            migrationBuilder.DeleteData(
                table: "RetTerms",
                keyColumn: "Id",
                keyValue: new Guid("a447a151-130e-46df-917b-d09976d2ebb5"));

            migrationBuilder.DeleteData(
                table: "RetTerms",
                keyColumn: "Id",
                keyValue: new Guid("a673bec7-aae1-4cca-b459-fb5d5bbfe3e1"));

            migrationBuilder.DeleteData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("0bd3c11f-c1c5-48f5-8ece-86cfeb5ede88"));

            migrationBuilder.DeleteData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("173487fc-5809-4d64-8a2c-a23403127e30"));

            migrationBuilder.DeleteData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("2aa77699-21f7-442a-8b0d-b6e3f6b9211d"));

            migrationBuilder.DeleteData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("5d14d241-437e-4819-ab01-58563d95c73c"));

            migrationBuilder.DeleteData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("7e9c9d23-7728-4808-975d-d07b42d8e039"));

            migrationBuilder.DeleteData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("a0229113-f803-4403-ba10-b0698d0cbbbe"));

            migrationBuilder.DeleteData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("a1c2cd8c-aae4-463d-b873-841c40f4bf86"));

            migrationBuilder.DeleteData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("d1f520f4-976d-4ec7-a523-24985873a91b"));

            migrationBuilder.DeleteData(
                table: "SetRefTerms",
                keyColumn: "Id",
                keyValue: new Guid("d2ffc955-b24b-411a-8cdb-26516bcfe3db"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SetRefTerms");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RetTerms");

            migrationBuilder.AddColumn<Guid>(
                name: "SetRefTermId",
                table: "SetRefTerms",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ReftermId",
                table: "RetTerms",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SetRefTerms",
                table: "SetRefTerms",
                column: "SetRefTermId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RetTerms",
                table: "RetTerms",
                column: "ReftermId");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("859a0577-76ad-49ef-a111-346e4f978a88"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 9, 18, 55, 3, 356, DateTimeKind.Local).AddTicks(9908));

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 9, 18, 55, 3, 357, DateTimeKind.Local).AddTicks(13));

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 9, 18, 55, 3, 357, DateTimeKind.Local).AddTicks(2499));

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: new Guid("d019119e-245b-45d2-93df-b4cbbdfeac9f"),
                column: "DateCreated",
                value: new DateTime(2023, 1, 9, 18, 55, 3, 357, DateTimeKind.Local).AddTicks(2404));

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

            migrationBuilder.InsertData(
                table: "RetTerms",
                columns: new[] { "ReftermId", "Description", "Key" },
                values: new object[,]
                {
                    { new Guid("3bbd0a04-40d0-44fb-ba4d-c25d0926d7df"), @"Types of addresses
                ", "ADDRESS_TYPE" },
                    { new Guid("a673bec7-aae1-4cca-b459-fb5d5bbfe3e1"), @"Types of countries
                ", "COUNTRY" },
                    { new Guid("66ce5b88-684d-4a82-96b6-d9c8bb751687"), @"Types of emails
                ", "EMAIL_ADDRESS_TYPE" },
                    { new Guid("a447a151-130e-46df-917b-d09976d2ebb5"), @"Types of phonenumber
                ", "PHONE_NUMBER_TYPE" }
                });

            migrationBuilder.InsertData(
                table: "SetRefTerms",
                columns: new[] { "SetRefTermId", "RefSetid", "ReftermId" },
                values: new object[,]
                {
                    { new Guid("a1c2cd8c-aae4-463d-b873-841c40f4bf86"), new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7"), new Guid("a447a151-130e-46df-917b-d09976d2ebb5") },
                    { new Guid("a0229113-f803-4403-ba10-b0698d0cbbbe"), new Guid("7b135772-658f-4bdf-a01c-cedba350cb41"), new Guid("a447a151-130e-46df-917b-d09976d2ebb5") },
                    { new Guid("2aa77699-21f7-442a-8b0d-b6e3f6b9211d"), new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"), new Guid("66ce5b88-684d-4a82-96b6-d9c8bb751687") },
                    { new Guid("7e9c9d23-7728-4808-975d-d07b42d8e039"), new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7"), new Guid("3bbd0a04-40d0-44fb-ba4d-c25d0926d7df") },
                    { new Guid("5d14d241-437e-4819-ab01-58563d95c73c"), new Guid("1f1f245d-c63b-42f6-b592-49b5b16bf861"), new Guid("a673bec7-aae1-4cca-b459-fb5d5bbfe3e1") },
                    { new Guid("d1f520f4-976d-4ec7-a523-24985873a91b"), new Guid("e7c0cab2-367b-4b60-805f-8b20cdadc599"), new Guid("a673bec7-aae1-4cca-b459-fb5d5bbfe3e1") },
                    { new Guid("d2ffc955-b24b-411a-8cdb-26516bcfe3db"), new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"), new Guid("3bbd0a04-40d0-44fb-ba4d-c25d0926d7df") },
                    { new Guid("0bd3c11f-c1c5-48f5-8ece-86cfeb5ede88"), new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"), new Guid("a447a151-130e-46df-917b-d09976d2ebb5") },
                    { new Guid("173487fc-5809-4d64-8a2c-a23403127e30"), new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7"), new Guid("66ce5b88-684d-4a82-96b6-d9c8bb751687") }
                });

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
    }
}
