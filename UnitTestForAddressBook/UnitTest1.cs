using Xunit;
using NoteBookAPI.Controllers;
using NoteBookAPI.DbContexts;
using NoteBookAPI.Profiles;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.AspNetCore.Mvc;
using NoteBookAPI.Models;
using System.Collections.Generic;
using System.Linq;
using UnitTestForAddressBook.InMemoryContext;
using Microsoft.AspNetCore.Http;
using System.IO;
using NoteBookAPI.Services;
using NoteBookAPI.Contracts;
using NoteBookAPI.Repositories;
using System.Security.Claims;


namespace UnitTestForAddressBook
{
    public class UnitTest1
    {
        UserController UserController;
        MetaDataController MetaDataController;
        FileController FileController;
        LoginController loginController;
        UserDetailsContext context;
        IUserServices UserService;
        IMetaDataServices MetaDataService;
        ILoginServices LoginService;
        IFileServices FileService;
        IUserDetailRepositories userDetailRepository;
        ILoginRepositories loginRepository;
        IMetaDataRepositories metaDataRepository;
        IFileRepositories fileRepository;
        IMapper _mapper;
        private readonly IConfiguration configuration;
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
            userDetailRepository = new UserDetailsRepositories(context);
            metaDataRepository = new MetaDataRepositories(context);
            loginRepository = new LoginRepositories(context);
            fileRepository = new FileRepositories(context);
            UserService = new UserServices(userDetailRepository, _mapper,logger);
            MetaDataService = new MetaDataServices(metaDataRepository, _mapper, configuration);
            LoginService = new LoginServices(loginRepository, _mapper, configuration);
            FileService = new FileServices(fileRepository, _mapper, configuration);
            UserController = new UserController( _mapper, UserService, logger);
            MetaDataController = new MetaDataController( MetaDataService, logger);
            loginController = new LoginController(logger, configuration, LoginService);
            FileController = new FileController( mapper, FileService, logger);
        }
        [Fact]
        public void GetUser_Ok()
        {
            //Checking userId
            Guid userId = new Guid("68417748-6864-4866-8d9b-b82ae29da396");
            var Response = UserController.GetUser(userId);
            Assert.IsType<OkObjectResult>(Response);
        }
        [Fact]
        public void GetUser_NotFound()
        {
            //Checking userId
            Guid userId = new Guid("68417748-6864-4866-8d9b-b82ae29da391");
            var Response = UserController.GetUser(userId);
            Assert.Equal(404, (Response as ObjectResult).StatusCode);
        }
        [Fact]
        public void CreateUser_Created()
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
                EmailAddress = "Hello@gmail.com",
                type = "PERSONAL",
            });
            userCreatingDto.Phones.Add(new PhoneCreatingDto()
            {
                PhoneNumber = "1234567891",
                type = "PERSONAL"
            });
            //create claims
            Guid userId = new Guid("68417748-6864-4866-8d9b-b82ae29da396");
            ClaimsPrincipal user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] {
                                        new Claim(ClaimTypes.NameIdentifier,userId.ToString())
                                        // other required and custom claims
                           }, "TestAuthentication"));
            //Adding Claims
            UserController.ControllerContext = new ControllerContext();
            UserController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            IActionResult CreateResponse = UserController.CreateUser(userCreatingDto);
            Assert.IsType<ObjectResult>(CreateResponse);
            Assert.Equal(201, (CreateResponse as ObjectResult).StatusCode);
            Guid id = new Guid((CreateResponse as ObjectResult).Value.ToString());
            Assert.IsType<Guid>(id);
        }
        [Fact]
        public void CreateUser_Conflict()
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
                EmailAddress = "itsmemano123@gmail.com",
                type = "PERSONAL",
            });
            userCreatingDto.Phones.Add(new PhoneCreatingDto()
            {
                PhoneNumber = "1234567891",
                type = "PERSONAL"
            });
            //create claims
            Guid userId = new Guid("68417748-6864-4866-8d9b-b82ae29da396");
            ClaimsPrincipal user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] {
                                        new Claim(ClaimTypes.NameIdentifier,userId.ToString())
                                        // other required and custom claims
                           }, "TestAuthentication"));
            //Adding Claims
            UserController.ControllerContext = new ControllerContext();
            UserController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            IActionResult CreateResponse = UserController.CreateUser(userCreatingDto);
            Assert.IsType<ObjectResult>(CreateResponse);
            Assert.Equal(409, (CreateResponse as ObjectResult).StatusCode);
         
        }
        [Fact]
        public void CreateUser_NotFound()
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
                EmailAddress = "itsme@gmail.com",
                type = "PERSONAL",
            });
            userCreatingDto.Phones.Add(new PhoneCreatingDto()
            {
                PhoneNumber = "1234567891",
                type = "PERSONA"
            });
            //create claims
            Guid userId = new Guid("68417748-6864-4866-8d9b-b82ae29da396");
            ClaimsPrincipal user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] {
                                        new Claim(ClaimTypes.NameIdentifier,userId.ToString())
                                        // other required and custom claims
                           }, "TestAuthentication"));
            //Adding Claims
            UserController.ControllerContext = new ControllerContext();
            UserController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            IActionResult CreateResponse = UserController.CreateUser(userCreatingDto);
            Assert.IsType<ObjectResult>(CreateResponse);
            Assert.Equal(404, (CreateResponse as ObjectResult).StatusCode);
           
        }

        [Fact]
        public void LoginUser()
        {
            LoginCredentialsDto loginCredentials = new LoginCredentialsDto()
            {
                EmailAddress = "itsmemano123@gmail.com",
                password = "Hello@123"
            };
            IActionResult response = loginController.UserLogin(loginCredentials);
            Assert.IsType<JsonResult>(response);


        }
        [Fact]
        public void LoginUser_NotAuthorized()
        {

            LoginCredentialsDto loginCredentials1 = new LoginCredentialsDto()
            {
                EmailAddress = "itsmemano@gmail.com",
                password = "Hello@123"
            };
            IActionResult response = loginController.UserLogin(loginCredentials1);
            Assert.Equal(401, (response as ObjectResult).StatusCode);


        }

        [Fact]
        public void ImageUpload()
        {
            Guid userId = new Guid("68417748-6864-4866-8d9b-b82ae29da396");
            string path = @"C:\Users\Manoj\source\repos\NoteBookAPI\NoteBookAPI\DbContexts\response.jpg";
            IFormFile File;
            //create claims
            ClaimsPrincipal user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] {
                                        new Claim(ClaimTypes.NameIdentifier,userId.ToString())
                                        // other required and custom claims
                           }, "TestAuthentication"));
            //Adding Claims
            FileController.ControllerContext = new ControllerContext();
            FileController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            using (FileStream stream = System.IO.File.OpenRead(path))
            {
                File = new FormFile(stream, 0, stream.Length, null, Path.GetFileName(stream.Name));
                IActionResult response = FileController.UploadFiles(userId, File);
                Assert.IsType<JsonResult>(response);
            };
        }


        [Fact]
        public void GetUserCount()
        {
            OkObjectResult response = UserController.GetCount() as OkObjectResult;
            Assert.IsType<string>(response.Value);
            Assert.Equal("count:2", response.Value);
        }

        [Fact]
        public void GetAllUsers()
        {
            IActionResult Response = UserController.GetUsers(1,2,"FirstName","ASC");
            Assert.IsType<OkObjectResult>(Response);
        }

        [Fact]
        public void ImageDownload_Ok()
        {
            Guid assetId = new Guid("f98972b6-04e4-4577-b21c-946e96bef643");
            IActionResult response = FileController.DownloadFile(assetId.ToString());
            Assert.IsType<FileContentResult>(response);
        }
        [Fact]
        public void ImageDownload_NotFound()
        {
            
            IActionResult response = FileController.DownloadFile(null);
            Assert.Equal(404, (response as ObjectResult).StatusCode);
        }


        [Fact]
        public void RefsetData_Test_Ok()
        {
            string key = "PHONE_NUMBER_TYPE";
            IActionResult response = MetaDataController.RefSet(key);
            Assert.IsType<OkObjectResult>(response);
            Assert.Equal(200, (response as ObjectResult).StatusCode);  
        }

        [Fact]
        public void RefsetData_Test_NotFound()
        {
            string key2 = "_TYPE";
            IActionResult response2 = MetaDataController.RefSet(key2);
            Assert.Equal(404, (response2 as ObjectResult).StatusCode);
        }


        [Fact]
        public void UpdateUserController_Ok()
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
            //create claims
            ClaimsPrincipal user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] {
                                        new Claim(ClaimTypes.NameIdentifier,userId.ToString())
                                        // other required and custom claims
                           }, "TestAuthentication"));
            //Adding Claims
            UserController.ControllerContext = new ControllerContext();
            UserController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            //updateResult
            IActionResult UpdateReturn = UserController.UpdateUser(userId, userUpdatingDto);
            Assert.IsType<OkObjectResult>(UpdateReturn);
            Assert.Equal(200, (UpdateReturn as ObjectResult).StatusCode);


        }
        [Fact]
        public void UpdateUserController_Conflict()
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
                EmailAddress = "itsmemano123@gmail.com",
                type = "PERSONAL",
            });
            userUpdatingDto.Phones.Add(new PhoneUpdatingDto()
            {
                PhoneNumber = "1234567891",
                type = "PERSONAL"
            });
            Guid userId = new Guid("68417748-6864-4866-8d9b-b82ae29da396");
            //create claims
            ClaimsPrincipal user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] {
                                        new Claim(ClaimTypes.NameIdentifier,userId.ToString())
                                        // other required and custom claims
                           }, "TestAuthentication"));
            //Adding Claims
            UserController.ControllerContext = new ControllerContext();
            UserController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            //updateResult
            IActionResult UpdateReturn = UserController.UpdateUser(userId, userUpdatingDto);
            Assert.Equal(409, (UpdateReturn as ObjectResult).StatusCode);


        }
        [Fact]
        public void UpdateUserController_Notfound()
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
            //create claims
            ClaimsPrincipal user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] {
                                        new Claim(ClaimTypes.NameIdentifier,userId.ToString())
                                        // other required and custom claims
                           }, "TestAuthentication"));
            //Adding Claims
            UserController.ControllerContext = new ControllerContext();
            UserController.ControllerContext.HttpContext = new DefaultHttpContext { User = user };
            //Wrong userId
            userId = Guid.NewGuid();
            userUpdatingDto.Emails.ToList()[0].EmailAddress = "emailcheck1@gmail.com";
            userUpdatingDto.Emails.ToList()[0].type = "PERSONAL";
            userUpdatingDto.Phones.ToList()[0].type = "PERSONAL";
            userUpdatingDto.Address.ToList()[0].Type = "PERSONAL";
            userUpdatingDto.Address.ToList()[0].Country = "INDIA";
            IActionResult UpdateReturn = UserController.UpdateUser(userId, userUpdatingDto);
            Assert.Equal(404, (UpdateReturn as ObjectResult).StatusCode);

        }



        [Fact]
        public void DeleteUser_Ok() {
            Guid userId = new Guid("68417748-6864-4866-8d9b-b82ae29da396");
            IActionResult response = UserController.DeleteUser(userId);
            Assert.Equal(200, (response as ObjectResult).StatusCode);
        }

        [Fact]
        public void DeleteUser_NotFound()
        {
            Guid userId = new Guid("68417748-6864-4866-8d9b-b82ae29da391");
            IActionResult response = UserController.DeleteUser(userId);
            Assert.Equal(404, (response as ObjectResult).StatusCode);
        }


    }
}
