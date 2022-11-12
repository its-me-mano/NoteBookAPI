using Microsoft.EntityFrameworkCore;
using NoteBookAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.DbContexts
{
    public class UserDetailsContext: DbContext
    {
        public UserDetailsContext(DbContextOptions<UserDetailsContext> options) : base(options){
            
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Phone> PhNumbers { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<RefSet> RefSets{ get; set; }
        public DbSet<RefTerm> RetTerms { get; set; }
        public DbSet<SetRefTerm> SetRefTerms { get; set; }
        public DbSet<ImageStore> ImageStores { get; set; }

            public DbSet<AssetDto> AssetDtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
/*
                                     USER
*/
            modelBuilder.Entity<User>().HasData(new User()
            {
                UserId=Guid.Parse("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                FirstName="Sakthi",
                LastName="Vel",
                password="Hello@123"
            },
            new User() {
                UserId = Guid.Parse("68417748-6864-4866-8d9b-b82ae29da396"),
                FirstName = "Manoj",
                LastName = "Kumar",
                password = "Hello@321"
            }
            
            );
/*
                                    ADDRESS
*/
            modelBuilder.Entity<Address>().HasData(new Address() { 
                UserId=Guid.Parse("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                AddressId=Guid.Parse("859a0577-76ad-49ef-a111-346e4f978a88"),
                Line1="hello",
                Line2="solunga",
                City="madurai",
                State="tamilnadu",
                Zipcode="625002",
                Type=Guid.Parse("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                Country=Guid.Parse("1f1f245d-c63b-42f6-b592-49b5b16bf861")
            },
            new Address()
            {
                UserId = Guid.Parse("68417748-6864-4866-8d9b-b82ae29da396"),
                AddressId = Guid.Parse("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                Line1 = "hello",
                Line2 = "solunga",
                City = "madurai",
                State = "tamilnadu",
           
                Zipcode = "625002",
                Type = Guid.Parse("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                Country=Guid.Parse("1f1f245d-c63b-42f6-b592-49b5b16bf861")

            }
            );
/*
                                      PHONE
*/
            modelBuilder.Entity<Phone>().HasData(new Phone()
            {
                UserId = Guid.Parse("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                PhId = Guid.Parse("00793011-a986-49f0-879b-86023edaff46"),
                PhoneNumber = "8925250061",
                TypeId = Guid.Parse("abad70c5-11db-42f8-9e3a-487023f1b1cc")
            },
            new Phone()
            {
                UserId = Guid.Parse("68417748-6864-4866-8d9b-b82ae29da396"),
                PhId = Guid.Parse("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                PhoneNumber = "9488977667",
                TypeId = Guid.Parse("abad70c5-11db-42f8-9e3a-487023f1b1cc")

            }
            );
/*
                                    EMAIL
*/
            modelBuilder.Entity<Email>().HasData(new Email() {
                UserId = Guid.Parse("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                EmailId = Guid.Parse("d019119e-245b-45d2-93df-b4cbbdfeac9f"),
                email = "itsmemano123@gmail.com",
                TypeId = Guid.Parse("abad70c5-11db-42f8-9e3a-487023f1b1cc")

            },
            new Email()
            {
                UserId = Guid.Parse("68417748-6864-4866-8d9b-b82ae29da396"),
                EmailId = Guid.Parse("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                email = "itsmemano@gmail.com",
                TypeId= Guid.Parse("abad70c5-11db-42f8-9e3a-487023f1b1cc")

            });
/*
                                    REFSET

*/
            modelBuilder.Entity<RefSet>().HasData(new RefSet()
            {
                Name="PERSONAL",
                TypeId=Guid.Parse("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                Description="It is used to the detail mentioned all about personal"
            },
            new RefSet() { 
                Name="WORK",
                TypeId=Guid.Parse("0d80e411-064c-4025-abd3-b10373c5b0c7"),
                Description="The detail mentioned is all about Work based"
            },
            new RefSet() { 
                Name="INDIA",
                TypeId=Guid.Parse("1f1f245d-c63b-42f6-b592-49b5b16bf861"),
                Description="Country",
            },
            new RefSet() { 
                Name="UNITED_STATES",
                TypeId=Guid.Parse("e7c0cab2-367b-4b60-805f-8b20cdadc599"),
                Description="Country"
            },
            new RefSet()
            {
                TypeId = Guid.Parse("7b135772-658f-4bdf-a01c-cedba350cb41"),
                Name = "ALTERNATE",
                Description = "Alternate number"
            }
            );
            /*
                                    REFTERM
            */
            modelBuilder.Entity<RefTerm>().HasData(new RefTerm()
            {
                ReftermId=Guid.Parse("3bbd0a04-40d0-44fb-ba4d-c25d0926d7df"),
                Types= "ADDRESS_TYPE",
                Description="Types of addresses"
            },
            new RefTerm() { 
                ReftermId=Guid.Parse("a447a151-130e-46df-917b-d09976d2ebb5"),
                Types= "PHONE_NUMBER_TYPE",
                Description="Types of phonenumber"
            },
            new RefTerm() { 
                ReftermId=Guid.Parse("66ce5b88-684d-4a82-96b6-d9c8bb751687"),
                Types= "EMAIL_ADDRESS_TYPE",
                Description="Types of emails"
            },
            new RefTerm() { 
                ReftermId=Guid.Parse("a673bec7-aae1-4cca-b459-fb5d5bbfe3e1"),
                Types="COUNTRY",
                Description="Types of countries"
            }
            );
/*
                                          SETREFTERM


*/
            modelBuilder.Entity<SetRefTerm>().HasData(
        //Address Type
            new SetRefTerm()
            {
                ReftermId = Guid.Parse("3bbd0a04-40d0-44fb-ba4d-c25d0926d7df"),
                RefSetid = Guid.Parse("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                SetRefTermId = Guid.Parse("d2ffc955-b24b-411a-8cdb-26516bcfe3db")
            },
            new SetRefTerm()
            {
                ReftermId = Guid.Parse("3bbd0a04-40d0-44fb-ba4d-c25d0926d7df"),
                RefSetid = Guid.Parse("0d80e411-064c-4025-abd3-b10373c5b0c7"),
                SetRefTermId = Guid.Parse("7e9c9d23-7728-4808-975d-d07b42d8e039")
            },


            //Phone Number Type
            new SetRefTerm()
            {
                ReftermId = Guid.Parse("a447a151-130e-46df-917b-d09976d2ebb5"),
                //Personal
                RefSetid = Guid.Parse("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                SetRefTermId = Guid.Parse("0bd3c11f-c1c5-48f5-8ece-86cfeb5ede88")
            },
            new SetRefTerm()
            {
                ReftermId = Guid.Parse("a447a151-130e-46df-917b-d09976d2ebb5"),
                //Work
                RefSetid = Guid.Parse("0d80e411-064c-4025-abd3-b10373c5b0c7"),
                SetRefTermId = Guid.Parse("a1c2cd8c-aae4-463d-b873-841c40f4bf86")
            },
            new SetRefTerm() { 
                ReftermId=Guid.Parse("a447a151-130e-46df-917b-d09976d2ebb5"),
                //Alternate
                RefSetid=Guid.Parse("7b135772-658f-4bdf-a01c-cedba350cb41"),
                SetRefTermId=Guid.Parse("a0229113-f803-4403-ba10-b0698d0cbbbe")
            },


            //Email Address Type
             new SetRefTerm()
             {
                 ReftermId = Guid.Parse("66ce5b88-684d-4a82-96b6-d9c8bb751687"),
                 RefSetid = Guid.Parse("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                 SetRefTermId = Guid.Parse("2aa77699-21f7-442a-8b0d-b6e3f6b9211d")
             },
             new SetRefTerm()
             {
                 ReftermId = Guid.Parse("66ce5b88-684d-4a82-96b6-d9c8bb751687"),
                 RefSetid = Guid.Parse("0d80e411-064c-4025-abd3-b10373c5b0c7"),
                 SetRefTermId = Guid.Parse("173487fc-5809-4d64-8a2c-a23403127e30")
             },


             //CountryType
             new SetRefTerm()
             {
                 ReftermId = Guid.Parse("a673bec7-aae1-4cca-b459-fb5d5bbfe3e1"),
                 //India
                 RefSetid = Guid.Parse("1f1f245d-c63b-42f6-b592-49b5b16bf861"),
                 SetRefTermId = Guid.Parse("5d14d241-437e-4819-ab01-58563d95c73c")
             },
             new SetRefTerm()
             {
                 ReftermId = Guid.Parse("a673bec7-aae1-4cca-b459-fb5d5bbfe3e1"),
                 //USA
                 RefSetid = Guid.Parse("e7c0cab2-367b-4b60-805f-8b20cdadc599"),
                 SetRefTermId = Guid.Parse("d1f520f4-976d-4ec7-a523-24985873a91b")
             }
            );
           /* modelBuilder.Entity<AssetDto>().HasData(new AssetDto()
            {
                AssetId = Guid.NewGuid(),
                UserId=Guid.Parse("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be")
                
            },
            new AssetDto()
            {
                AssetId = Guid.NewGuid(),
                UserId = Guid.Parse("68417748-6864-4866-8d9b-b82ae29da396")

            }
            );*/



            base.OnModelCreating(modelBuilder);
        }



    }
}
