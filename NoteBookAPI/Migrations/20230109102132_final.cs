﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NoteBookAPI.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefSets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefSets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RetTerms",
                columns: table => new
                {
                    ReftermId = table.Column<Guid>(nullable: false),
                    Key = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetTerms", x => x.ReftermId);
                });

            migrationBuilder.CreateTable(
                name: "SetRefTerms",
                columns: table => new
                {
                    SetRefTermId = table.Column<Guid>(nullable: false),
                    RefSetid = table.Column<Guid>(nullable: false),
                    ReftermId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetRefTerms", x => x.SetRefTermId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<Guid>(nullable: false),
                    UpdateBy = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<Guid>(nullable: false),
                    UpdateBy = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Line1 = table.Column<string>(nullable: true),
                    Line2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zipcode = table.Column<string>(nullable: true),
                    Type = table.Column<Guid>(nullable: false),
                    Country = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<Guid>(nullable: false),
                    UpdateBy = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    File = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<Guid>(nullable: false),
                    UpdateBy = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    TypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhNumbers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    CreateBy = table.Column<Guid>(nullable: false),
                    UpdateBy = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    TypeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhNumbers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "RefSets",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"), @"It is used to the detail mentioned all about personal
                ", "PERSONAL" },
                    { new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7"), @"The detail mentioned is all about Work based
                ", "WORK" },
                    { new Guid("1f1f245d-c63b-42f6-b592-49b5b16bf861"), @"Country
                ", "INDIA" },
                    { new Guid("e7c0cab2-367b-4b60-805f-8b20cdadc599"), @"Country
                ", "UNITED_STATES" },
                    { new Guid("7b135772-658f-4bdf-a01c-cedba350cb41"), @"Alternate number
                ", "ALTERNATE" }
                });

            migrationBuilder.InsertData(
                table: "RetTerms",
                columns: new[] { "ReftermId", "Description", "Key" },
                values: new object[,]
                {
                    { new Guid("3bbd0a04-40d0-44fb-ba4d-c25d0926d7df"), @"Types of addresses
                ", "ADDRESS_TYPE" },
                    { new Guid("a447a151-130e-46df-917b-d09976d2ebb5"), @"Types of phonenumber
                ", "PHONE_NUMBER_TYPE" },
                    { new Guid("66ce5b88-684d-4a82-96b6-d9c8bb751687"), @"Types of emails
                ", "EMAIL_ADDRESS_TYPE" },
                    { new Guid("a673bec7-aae1-4cca-b459-fb5d5bbfe3e1"), @"Types of countries
                ", "COUNTRY" }
                });

            migrationBuilder.InsertData(
                table: "SetRefTerms",
                columns: new[] { "SetRefTermId", "RefSetid", "ReftermId" },
                values: new object[,]
                {
                    { new Guid("d1f520f4-976d-4ec7-a523-24985873a91b"), new Guid("e7c0cab2-367b-4b60-805f-8b20cdadc599"), new Guid("a673bec7-aae1-4cca-b459-fb5d5bbfe3e1") },
                    { new Guid("5d14d241-437e-4819-ab01-58563d95c73c"), new Guid("1f1f245d-c63b-42f6-b592-49b5b16bf861"), new Guid("a673bec7-aae1-4cca-b459-fb5d5bbfe3e1") },
                    { new Guid("173487fc-5809-4d64-8a2c-a23403127e30"), new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7"), new Guid("66ce5b88-684d-4a82-96b6-d9c8bb751687") },
                    { new Guid("2aa77699-21f7-442a-8b0d-b6e3f6b9211d"), new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"), new Guid("66ce5b88-684d-4a82-96b6-d9c8bb751687") },
                    { new Guid("d2ffc955-b24b-411a-8cdb-26516bcfe3db"), new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"), new Guid("3bbd0a04-40d0-44fb-ba4d-c25d0926d7df") },
                    { new Guid("a1c2cd8c-aae4-463d-b873-841c40f4bf86"), new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7"), new Guid("a447a151-130e-46df-917b-d09976d2ebb5") },
                    { new Guid("0bd3c11f-c1c5-48f5-8ece-86cfeb5ede88"), new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"), new Guid("a447a151-130e-46df-917b-d09976d2ebb5") },
                    { new Guid("7e9c9d23-7728-4808-975d-d07b42d8e039"), new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7"), new Guid("3bbd0a04-40d0-44fb-ba4d-c25d0926d7df") },
                    { new Guid("a0229113-f803-4403-ba10-b0698d0cbbbe"), new Guid("7b135772-658f-4bdf-a01c-cedba350cb41"), new Guid("a447a151-130e-46df-917b-d09976d2ebb5") }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateBy", "DateCreated", "DateUpdated", "FirstName", "LastName", "UpdateBy", "password" },
                values: new object[,]
                {
                    { new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"), new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"), new DateTime(2023, 1, 9, 15, 51, 32, 91, DateTimeKind.Local).AddTicks(7364), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sakthi", "Vel", new Guid("00000000-0000-0000-0000-000000000000"), "Hello@123" },
                    { new Guid("68417748-6864-4866-8d9b-b82ae29da396"), new Guid("68417748-6864-4866-8d9b-b82ae29da396"), new DateTime(2023, 1, 9, 15, 51, 32, 92, DateTimeKind.Local).AddTicks(2452), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Manoj", "Kumar", new Guid("00000000-0000-0000-0000-000000000000"), "Hello@321" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "CreateBy", "DateCreated", "DateUpdated", "Line1", "Line2", "State", "Type", "UpdateBy", "UserId", "Zipcode" },
                values: new object[,]
                {
                    { new Guid("859a0577-76ad-49ef-a111-346e4f978a88"), "madurai", new Guid("1f1f245d-c63b-42f6-b592-49b5b16bf861"), new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"), new DateTime(2023, 1, 9, 15, 51, 32, 93, DateTimeKind.Local).AddTicks(3301), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "hello", "solunga", "tamilnadu", new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"), "625002" },
                    { new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"), "madurai", new Guid("1f1f245d-c63b-42f6-b592-49b5b16bf861"), new Guid("68417748-6864-4866-8d9b-b82ae29da396"), new DateTime(2023, 1, 9, 15, 51, 32, 93, DateTimeKind.Local).AddTicks(3391), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "hello", "solunga", "tamilnadu", new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("68417748-6864-4866-8d9b-b82ae29da396"), "625002" }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "CreateBy", "DateCreated", "DateUpdated", "TypeId", "UpdateBy", "UserId", "email" },
                values: new object[,]
                {
                    { new Guid("d019119e-245b-45d2-93df-b4cbbdfeac9f"), new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"), new DateTime(2023, 1, 9, 15, 51, 32, 93, DateTimeKind.Local).AddTicks(5792), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"), "itsmemano123@gmail.com" },
                    { new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"), new Guid("68417748-6864-4866-8d9b-b82ae29da396"), new DateTime(2023, 1, 9, 15, 51, 32, 93, DateTimeKind.Local).AddTicks(5845), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("68417748-6864-4866-8d9b-b82ae29da396"), "itsmemano@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "PhNumbers",
                columns: new[] { "Id", "CreateBy", "DateCreated", "DateUpdated", "PhoneNumber", "TypeId", "UpdateBy", "UserId" },
                values: new object[,]
                {
                    { new Guid("00793011-a986-49f0-879b-86023edaff46"), new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"), new DateTime(2023, 1, 9, 15, 51, 32, 93, DateTimeKind.Local).AddTicks(4604), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "8925250061", new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be") },
                    { new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"), new Guid("68417748-6864-4866-8d9b-b82ae29da396"), new DateTime(2023, 1, 9, 15, 51, 32, 93, DateTimeKind.Local).AddTicks(4649), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "9488977667", new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("68417748-6864-4866-8d9b-b82ae29da396") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_UserId",
                table: "Assets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Emails_UserId",
                table: "Emails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhNumbers_UserId",
                table: "PhNumbers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "PhNumbers");

            migrationBuilder.DropTable(
                name: "RefSets");

            migrationBuilder.DropTable(
                name: "RetTerms");

            migrationBuilder.DropTable(
                name: "SetRefTerms");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
