﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NoteBookAPI.DbContexts;

namespace NoteBookAPI.Migrations
{
    [DbContext(typeof(UserDetailsContext))]
    [Migration("20221110171021_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NoteBookAPI.Entities.Address", b =>
                {
                    b.Property<Guid>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CountryType")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Line1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Line2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Type")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Zipcode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            AddressId = new Guid("859a0577-76ad-49ef-a111-346e4f978a88"),
                            City = "madurai",
                            CountryType = new Guid("1f1f245d-c63b-42f6-b592-49b5b16bf861"),
                            Line1 = "hello",
                            Line2 = "solunga",
                            State = "tamilnadu",
                            Type = new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                            UserId = new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                            Zipcode = "625002"
                        },
                        new
                        {
                            AddressId = new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                            City = "madurai",
                            CountryType = new Guid("1f1f245d-c63b-42f6-b592-49b5b16bf861"),
                            Line1 = "hello",
                            Line2 = "solunga",
                            State = "tamilnadu",
                            Type = new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                            UserId = new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                            Zipcode = "625002"
                        });
                });

            modelBuilder.Entity("NoteBookAPI.Entities.Email", b =>
                {
                    b.Property<Guid>("EmailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmailId");

                    b.HasIndex("UserId");

                    b.ToTable("Emails");

                    b.HasData(
                        new
                        {
                            EmailId = new Guid("d019119e-245b-45d2-93df-b4cbbdfeac9f"),
                            TypeId = new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                            UserId = new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                            email = "itsmemano123@gmail.com"
                        },
                        new
                        {
                            EmailId = new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                            TypeId = new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                            UserId = new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                            email = "itsmemano@gmail.com"
                        });
                });

            modelBuilder.Entity("NoteBookAPI.Entities.Phone", b =>
                {
                    b.Property<Guid>("PhId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PhId");

                    b.HasIndex("UserId");

                    b.ToTable("PhNumbers");

                    b.HasData(
                        new
                        {
                            PhId = new Guid("00793011-a986-49f0-879b-86023edaff46"),
                            PhNo = "8925250061",
                            TypeId = new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                            UserId = new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be")
                        },
                        new
                        {
                            PhId = new Guid("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                            PhNo = "9488977667",
                            TypeId = new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                            UserId = new Guid("68417748-6864-4866-8d9b-b82ae29da396")
                        });
                });

            modelBuilder.Entity("NoteBookAPI.Entities.RefSet", b =>
                {
                    b.Property<Guid>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TypeId");

                    b.ToTable("RefSets");

                    b.HasData(
                        new
                        {
                            TypeId = new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                            Description = "It is used to the detail mentioned all about personal",
                            Name = "PERSONAL"
                        },
                        new
                        {
                            TypeId = new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7"),
                            Description = "The detail mentioned is all about Work based",
                            Name = "WORK"
                        },
                        new
                        {
                            TypeId = new Guid("1f1f245d-c63b-42f6-b592-49b5b16bf861"),
                            Description = "Country",
                            Name = "INDIA"
                        },
                        new
                        {
                            TypeId = new Guid("e7c0cab2-367b-4b60-805f-8b20cdadc599"),
                            Description = "Country",
                            Name = "UNITED_STATES"
                        });
                });

            modelBuilder.Entity("NoteBookAPI.Entities.RefTerm", b =>
                {
                    b.Property<Guid>("ReftermId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Types")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReftermId");

                    b.ToTable("RetTerms");

                    b.HasData(
                        new
                        {
                            ReftermId = new Guid("3bbd0a04-40d0-44fb-ba4d-c25d0926d7df"),
                            Description = "Types of addresses",
                            Types = "ADDRESS_TYPE"
                        },
                        new
                        {
                            ReftermId = new Guid("a447a151-130e-46df-917b-d09976d2ebb5"),
                            Description = "Types of phonenumber",
                            Types = "PHONE_NUMBER_TYPE"
                        },
                        new
                        {
                            ReftermId = new Guid("66ce5b88-684d-4a82-96b6-d9c8bb751687"),
                            Description = "Types of emails",
                            Types = "EMAIL_ADDRESS_TYPE"
                        },
                        new
                        {
                            ReftermId = new Guid("a673bec7-aae1-4cca-b459-fb5d5bbfe3e1"),
                            Description = "Types of countries",
                            Types = "COUNTRY"
                        },
                        new
                        {
                            ReftermId = new Guid("7b135772-658f-4bdf-a01c-cedba350cb41"),
                            Description = "Alternate number",
                            Types = "ALTERNATE"
                        });
                });

            modelBuilder.Entity("NoteBookAPI.Entities.SetRefTerm", b =>
                {
                    b.Property<Guid>("SetRefTermId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RefSetid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ReftermId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SetRefTermId");

                    b.ToTable("SetRefTerms");

                    b.HasData(
                        new
                        {
                            SetRefTermId = new Guid("d2ffc955-b24b-411a-8cdb-26516bcfe3db"),
                            RefSetid = new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                            ReftermId = new Guid("3bbd0a04-40d0-44fb-ba4d-c25d0926d7df")
                        },
                        new
                        {
                            SetRefTermId = new Guid("7e9c9d23-7728-4808-975d-d07b42d8e039"),
                            RefSetid = new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7"),
                            ReftermId = new Guid("3bbd0a04-40d0-44fb-ba4d-c25d0926d7df")
                        },
                        new
                        {
                            SetRefTermId = new Guid("0bd3c11f-c1c5-48f5-8ece-86cfeb5ede88"),
                            RefSetid = new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                            ReftermId = new Guid("a447a151-130e-46df-917b-d09976d2ebb5")
                        },
                        new
                        {
                            SetRefTermId = new Guid("a1c2cd8c-aae4-463d-b873-841c40f4bf86"),
                            RefSetid = new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7"),
                            ReftermId = new Guid("a447a151-130e-46df-917b-d09976d2ebb5")
                        },
                        new
                        {
                            SetRefTermId = new Guid("a0229113-f803-4403-ba10-b0698d0cbbbe"),
                            RefSetid = new Guid("7b135772-658f-4bdf-a01c-cedba350cb41"),
                            ReftermId = new Guid("a447a151-130e-46df-917b-d09976d2ebb5")
                        },
                        new
                        {
                            SetRefTermId = new Guid("2aa77699-21f7-442a-8b0d-b6e3f6b9211d"),
                            RefSetid = new Guid("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                            ReftermId = new Guid("66ce5b88-684d-4a82-96b6-d9c8bb751687")
                        },
                        new
                        {
                            SetRefTermId = new Guid("173487fc-5809-4d64-8a2c-a23403127e30"),
                            RefSetid = new Guid("0d80e411-064c-4025-abd3-b10373c5b0c7"),
                            ReftermId = new Guid("66ce5b88-684d-4a82-96b6-d9c8bb751687")
                        },
                        new
                        {
                            SetRefTermId = new Guid("5d14d241-437e-4819-ab01-58563d95c73c"),
                            RefSetid = new Guid("1f1f245d-c63b-42f6-b592-49b5b16bf861"),
                            ReftermId = new Guid("a673bec7-aae1-4cca-b459-fb5d5bbfe3e1")
                        },
                        new
                        {
                            SetRefTermId = new Guid("d1f520f4-976d-4ec7-a523-24985873a91b"),
                            RefSetid = new Guid("e7c0cab2-367b-4b60-805f-8b20cdadc599"),
                            ReftermId = new Guid("a673bec7-aae1-4cca-b459-fb5d5bbfe3e1")
                        });
                });

            modelBuilder.Entity("NoteBookAPI.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                            FirstName = "Sakthi",
                            LastName = "Vel",
                            password = "Hello@123"
                        },
                        new
                        {
                            UserId = new Guid("68417748-6864-4866-8d9b-b82ae29da396"),
                            FirstName = "Manoj",
                            LastName = "Kumar",
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
