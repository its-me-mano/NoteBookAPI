using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteBookAPI.Models;
using NoteBookAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using NoteBookAPI.Helper;
using NoteBookAPI.Entities;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using NoteBookAPI.Entities.Dto;
using System.Security.Claims;

namespace NoteBookAPI.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class UserController : ControllerBase
    {
        private readonly IUserDetailRepository _userDetailRepositary;
        private readonly IMapper _mapper;
        private readonly IService _service;
        private readonly ILogger _logger;


        public UserController(IUserDetailRepository UserDetailRepositary, IMapper mapper, IService service,ILogger logger)
        {
            _userDetailRepositary = UserDetailRepositary ?? throw new ArgumentNullException(nameof(UserDetailRepositary));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _service = service ?? throw new ArgumentException(nameof(mapper));
            _logger = logger ?? throw new ArgumentException(nameof(logger));

        }


        /// <summary>
        /// Get All Address Book API
        /// </summary>
        /// <remarks>To get all the address book stored in the database</remarks>
        /// <param name="userResourceParameter"></param>
        /// <response code="200">Success</response>
        /// <response code="404">NotFound</response>
        /// <response code="400">The user input is not valid.</response>
        /// <response code="401">The user is not authorized.</response>
        [Authorize]
        [SwaggerOperation("GetAllUser")]
        [SwaggerResponse(statusCode: 200, "Success")]
        [SwaggerResponse(statusCode: 401, "The user input is not authorized")]
        [SwaggerResponse(statusCode: 404, "NotFound")]
        [SwaggerResponse(statusCode: 400, "The user input is not valid")]
        [HttpHead]
        [HttpGet(Name = "GetAllUser")]
        public IActionResult GetUsers([Required][FromQuery] UserResourceParameter userResourceParameter)
        {
            _logger.LogInformation("Fetching all addressBook initiated");
            if (_service.checkPageNumberLimit(userResourceParameter.PageSize, userResourceParameter.PageNo)) {
                _logger.LogInformation("There is no pageNumber");
                return NotFound($"There is no PageNumber {userResourceParameter.PageNo}");
            }
            PageList<User> items = _userDetailRepositary.GetUsers(userResourceParameter);
            items = _service.AppendingValues(items);
            _logger.LogInformation("AddressBook gathered Successfully");
            return Ok(_mapper.Map<IEnumerable<UserDto>>(items));
        }



        /// <summary>
        /// Get Count Address Book API
        /// </summary>
        /// <remarks>To get the total count of all address book stored in the database</remarks>
        /// <response code="200">Success.</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="401">The user is not authorized.</response>
        [SwaggerOperation("GetCount")]
        [SwaggerResponse(statusCode: 200, "Success!")]
        [SwaggerResponse(statusCode: 401, "The user input is not authorized")]
        [SwaggerResponse(statusCode: 500, "Internal Server Error")]
        [Authorize]
        [HttpGet("count")]
        public IActionResult GetCount()
        {
            GetCountDto getCountDto = new GetCountDto();
            getCountDto.count= _userDetailRepositary.GetCount();
            _logger.LogInformation($"AddressBook count is {getCountDto.count}");
            return Ok($"count:{getCountDto.count}");
        }


        /// <summary>
        /// Get Address Book API
        /// </summary>
        /// <remarks>To get an address book details stored in the database</remarks>
        /// <param name="userId"></param>
        /// <response code="200">Success</response>
        /// <response code="404">NotFound</response>
        /// <response code="400">The user input is not valid.</response>
        /// <response code="401">The user is not authorized.</response>
        /// <response code="500">Internal Server Error</response>
        [SwaggerOperation("GetUser")]
        [SwaggerResponse(statusCode: 200, "Success!")]
        [SwaggerResponse(statusCode: 400, "The user input is not valid")]
        [SwaggerResponse(statusCode: 401, "The user is not authorized")]
        [SwaggerResponse(statusCode:404,"The user  is not found")]
        [SwaggerResponse(statusCode: 500, "Internal Server Error")]
        [Authorize]
        [HttpGet("{user-Id}", Name = "GetUser")]
        public IActionResult GetUser([FromRoute(Name = "user-Id")][Required] Guid userId)
        {
            _logger.LogInformation("Fetch the user initiated");
            if (_userDetailRepositary.UserExits(userId))
            {
                User UserFromRepo = _service.AppendingValueForUser(userId);
                _logger.LogInformation("AddressBook feteched");
                return Ok(_mapper.Map<UserDto>(UserFromRepo));
            }
            else {
                _logger.LogInformation("UserId not found");
                return NotFound("Check the userId");
            }
        }

        /// <summary>
        /// Delete Address Book API
        /// </summary>
        /// <remarks>To get an address book details stored in the database</remarks>
        /// <param name="userId"></param>
        /// <response code="200">Success</response>
        /// <response code="400">The user input is not valid.</response>
        /// <response code="404">NotFound</response>
        /// <response code="401">The user is not authorized.</response>
        /// <response code="500">Internal Server Error</response>
        [SwaggerOperation("DeleteUser")]
        [SwaggerResponse(statusCode: 200, "Success!")]
        [SwaggerResponse(statusCode: 400, "The user input is not valid")]
        [SwaggerResponse(statusCode: 401, "The user is not authorized")]
        [SwaggerResponse(statusCode:404,"The user is not found")]
        [SwaggerResponse(statusCode: 500, "Internal Server Error")]
        [Authorize]
        [HttpDelete("{user-Id}")]
        public IActionResult DeleteUser([FromRoute(Name = "user-Id")][Required] Guid userId)
        {
            _logger.LogInformation("Delete user process initiated");
            if (!_userDetailRepositary.UserExits(userId))
            {
                _logger.LogInformation("UserId not found");
                return NotFound();
            }
            User userFromRepo = _userDetailRepositary.GetUser(userId);
            if (userFromRepo == null)
            {
                _logger.LogInformation("User data is null");
                return NotFound();
            }
            _userDetailRepositary.DeleteUser(userFromRepo);
            _userDetailRepositary.Save();
            _logger.LogInformation("Userbook deleted successfully");
            return StatusCode(200, "Address book deleted successfully");
        }
        
        /// <summary>
        ///Create Address Book API
        /// </summary>
        /// <remarks>Create address book with first name, last name and their communication details</remarks>
        /// <param name="user"></param>
        /// <response code="200">Floor layout image and tab file info returned successfully</response>
        /// <response code="400">The user input is not valid.</response>
        /// <response code="401">The user is not authorized.</response>
        /// <response code="404">MetaData is not found</response>
        /// <response code="409">Email address or phone number already exist</response>
        /// <response code="500">Internal Server Error</response>
        [SwaggerOperation("CreaterUser")]
        [SwaggerResponse(statusCode: 201,"Success!")]
        [SwaggerResponse(statusCode: 400, "The user input is not valid")]
        [SwaggerResponse(statusCode: 401, "The user is not authorized")]
        [SwaggerResponse(statusCode: 404, "MetaData is not found")]
        [SwaggerResponse(statusCode: 409, "Email address or phone number already exist")]
        [SwaggerResponse(statusCode: 500, "Internal Server Error")]
        [Authorize]
        [HttpPost]
        public IActionResult CreateUser([Required][FromBody] UserCreatingDto user)
        {
            Guid LoggedUserId = new Guid(_service.GetLoggedId(User));
            _logger.LogInformation("adding address_book is initiated");
            if (_service.IsPasswordValid(user.password))
            {
                foreach (EmailCreatingDto item in user.Emails)
                {
                    if (!_userDetailRepositary.metaExist(item.type))
                    {
                        _logger.LogError("Email type is not exist");
                        return NotFound("Email type is not exist");
                    }
                    if (_userDetailRepositary.EmailExist(item.EmailAddress))
                    {
                        _logger.LogError("Email is already exist");
                        return Conflict("Email is already exist");
                    }
                    item.type = _service.RefTermKeyToGuidString(item.type);
                    item.CreateBy = LoggedUserId;
                    item.DateCreated = DateTime.Now;
                }
                foreach (PhoneCreatingDto item in user.Phones)
                {
                    if (!_userDetailRepositary.metaExist(item.type))
                    {
                        _logger.LogError("Phone number type is not exist");
                        return NotFound("Phone number type is not exist");
                    }
                    item.type = _service.RefTermKeyToGuidString(item.type);
                    item.CreateBy = LoggedUserId;
                    item.DateCreated = DateTime.Now;
                }
                foreach (AddressCreatingDto item in user.Address)
                {
                    if (!_userDetailRepositary.metaExist(item.Country))
                    {
                        _logger.LogError($"Countrytype is not exist{item.Country}");
                        return NotFound($"Countrytype is not exist{item.Country}");
                    }
                    if (!_userDetailRepositary.metaExist(item.Type))
                    {
                        _logger.LogError("Addresstype is not exist");

                        return NotFound("Addresstype is not exist");
                    }

                    item.Type = _service.RefTermKeyToGuidString(item.Type);
                    item.Country = _service.RefTermKeyToGuidString(item.Country);
                    item.CreateBy = LoggedUserId;
                    item.DateCreated = DateTime.Now;

                }
                user.CreateBy = LoggedUserId;
                user.DateCreated = DateTime.Now;

                User userEntity = _mapper.Map<User>(user);
                
                _userDetailRepositary.AddUser(userEntity);
                _userDetailRepositary.Save();

                UserDto userToReturn = _mapper.Map<UserDto>(userEntity);
                _logger.LogInformation("New addressBook created successfully");
                return StatusCode(201, $"{userToReturn.Id}");

            }
            else
            {
                return BadRequest();
            }

        }

        /// <summary>
        ///Update Address Book API
        /// </summary>
        /// <remarks>To update the existing address book details like first name, last name and their communication details</remarks>
        /// <param name="userId"></param>
        /// <param name="user"></param>
        /// <response code="200">Floor layout image and tab file info returned successfully</response>
        /// <response code="400">The user input is not valid.</response>
        /// <response code="404">MetaData is not found</response>
        /// <response code="401">The user is not authorized.</response>
        /// <response code="409">Email address or phone number already exist</response>
        /// <response code="500">Internal Server Error</response>
        [SwaggerOperation("UpdateUser")]
        [SwaggerResponse(statusCode: 201, "Success!")]
        [SwaggerResponse(statusCode: 400, "The user input is not valid")]
        [SwaggerResponse(statusCode: 404, "MetaData is not found")]
        [SwaggerResponse(statusCode: 401, "The user is not authorized")]
        [SwaggerResponse(statusCode: 409, "Email address or phone number already exist")]
        [SwaggerResponse(statusCode: 500, "Internal Server Error")]
        [Authorize]
        [HttpPut("{user-Id}")]
        public IActionResult UpdateUser([FromRoute(Name ="user-Id")][Required]Guid userId, [FromBody] UserUpdatingDto user)
        {
            _logger.LogInformation("UpdateUser has beed initiated");
            Guid LoggedUserId = new Guid(_service.GetLoggedId(User));

            if (!_userDetailRepositary.UserExits(userId))
            {
                _logger.LogInformation("UserID is not existed");
                return NotFound("userId is not existed");
            }
            if (_service.IsPasswordValid(user.password))
            {

                foreach (EmailUpdatingDto item in user.Emails)
                {
                    if (_userDetailRepositary.EmailExist(item.EmailAddress))
                    {
                        _logger.LogInformation("Email is already existed");
                        return Conflict("Email is already exist");
                    }
                    if (!_userDetailRepositary.metaExist(item.type))
                    {
                        _logger.LogInformation("Email type is not existed");
                        return NotFound("Email type is not exist");
                    }

                    item.type = (_userDetailRepositary.TypeFinder(item.type)).Id.ToString();
                    item.UpdateBy = LoggedUserId;
                    item.DateUpdated = DateTime.Now;
                }

                foreach (PhoneUpdatingDto item in user.Phones)
                {
                    if (!_userDetailRepositary.metaExist(item.type))
                    {
                        _logger.LogInformation("Phone number type  is not existed");
                        return NotFound("Phone number type is not exist");
                    }
                    item.type = (_userDetailRepositary.TypeFinder(item.type)).Id.ToString();
                    item.UpdateBy = LoggedUserId;
                    item.DateUpdated = DateTime.Now;

                }

                foreach (AddressUpdatingDto item in user.Address)
                {
                    if (!_userDetailRepositary.metaExist(item.Country))
                    {
                        _logger.LogInformation($"Countrytype is not exist{item.Country}");
                        return NotFound($"Countrytype is not exist{item.Country}");
                    }
                    if (!_userDetailRepositary.metaExist(item.Type))
                    {
                        _logger.LogInformation($"Addresstype is not exist");
                        return NotFound($"Addresstype is not exist");
                    }
                    item.Type = (_userDetailRepositary.TypeFinder(item.Type)).Id.ToString();
                    item.Country = (_userDetailRepositary.TypeFinder(item.Country)).Id.ToString();
                    item.UpdateBy = LoggedUserId;
                    item.DateUpdated = DateTime.Now;
                }
                user.UpdateBy = LoggedUserId;
                user.DateUpdated = DateTime.Now;
                Entities.User userFromRepo = _userDetailRepositary.GetUser(userId);
                if (userFromRepo == null)
                {
                    _logger.LogInformation("user not found");
                    return NotFound();
                }
                List<Address> AddressGuid = _userDetailRepositary.GetAddressIds(userId).ToList();
                userFromRepo.Address.ToList()[0].Id = AddressGuid[0].Id;
                List<Email> EmailGuid = _userDetailRepositary.GetEmailIds(userId).ToList();
                userFromRepo.Emails.ToList()[0].Id = EmailGuid[0].Id;
                List<Phone> PhoneGuid = _userDetailRepositary.GetPhoneIds(userId).ToList();
                userFromRepo.Phones.ToList()[0].Id = PhoneGuid[0].Id;
           
                _mapper.Map(user, userFromRepo);
                _userDetailRepositary.UpdateUser(userFromRepo, userId);
                _userDetailRepositary.Save();
                _logger.LogInformation("Addressbook updated successfully");
                return Ok("Updated successfully");

            }
            else {
                return BadRequest();
            }
        }
}
}
