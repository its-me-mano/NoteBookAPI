﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NoteBookAPI.DbContexts;

namespace NoteBookAPI.Migrations
{
    [DbContext(typeof(UserDetailsContext))]
    partial class UserDetailsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NoteBookAPI.Entities.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Country")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Line1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Line2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Type")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Zipcode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = new Guid("859a0577-76ad-49ef-a111-346e4f978a88"),
                            City = "madurai",
                            Country = new Guid("1f1f245d-c63b-42f6-b592-49b5b16bf861"),
                            CreateBy = new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                            DateCreated = new DateTime(2023, 1, 12, 17, 20, 40, 151, DateTimeKind.Local).AddTicks(9616),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Line1 = "hello",
                            Line2 = "solunga",
                            StateName = "tamilnadu",
                            Type = new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            UserId = new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                            Zipcode = "625002"
                        },
                        new
                        {
                            Id = new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                            City = "madurai",
                            Country = new Guid("1f1f245d-c63b-42f6-b592-49b5b16bf861"),
                            CreateBy = new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                            DateCreated = new DateTime(2023, 1, 12, 17, 20, 40, 151, DateTimeKind.Local).AddTicks(9731),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Line1 = "hello",
                            Line2 = "solunga",
                            StateName = "tamilnadu",
                            Type = new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            UserId = new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                            Zipcode = "625002"
                        });
                });

            modelBuilder.Entity("NoteBookAPI.Entities.Asset", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("File")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("NoteBookAPI.Entities.Email", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Emails");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d019119e-245b-45d2-93df-b4cbbdfeac9f"),
                            CreateBy = new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                            DateCreated = new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(2093),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailAddress = "itsmemano123@gmail.com",
                            TypeId = new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            UserId = new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be")
                        },
                        new
                        {
                            Id = new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                            CreateBy = new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                            DateCreated = new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(2144),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmailAddress = "itsmemano@gmail.com",
                            TypeId = new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            UserId = new Guid("68417748-6864-4866-8d9b-b82ae29da396")
                        });
                });

            modelBuilder.Entity("NoteBookAPI.Entities.Phone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PhNumbers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("00793011-a986-49f0-879b-86023edaff46"),
                            CreateBy = new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                            DateCreated = new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(900),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PhoneNumber = "8925250061",
                            TypeId = new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            UserId = new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be")
                        },
                        new
                        {
                            Id = new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                            CreateBy = new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                            DateCreated = new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(947),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PhoneNumber = "9488977667",
                            TypeId = new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            UserId = new Guid("68417748-6864-4866-8d9b-b82ae29da396")
                        });
                });

            modelBuilder.Entity("NoteBookAPI.Entities.RefSet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("RefSets");

                    b.HasData(
                        new
                        {
                            Id = new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                            CreateBy = new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                            DateCreated = new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(4938),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = @"It is used to the detail mentioned all about personal",
                            Key = "PERSONAL",
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7"),
                            CreateBy = new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                            DateCreated = new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(5191),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = @"The detail mentioned is all about Work based",
                            Key = "WORK",
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("1f1f245d-c63b-42f6-b592-49b5b16bf861"),
                            CreateBy = new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                            DateCreated = new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(5230),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = @"Country",
                            Key = "INDIA",
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("e7c0cab2-367b-4b60-805f-8b20cdadc599"),
                            CreateBy = new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                            DateCreated = new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(5255),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = @"Country",
                            Key = "UNITED_STATES",
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("7b135772-658f-4bdf-a01c-cedba350cb41"),
                            CreateBy = new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                            DateCreated = new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(5277),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = @"Alternate number",
                            Key = "ALTERNATE",
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("NoteBookAPI.Entities.RefTerm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("RetTerms");

                    b.HasData(
                        new
                        {
                            Id = new Guid("3bbd0a04-40d0-44fb-ba4d-c25d0926d7df"),
                            CreateBy = new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                            DateCreated = new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(6713),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = @"Types of addresses",
                            Key = "ADDRESS_TYPE",
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("a447a151-130e-46df-917b-d09976d2ebb5"),
                            CreateBy = new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                            DateCreated = new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(6949),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = @"Types of phonenumber",
                            Key = "PHONE_NUMBER_TYPE",
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("66ce5b88-684d-4a82-96b6-d9c8bb751687"),
                            CreateBy = new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                            DateCreated = new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(6985),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = @"Types of emails",
                            Key = "EMAIL_ADDRESS_TYPE",
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("a673bec7-aae1-4cca-b459-fb5d5bbfe3e1"),
                            CreateBy = new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                            DateCreated = new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(7041),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = @"Types of countries",
                            Key = "COUNTRY",
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("NoteBookAPI.Entities.SetRefTerm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RefSetid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ReftermId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("SetRefTerms");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d2ffc955-b24b-411a-8cdb-26516bcfe3db"),
                            CreateBy = new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                            DateCreated = new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(8568),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RefSetid = new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                            ReftermId = new Guid("3bbd0a04-40d0-44fb-ba4d-c25d0926d7df"),
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("7e9c9d23-7728-4808-975d-d07b42d8e039"),
                            CreateBy = new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                            DateCreated = new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(8800),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RefSetid = new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7"),
                            ReftermId = new Guid("3bbd0a04-40d0-44fb-ba4d-c25d0926d7df"),
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("0bd3c11f-c1c5-48f5-8ece-86cfeb5ede88"),
                            CreateBy = new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                            DateCreated = new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(8838),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RefSetid = new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                            ReftermId = new Guid("a447a151-130e-46df-917b-d09976d2ebb5"),
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("a1c2cd8c-aae4-463d-b873-841c40f4bf86"),
                            CreateBy = new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                            DateCreated = new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(8864),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RefSetid = new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7"),
                            ReftermId = new Guid("a447a151-130e-46df-917b-d09976d2ebb5"),
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("a0229113-f803-4403-ba10-b0698d0cbbbe"),
                            CreateBy = new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                            DateCreated = new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(8925),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RefSetid = new Guid("7b135772-658f-4bdf-a01c-cedba350cb41"),
                            ReftermId = new Guid("a447a151-130e-46df-917b-d09976d2ebb5"),
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("2aa77699-21f7-442a-8b0d-b6e3f6b9211d"),
                            CreateBy = new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                            DateCreated = new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(8954),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RefSetid = new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                            ReftermId = new Guid("66ce5b88-684d-4a82-96b6-d9c8bb751687"),
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("173487fc-5809-4d64-8a2c-a23403127e30"),
                            CreateBy = new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                            DateCreated = new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(8978),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RefSetid = new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7"),
                            ReftermId = new Guid("66ce5b88-684d-4a82-96b6-d9c8bb751687"),
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("5d14d241-437e-4819-ab01-58563d95c73c"),
                            CreateBy = new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                            DateCreated = new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(9001),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RefSetid = new Guid("1f1f245d-c63b-42f6-b592-49b5b16bf861"),
                            ReftermId = new Guid("a673bec7-aae1-4cca-b459-fb5d5bbfe3e1"),
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            Id = new Guid("d1f520f4-976d-4ec7-a523-24985873a91b"),
                            CreateBy = new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                            DateCreated = new DateTime(2023, 1, 12, 17, 20, 40, 152, DateTimeKind.Local).AddTicks(9024),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            RefSetid = new Guid("e7c0cab2-367b-4b60-805f-8b20cdadc599"),
                            ReftermId = new Guid("a673bec7-aae1-4cca-b459-fb5d5bbfe3e1"),
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("NoteBookAPI.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UpdateBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                            CreateBy = new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                            DateCreated = new DateTime(2023, 1, 12, 17, 20, 40, 150, DateTimeKind.Local).AddTicks(3342),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Sakthi",
                            LastName = "Vel",
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            password = "Hello@123"
                        },
                        new
                        {
                            Id = new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                            CreateBy = new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                            DateCreated = new DateTime(2023, 1, 12, 17, 20, 40, 150, DateTimeKind.Local).AddTicks(8214),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Manoj",
                            LastName = "Kumar",
                            UpdateBy = new Guid("00000000-0000-0000-0000-000000000000"),
                            password = "Hello@321"
                        });
                });

            modelBuilder.Entity("NoteBookAPI.Entities.Address", b =>
                {
                    b.HasOne("NoteBookAPI.Entities.User", null)
                        .WithMany("Address")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NoteBookAPI.Entities.Asset", b =>
                {
                    b.HasOne("NoteBookAPI.Entities.User", null)
                        .WithMany("Assets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NoteBookAPI.Entities.Email", b =>
                {
                    b.HasOne("NoteBookAPI.Entities.User", null)
                        .WithMany("Emails")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NoteBookAPI.Entities.Phone", b =>
                {
                    b.HasOne("NoteBookAPI.Entities.User", null)
                        .WithMany("Phones")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
