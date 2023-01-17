using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using NoteBookAPI.DbContexts;
using System.IO;
using NoteBookAPI.Entities;

namespace UnitTestForAddressBook.InMemoryContext
{
    public static class InMemorydbContext
    {
        /// <summary>
        /// This method is used to create the InMemeorydatabase
        /// </summary>
        public static UserDetailsContext userDetailsContext()
        {
            var options = new DbContextOptionsBuilder<UserDetailsContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            var context = new UserDetailsContext(options);

            context.Users.Add(new User()
            {
                Id = Guid.Parse("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                FirstName = "Sakthi",
                LastName = "Vel",
                password = "Hello@123",
                CreateBy = Guid.Parse("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                DateCreated = DateTime.Now,

                Address = new List<Address>() {
                new Address(){
                UserId = Guid.Parse("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                Id = Guid.Parse("859a0577-76ad-49ef-a111-346e4f978a88"),
                Line1 = "hello",
                Line2 = "solunga",
                City = "madurai",
                StateName = "tamilnadu",
                Zipcode = "625002",
                Type = Guid.Parse("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                Country = Guid.Parse("1f1f245d-c63b-42f6-b592-49b5b16bf861"),
                CreateBy = Guid.Parse("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                DateCreated = DateTime.Now
                        }
                },

                Emails=new List<Email>() {
                new Email(){
                    UserId = Guid.Parse("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                    Id = Guid.Parse("d019119e-245b-45d2-93df-b4cbbdfeac9f"),
                    EmailAddress = "itsmemano123@gmail.com",
                    TypeId = Guid.Parse("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                    CreateBy = Guid.Parse("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                    DateCreated = DateTime.Now
                }
                },

                Phones=new List<Phone>() {
                new Phone(){
                     UserId = Guid.Parse("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                     Id = Guid.Parse("00793011-a986-49f0-879b-86023edaff46"),
                     PhoneNumber = "8925250061",
                     TypeId = Guid.Parse("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                     CreateBy = Guid.Parse("f46f9dba-8a1c-4dd9-a8ea-c572a83be0be"),
                     DateCreated = DateTime.Now
                }
                }

            }) ;


            context.Users.Add(new User()
            {
                Id = Guid.Parse("68417748-6864-4866-8d9b-b82ae29da396"),
                FirstName = "Manoj",
                LastName = "Kumar",
                password = "Hello@321",
                CreateBy = Guid.Parse("68417748-6864-4866-8d9b-b82ae29da396"),
                DateCreated = DateTime.Now,

                Address = new List<Address>() {
                new Address(){
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
                },

                Emails = new List<Email>() {
                new Email(){
                    UserId = Guid.Parse("68417748-6864-4866-8d9b-b82ae29da396"),
                    Id = Guid.Parse("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                    EmailAddress = "itsmemano@gmail.com",
                    TypeId= Guid.Parse("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                    CreateBy = Guid.Parse("68417748-6864-4866-8d9b-b82ae29da396"),
                    DateCreated = DateTime.Now
                }
                },

                Phones = new List<Phone>() {
                new Phone(){
                    UserId = Guid.Parse("68417748-6864-4866-8d9b-b82ae29da396"),
                    Id = Guid.Parse("8c50f920-4b3a-4565-a8b6-0b635b429a98"),
                    PhoneNumber = "9488977667",
                    TypeId = Guid.Parse("abad70c5-11db-42f8-9e3a-487023f1b1cc"),
                    CreateBy = Guid.Parse("68417748-6864-4866-8d9b-b82ae29da396"),
                    DateCreated = DateTime.Now
                }
                }

            });




            string path = @"C:\Users\Manoj\source\repos\NoteBookAPI\NoteBookAPI\DbContexts\RefTerm.csv";
            string ReadCSV = File.ReadAllText(path);
            foreach (string csvRow in ReadCSV.Split("\n"))
            {
                if (!string.IsNullOrEmpty(csvRow))
                {
                    string[] csvCols = csvRow.Split(",");
                    RefSet refSet = new RefSet();
                    refSet.Id = Guid.Parse(csvCols[0].ToString());
                    refSet.Key = csvCols[1].ToString();
                    refSet.Description = csvCols[2].ToString();
                    refSet.CreateBy = new Guid("68417748-6864-4866-8d9b-b82ae29da396");
                    refSet.DateCreated = DateTime.Now;
                    context.RefSets.Add(refSet);
                }
            }
            string path1 = @"C:\Users\Manoj\source\repos\NoteBookAPI\NoteBookAPI\DbContexts\RefSet.csv";
            string ReadCSV1 = File.ReadAllText(path1);
            foreach (string csvRow in ReadCSV1.Split("\n"))
            {
                if (!string.IsNullOrEmpty(csvRow))
                {
                    string[] csvCols = csvRow.Split(",");
                    RefTerm refTerm = new RefTerm();
                    refTerm.Id = Guid.Parse(csvCols[1].ToString());
                    refTerm.Key = csvCols[0].ToString();
                    refTerm.Description = csvCols[2].ToString();
                    refTerm.CreateBy = new Guid("68417748-6864-4866-8d9b-b82ae29da396");
                    refTerm.DateCreated = DateTime.Now;
                    context.RefTerms.Add(refTerm);

                }
            }

            string path2 = @"C:\Users\Manoj\source\repos\NoteBookAPI\NoteBookAPI\DbContexts\SetRefTerm.csv";
            string ReadCSV2 = File.ReadAllText(path2);
            foreach (string csvRow in ReadCSV2.Split("\n"))
            {
                if (!string.IsNullOrEmpty(csvRow))
                {
                    string[] csvCols = csvRow.Split(",");
                    SetRefTerm setRefTerm = new SetRefTerm();
                    setRefTerm.RefSetid = Guid.Parse(csvCols[0].ToString());
                    setRefTerm.ReftermId = Guid.Parse(csvCols[1].ToString());
                    setRefTerm.Id = Guid.Parse(csvCols[2].ToString());
                    setRefTerm.CreateBy = new Guid("68417748-6864-4866-8d9b-b82ae29da396");
                    setRefTerm.DateCreated = DateTime.Now;
                    context.SetRefTerms.Add(setRefTerm);
                }
            }


            FileStream sourceImg = File.OpenRead(@"C:\Users\Manoj\source\repos\NoteBookAPI\NoteBookAPI\DbContexts\response.jpg");
            MemoryStream memoryStream = new MemoryStream();
            sourceImg.CopyToAsync(memoryStream);
            byte[] bytearr = memoryStream.ToArray();
            Asset assetdto = new Asset { Id = Guid.Parse("f98972b6-04e4-4577-b21c-946e96bef643"), File = Convert.ToBase64String(bytearr) };
            context.Assets.Add(assetdto);
            context.SaveChanges();
            return context;
        }
    }
}
