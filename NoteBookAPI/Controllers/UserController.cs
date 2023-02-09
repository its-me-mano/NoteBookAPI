using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteBookAPI.Models;
using NoteBookAPI.Services;
using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using NoteBookAPI.Helper;
using NoteBookAPI.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using NoteBookAPI.Entities.Dto;

namespace NoteBookAPI.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserServices _service;
        private readonly ILogger _logger;
        public UserController( IMapper mapper, IUserServices service, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _service = service ?? throw new ArgumentException(nameof(mapper));
            _logger = logger ?? throw new ArgumentException(nameof(logger));
        }
        /// <summary>
        /// Get All Users
        /// </summary>
        /// <remarks>To get all the address book stored in the database</remarks>
        /// <param name="userResourceParameter"></param>
        /// <response code="200">All the address book fetched successfully</response>
        /// <response code="400">The user input is not valid.</response>
        /// <response code="401">The user is not authorized.</response>
        [Authorize]
        [SwaggerOperation("GetAllUser")]
        [SwaggerResponse(statusCode: 200, "All the address book fetched successfully")]
        [SwaggerResponse(statusCode: 401, "The user  is not authorized", typeof(ErrorDto))]
        [SwaggerResponse(statusCode: 400, "The user input is not valid", typeof(ErrorDto))]
        [HttpHead]
        [HttpGet(Name = "GetAllUser")]
        public IActionResult GetUsers([Required][FromQuery(Name ="page-no")] int PageNo, [FromQuery(Name = "page-size")] int PageSize, [FromQuery(Name = "order-type")] string OrderType, [FromQuery(Name = "order-by")] string OrderBy)
        {
            UserResourceParameter userResourceParameter = new UserResourceParameter() {
                PageNo = PageNo,
                PageSize=PageSize,
                OrderBy=OrderBy,
                OrderType=OrderType
            };
            _logger.LogInformation("Fetching all addressBook initiated");
            PageList<User> items = _service.GetUsers(userResourceParameter);  
            items = _service.AppendingValues(items);
            _logger.LogInformation("AddressBook gathered Successfully");
            return Ok(_mapper.Map<IEnumerable<UserDto>>(items));
        }
        /// <summary>
        /// Get Count of Users
        /// </summary>
        /// <remarks>To get the total count of all address book stored in the database</remarks>
        /// <response code="200">Users count fected successfully</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="401">The user is not authorized.</response>
        [SwaggerOperation("GetCount")]
        [SwaggerResponse(statusCode: 200, "Users count fected successfully")]
        [SwaggerResponse(statusCode: 401, "The user is not authorized",typeof(ErrorDto))]
        [SwaggerResponse(statusCode: 500, "Internal Server Error", typeof(ErrorDto))]
        [Authorize]
        [HttpGet("count")]
        public IActionResult GetCount()
        {
            int count = _service.GetCount();
            _logger.LogInformation($"AddressBook count is {count}");
            return Ok($"count:{count}");
        }
        /// <summary>
        /// Get particular user details
        /// </summary>
        /// <remarks>To get an address book details stored in the database</remarks>
        /// <param name="userId"></param>
        /// <response code="200">Fetched the particular user</response>
        /// <response code="404">NotFound</response>
        /// <response code="401">The user is not authorized.</response>
        /// <response code="500">Internal Server Error</response>
        [SwaggerOperation("GetUser")]
        [SwaggerResponse(statusCode: 200, "Fetched the particular user")]
        [SwaggerResponse(statusCode: 401, "The user is not authorized", typeof(ErrorDto))]
        [SwaggerResponse(statusCode:404,"The user  is not found", typeof(ErrorDto))]
        [SwaggerResponse(statusCode: 500, "Internal Server Error", typeof(ErrorDto))]
        [Authorize]
        [HttpGet("{user-Id}", Name = "GetUser")]
        public IActionResult GetUser([FromRoute(Name = "user-Id")][Required] Guid userId)
        {
            _logger.LogInformation("Fetch the user initiated");
            if (!_service.UserExists(userId))
            {
                User userFromRepo = _service.AppendingValueForUser(userId);
                _logger.LogInformation("AddressBook feteched");
                return Ok(_mapper.Map<UserDto>(userFromRepo));
            }
            else {
                _logger.LogError("UserId not found");
                return StatusCode(404,_service.ErrorToReturn("404","Check the userId"));
            }
        }
        /// <summary>
        /// Delete The User
        /// </summary>
        /// <remarks>To get an address book details stored in the database</remarks>
        /// <param name="userId"></param>
        /// <response code="200">Deleted Successfully</response>
        /// <response code="404">NotFound</response>
        /// <response code="401">The user is not authorized.</response>
        /// <response code="500">Internal Server Error</response>
        [SwaggerOperation("DeleteUser")]
        [SwaggerResponse(statusCode: 200, "Deleted Successfully")]
        [SwaggerResponse(statusCode: 401, "The user is not authorized", typeof(ErrorDto))]
        [SwaggerResponse(statusCode:404,"The user is not found", typeof(ErrorDto))]
        [SwaggerResponse(statusCode: 500, "Internal Server Error", typeof(ErrorDto))]
        [Authorize]
        [HttpDelete("{user-Id}")]
        public IActionResult DeleteUser([FromRoute(Name="user-Id")][Required] Guid userId)
        {
            _logger.LogInformation("Delete user process initiated");
            if (_service.UserExists(userId))
            {
                _logger.LogError("UserId not found");
                return StatusCode(404, _service.ErrorToReturn("404", "UserId not found"));
            }
            User userFromRepo = _service.GetUser(userId);    
            if (userFromRepo == null)
            {
                _logger.LogError("User data is null");
                return StatusCode(404, _service.ErrorToReturn("404", "User data is empty"));
            }
            _service.DeleteUser(userFromRepo);
            _logger.LogInformation("Userbook deleted successfully");
            return StatusCode(200, "Address book deleted successfully");
        }
        /// <summary>
        ///Create the user
        /// </summary>
        /// <remarks>Create address book with first name, last name and their communication details</remarks>
        /// <param name="user"></param>
        /// <response code="200">User created successsfully</response>
        /// <response code="401">The user is not authorized.</response>
        /// <response code="404">MetaData is does not exist</response>
        /// <response code="409">Email address or phone number already exist</response>
        /// <response code="500">Internal Server Error</response>
        [SwaggerOperation("CreaterUser")]
        [SwaggerResponse(statusCode: 201,"User created successsfully")]
        [SwaggerResponse(statusCode: 401, "The user is not authorized", typeof(ErrorDto))]
        [SwaggerResponse(statusCode: 404, "MetaData does not exist", typeof(ErrorDto))]
        [SwaggerResponse(statusCode: 409, "Email address or phone number already exist", typeof(ErrorDto))]
        [SwaggerResponse(statusCode: 500, "Internal Server Error", typeof(ErrorDto))]
        [Authorize]
        [HttpPost]
        public IActionResult CreateUser([Required][FromBody] UserCreatingDto user)
        {
            Guid loginUserId = new Guid(_service.GetLoggedId(User));
            _logger.LogInformation("adding address_book is initiated");
            ReturnCreateStatus returnCreate = new ReturnCreateStatus();
            returnCreate = _service.CreateTheUser(user, loginUserId);
            if (returnCreate.status==200)
            {
                UserDto userToReturn=_service.SaveCreateUser(user,loginUserId);
                _logger.LogInformation("New addressBook created successfully");
                return StatusCode(201, $"{userToReturn.Id}");
            }
            else {
                return StatusCode(returnCreate.status, _service.ErrorToReturn(Convert.ToString(returnCreate.status),returnCreate.description));
            }
        }


        /// <summary>
        ///Update the user
        /// </summary>
        /// <remarks>To update the existing address book details like first name, last name and their communication details</remarks>
        /// <param name="userId"></param>
        /// <param name="user"></param>
        /// <response code="200">User updated successfully</response>
        /// <response code="404">MetaData is not found</response>
        /// <response code="401">The user is not authorized.</response>
        /// <response code="409">Email address or phone number already exist</response>
        /// <response code="500">Internal Server Error</response>
        [SwaggerOperation("UpdateUser")]
        [SwaggerResponse(statusCode: 201, "User Updated Successfully")]
        [SwaggerResponse(statusCode: 404, "MetaData is not found", typeof(ErrorDto))]
        [SwaggerResponse(statusCode: 401, "The user is not authorized", typeof(ErrorDto))]
        [SwaggerResponse(statusCode: 409, "Email address or phone number already exist", typeof(ErrorDto))]
        [SwaggerResponse(statusCode: 500, "Internal Server Error", typeof(ErrorDto))]
        [Authorize]
        [HttpPut("{user-Id}")]
        public IActionResult UpdateUser([FromRoute(Name ="user-Id")][Required]Guid userId, [FromBody] UserUpdatingDto user)
        {
            _logger.LogInformation("UpdateUser has beed initiated");
            Guid loginUserId = new Guid(_service.GetLoggedId(User));
            if (_service.UserExists(userId))
            {
                _logger.LogError("UserID does not exist");
                return StatusCode(404, _service.ErrorToReturn("404", "UserId doest not exist"));
            }
            ReturnUpdateStatus returnUpdate = new ReturnUpdateStatus();
            returnUpdate= _service.UpdateTheUser(user, loginUserId);
            if (returnUpdate.status == 200)
            {         
                User userFromRepo = _service.GetUser(userId);
                if (userFromRepo == null)
                {
                    _logger.LogError("User does not exist");
                    return StatusCode(404, _service.ErrorToReturn("404", "User does not exist"));
                }
                _service.AppendingValueForUpdate(userFromRepo,userId,user,loginUserId);
                _logger.LogInformation("Addressbook updated successfully");
                return Ok("Updated successfully");
            }
            else {
                return StatusCode(returnUpdate.status, _service.ErrorToReturn(Convert.ToString(returnUpdate.status), returnUpdate.description));
            }
        }
        }
}

