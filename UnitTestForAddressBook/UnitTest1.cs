using Xunit;
using NoteBookAPI.Controllers;
using NoteBookAPI.Services;
using NoteBookAPI.DbContexts;
using NoteBookAPI.Profiles;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using System;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using NoteBookAPI.Models;
using System.Collections.Generic;
using System.Linq;
using UnitTestForAddressBook.InMemoryContext;
using NoteBookAPI.Helper;
using Microsoft.AspNetCore.Http;
using System.IO;
using Moq;
using NoteBookAPI.Entities;

namespace UnitTestForAddressBook
{
    public class UnitTest1
    {

        UserController userController;
        MetaDataController metaDataController;
        FileController UploadDownloadController;
        LoginController loginController;
        UserDetailsContext context;
        IService service;
        IUserDetailRepository userDetailRepository;
        IMapper _mapper;
        private readonly IConfiguration configuration;
        ILogger logger;



        public UnitTest1()
        {
             configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            using var services = new ServiceCollection().AddSingleton<IConfiguration>(configuration).BuildServiceProvider();
            context = InMemorydbContext.userDetailsContext();
            IHostBuilder hostBuilder = Host.CreateDefaultBuilder().
            ConfigureLogging((builderContext, loggingBuilder) =>
            {
                loggingBuilder.AddConsole((options) =>
                {
                    options.IncludeScopes = true;
                });
            });
            IHost host = hostBuilder.Build();
            ILogger<UserController> logger = host.Services.GetRequiredService<ILogger<UserController>>();

            MapperConfiguration mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Automapper());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            _mapper = mapper;

            userDetailRepository = new UserDetailsRepository(context);
            service = new Service(userDetailRepository, _mapper, configuration);
            userController = new UserController(userDetailRepository, _mapper, service, logger);
            metaDataController = new MetaDataController(userDetailRepository, _mapper, service, logger);
            loginController = new LoginController(logger, userDetailRepository, mapper, configuration, service);
            UploadDownloadController = new FileController(userDetailRepository, mapper, service, logger);
        }

        [Fact]
        public void LoginUser()
        {
            LoginCredentialsDto loginCredentials = new LoginCredentialsDto()
            {
                EmailAddress = "itsmemano123@gmail.com",
                password = "Hello@123"
            };
            var response = loginController.UserLogin(loginCredentials);
            Assert.IsType<JsonResult>(response);
            LoginCredentialsDto loginCredentials1 = new LoginCredentialsDto()
            {
                EmailAddress = "itsmemano@gmail.com",
                password = "Hello@123"
            };
            response = loginController.UserLogin(loginCredentials1);
            Assert.IsType<ObjectResult>(response);

        }


