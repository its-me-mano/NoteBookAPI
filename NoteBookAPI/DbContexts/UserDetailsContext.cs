using Microsoft.EntityFrameworkCore;
using NoteBookAPI.Entities;
using System;
using System.IO;

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
        public DbSet<Asset> Assets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
      
            /*
                                                 USER
            */
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = Guid.Parse("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                FirstName = "Sakthi",
                LastName = "Vel",
                password = "Hello@123",
                CreateBy = Guid.Parse("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                DateCreated = DateTime.Now
            },
            new User()
            {
                Id = Guid.Parse("68417748-6864-4866-8d9b-b82ae29da396"),
                FirstName = "Manoj",
                LastName = "Kumar",
                password = "Hello@321",
                CreateBy = Guid.Parse("68417748-6864-4866-8d9b-b82ae29da396"),
               DateCreated = DateTime.Now
            }

            );
/*
                                    ADDRESS
*/
            modelBuilder.Entity<Address>().HasData(new Address() { 
                    UserId=Guid.Parse("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                    Id=Guid.Parse("859a0577-76ad-49ef-a111-346e4f978a88"),
                    Line1="hello",
                    Line2="solunga",
                    City="madurai",
                    StateName="tamilnadu",
                    Zipcode="625002",
                    Type=Guid.Parse("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                    Country=Guid.Parse("1f1f245d-c63b-42f6-b592-49b5b16bf861"),
                    CreateBy = Guid.Parse("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                    DateCreated = DateTime.Now
            },
            new Address()
            {
                UserId = Guid.Parse("68417748-6864-4866-8d9b-b82ae29da396"),
                Id = Guid.Parse("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                Line1 = "hello",
                Line2 = "solunga",
                City = "madurai",
                StateName = "tamilnadu",
                Zipcode = "625002",
                Type = Guid.Parse("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                Country=Guid.Parse("1f1f245d-c63b-42f6-b592-49b5b16bf861"),
                CreateBy = Guid.Parse("68417748-6864-4866-8d9b-b82ae29da396"),
                DateCreated = DateTime.Now

            }
            );
/*
                                      PHONE
*/
            modelBuilder.Entity<Phone>().HasData(new Phone()
            {
                UserId = Guid.Parse("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                Id = Guid.Parse("00793011-a986-49f0-879b-86023edaff46"),
                PhoneNumber = "8925250061",
                TypeId = Guid.Parse("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                CreateBy = Guid.Parse("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
              DateCreated = DateTime.Now
            },
            new Phone()
            {
                UserId = Guid.Parse("68417748-6864-4866-8d9b-b82ae29da396"),
                Id = Guid.Parse("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                PhoneNumber = "9488977667",
                TypeId = Guid.Parse("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                CreateBy = Guid.Parse("68417748-6864-4866-8d9b-b82ae29da396"),
               DateCreated = DateTime.Now
            }
            );
/*
                                    EMAIL
*/
            modelBuilder.Entity<Email>().HasData(new Email() {
                UserId = Guid.Parse("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                Id = Guid.Parse("d019119e-245b-45d2-93df-b4cbbdfeac9f"),
                EmailAddress = "itsmemano123@gmail.com",
                TypeId = Guid.Parse("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                CreateBy = Guid.Parse("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                DateCreated = DateTime.Now

            },
            new Email()
            {
                UserId = Guid.Parse("68417748-6864-4866-8d9b-b82ae29da396"),
                Id = Guid.Parse("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                EmailAddress = "itsmemano@gmail.com",
                TypeId= Guid.Parse("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                CreateBy = Guid.Parse("68417748-6864-4866-8d9b-b82ae29da396"),
                DateCreated = DateTime.Now
                

            });
            /*
                                                REFSET

            */
            /*string path = System.IO.Path.GetFullPath("./DbContexts/Refset.csv");*/
            string path = @"C:\Users\Manoj\source\repos\NoteBookAPI\NoteBookAPI\DbContexts\Refset.csv";
            string ReadCSV = File.ReadAllText(path);
            foreach (string csvRow in ReadCSV.Split("\n")) {
                if (!string.IsNullOrEmpty(csvRow)) {
                    string[] csvCols = csvRow.Split(",");
                    RefSet refSet = new RefSet();
                    refSet.Id = Guid.Parse(csvCols[1].ToString());
                    refSet.Key = csvCols[0].ToString();
                    refSet.Description = csvCols[2].ToString();
                    modelBuilder.Entity<RefSet>().HasData(refSet);
                }
            }

            /*                         REFTERM
               *                        
             */
            /*  string path1 = System.IO.Path.GetFullPath("./DbContexts/RefTerm.csv");*/
            string path1 = @"C:\Users\Manoj\source\repos\NoteBookAPI\NoteBookAPI\DbContexts\RefTerm.csv";
            string ReadCSV1 = File.ReadAllText(path1);
            foreach (string csvRow in ReadCSV1.Split("\n"))
            {
                if (!string.IsNullOrEmpty(csvRow))
                {
                    string[] csvCols = csvRow.Split(",");
                    RefTerm refTerm = new RefTerm();
                    refTerm.ReftermId = Guid.Parse(csvCols[0].ToString());
                    refTerm.Key = csvCols[1].ToString();
                    refTerm.Description = csvCols[2].ToString();
                    modelBuilder.Entity<RefTerm>().HasData(refTerm);
              
                }
            }

           /*
                                          SETREFTERM


*/
            /*string path2 = System.IO.Path.GetFullPath("./DbContexts/SetRefTerm.csv");*/
            string path2 = @"C:\Users\Manoj\source\repos\NoteBookAPI\NoteBookAPI\DbContexts\SetRefTerm.csv";
            string ReadCSV2 = File.ReadAllText(path2);
            foreach (string csvRow in ReadCSV2.Split("\n"))
            {
                if (!string.IsNullOrEmpty(csvRow))
                {
                    string[] csvCols = csvRow.Split(",");
                    SetRefTerm setRefTerm = new SetRefTerm();
                    setRefTerm.ReftermId = Guid.Parse(csvCols[0].ToString());
                    setRefTerm.RefSetid = Guid.Parse(csvCols[1].ToString());
                    setRefTerm.SetRefTermId = Guid.Parse(csvCols[2].ToString());
                    modelBuilder.Entity<SetRefTerm>().HasData(setRefTerm);
                }
            }
            base.OnModelCreating(modelBuilder);
        }



    }
}