        [Fact]
        public void ImageUpload()
        {
            Guid userId = new Guid("68417748-6864-4866-8d9b-b82ae29da396");
            string path = @"C:\Users\Manoj\source\repos\NoteBookAPI\NoteBookAPI\DbContexts\response.jpg";
            IFormFile File;
            using (var stream = System.IO.File.OpenRead(path))
            {
                File = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name));
                var response = UploadDownloadController.UploadFiles(userId, File);
                Assert.IsType<JsonResult>(response);
            };
        }


        [Fact]
        public void GetUserCount()
        {
            OkObjectResult response = userController.GetCount() as OkObjectResult;
            Assert.IsType<string>(response.Value);
            Assert.Equal("count:2", response.Value);
        }

        [Fact]
        public void GetAllUsers()
        {
            UserResourceParameter userResourceParameter = new UserResourceParameter()
            {
                PageNo = 2,
                PageSize = 2,
                OrderBy = "FirstName",
                OrderType = "ASC"
            };



            //PageNumberCheck
            var Response = userController.GetUsers(userResourceParameter);
            Assert.IsType<NotFoundObjectResult>(Response);

            //Validation
            userResourceParameter.PageNo = 1;
            Response = userController.GetUsers(userResourceParameter);
            Assert.IsType<OkObjectResult>(Response);

        }

        [Fact]
        public void ImageDownload()
        {
            Guid assetId = new Guid("f98972b6-04e4-4577-b21c-946e96bef643");
            var response = UploadDownloadController.DownloadFile(assetId.ToString());
            Assert.IsType<FileContentResult>(response);

        }

        [Fact]
        public void GetUser()
        {

            //Checking userId
            Guid userId = new Guid("68417748-6864-4866-8d9b-b82ae29da396");
            var Response = userController.GetUser(userId);
            Assert.IsType<OkObjectResult>(Response);

            //Checking random UserId
            userId = Guid.NewGuid();
            Response = userController.GetUser(userId);
            Assert.IsType<NotFoundObjectResult>(Response);

        }
        [Fact]
        public void RefsetData_Test()
        {
            string key = "PHONE_NUMBER_TYPE";
            ActionResult response = metaDataController.refSet(key) as ActionResult;
            Assert.IsType<JsonResult>(response);
            string key2 = "NAME_TYPE";
            ActionResult response2 = metaDataController.refSet(key2) as ActionResult;
            Assert.IsType<NotFoundResult>(response2);
        }


        [Fact]
        public void UpdateUserController()
        {
            UserUpdatingDto userUpdatingDto = new UserUpdatingDto()
            {
                FirstName = "Power",
                LastName = "Ranger",
                password = "Satkhi@321",
                Address = new List<AddressUpdatingDto>(),
                Emails = new List<EmailUpdatingDto>(),
                Phones = new List<PhoneUpdatingDto>()
            };
            userUpdatingDto.Address.Add(new AddressUpdatingDto()
            {
                Line1 = "182",
                Line2 = "sellur",
                City = "Madurai",
                StateName = "tamilnadu",
                Zipcode = "234234",
                Type = "PERSONAL",
                Country = "INDIA"
            });
            userUpdatingDto.Emails.Add(new EmailUpdatingDto()
            {
                EmailAddress = "itsme1233321@gmail.com",
                type = "PERSONAL",
            });
            userUpdatingDto.Phones.Add(new PhoneUpdatingDto()
            {
                PhoneNumber = "1234567891",
                type = "PERSONAL"
            });

            Guid userId = new Guid("68417748-6864-4866-8d9b-b82ae29da396");

            //updateResult
            var UpdateReturn = userController.UpdateUser(userId, userUpdatingDto);
            Assert.IsType<OkObjectResult>(UpdateReturn);

            //sameMailid
            userUpdatingDto.Emails.ToList()[0].type = "PERSONAL";
            userUpdatingDto.Phones.ToList()[0].type = "PERSONAL";
            userUpdatingDto.Address.ToList()[0].Type = "PERSONAL";
            userUpdatingDto.Address.ToList()[0].Country = "INDIA";
            UpdateReturn = userController.UpdateUser(userId, userUpdatingDto);
            Assert.IsType<ConflictObjectResult>(UpdateReturn);


            //MetaDataWrong
            userUpdatingDto.Emails.ToList()[0].EmailAddress = "emailcheck@gmail.com";
            userUpdatingDto.Emails.ToList()[0].type = "PERSONA";
            UpdateReturn = userController.UpdateUser(userId, userUpdatingDto);
            Assert.IsType<NotFoundObjectResult>(UpdateReturn);


            //NotValidPassword
            userUpdatingDto.password = "1234";
            userUpdatingDto.Emails.ToList()[0].EmailAddress = "emailcheck1@gmail.com";
            userUpdatingDto.Emails.ToList()[0].type = "PERSONAL";
            userUpdatingDto.Phones.ToList()[0].type = "PERSONAL";
            userUpdatingDto.Address.ToList()[0].Type = "PERSONAL";
            userUpdatingDto.Address.ToList()[0].Country = "INDIA";
            UpdateReturn = userController.UpdateUser(userId, userUpdatingDto);
            Assert.IsType<BadRequestResult>(UpdateReturn);



            //Wrong userId
            userId = Guid.NewGuid();
            UpdateReturn = userController.UpdateUser(userId, userUpdatingDto);
            Assert.IsType<NotFoundObjectResult>(UpdateReturn);

        }



        [Fact]
        public void CreateUser()
        {
            UserCreatingDto userCreatingDto = new UserCreatingDto()
            {
                FirstName = "Power",
                LastName = "Ranger",
                password = "Satkhi@321",
                Address = new List<AddressCreatingDto>(),
                Emails = new List<EmailCreatingDto>(),
                Phones = new List<PhoneCreatingDto>()
            };
            userCreatingDto.Address.Add(new AddressCreatingDto()
            {
                Line1 = "182",
                Line2 = "sellur",
                City = "Madurai",
                StateName = "tamilnadu",
                Zipcode = "234234",
                Type = "PERSONAL",
                Country = "INDIA"
            });
            userCreatingDto.Emails.Add(new EmailCreatingDto()
            {
                EmailAddress = "itsme1233321@gmail.com",
                type = "PERSONAL",
            });
            userCreatingDto.Phones.Add(new PhoneCreatingDto()
            {
                PhoneNumber = "1234567891",
                type = "PERSONAL"
            });

            var CreateResponse = userController.CreateUser(userCreatingDto);
            Assert.IsType<ObjectResult>(CreateResponse);
            Assert.Equal(201, (CreateResponse as ObjectResult).StatusCode);

            Guid id = new Guid((CreateResponse as ObjectResult).Value.ToString());
            Assert.IsType<Guid>(id);
        }


    }
}
