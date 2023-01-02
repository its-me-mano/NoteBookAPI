using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteBookAPI.Models;
using NoteBookAPI.Services;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using NoteBookAPI.Helper;
using NoteBookAPI.Entities;
using Swashbuckle.AspNetCore.Swagger;

namespace NoteBookAPI.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class UserController : ControllerBase
    {
        private readonly IUserDetailRepositary _userDetailRepositary;
        private readonly IMapper _mapper;



        public UserController(IUserDetailRepositary UserDetailRepositary, IMapper mapper)
        {
            _userDetailRepositary = UserDetailRepositary ?? throw new ArgumentNullException(nameof(UserDetailRepositary));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }
        /*
                                       ALL USER

        */
        [Authorize]
        [HttpHead]
        [HttpGet(Name = "GetAllUser")]
        public ActionResult<IEnumerable<User>> GetUsers([FromQuery] UserResourceParameter userResourceParameter)
        {
            var CountBook = _userDetailRepositary.GetCount();
            double MaxPageNo = (double)CountBook/(double)(userResourceParameter.PageSize);
            int MaxiPage = Convert.ToInt32(Math.Ceiling(MaxPageNo));
            if (MaxiPage< userResourceParameter.PageNo) {
                return NotFound("There is no pageNo");
            }
            var ResourceFromRepo = _userDetailRepositary.GetUsers(userResourceParameter);
            var items = _mapper.Map<IEnumerable<UserDto>>(ResourceFromRepo);
            var userFromRepo = _userDetailRepositary.GetAllUsers();
            foreach (var user in items)
            {
                var emails = _userDetailRepositary.GetEmailIds(user.UserId);
                var Address = _userDetailRepositary.GetAddressIds(user.UserId); 
                var Phone = _userDetailRepositary.GetPhoneIds(user.UserId);
                var AssetDto = _userDetailRepositary.GetAssetIds(user.UserId);
                var emailType = _mapper.Map <IEnumerable<EmailDto>>(emails);
                var AddressType = _mapper.Map<IEnumerable<AddressDto>>(Address);
                var PhoneType = _mapper.Map<IEnumerable<PhoneDto>>(Phone);
                var AssetType = _mapper.Map<IEnumerable<AssetDto1>>(AssetDto);
                 
                user.Phones = PhoneType.ToList();
                user.Emails = emailType.ToList();
                user.Address = AddressType.ToList();
       
                user.AssetDtos = AssetType.ToList();
            }
            return Ok(_mapper.Map<IEnumerable<UserDto>>(items));
        }
        private string CreateBandUri(UserResourceParameter userResourceParameter, UriType uriType)
        {
            switch (uriType)
            {
                case UriType.PreviousPage:
                    return Url.Link("Query", new
                    {
                        PageNo = userResourceParameter.PageNo - 1,
                        pageSisze = userResourceParameter.PageSize,
                        FirstName = userResourceParameter.FirstName

                    });
                case UriType.NextPage:
                    return Url.Link("Query", new
                    {
                        PageNo = userResourceParameter.PageNo + 1,
                        pageSisze = userResourceParameter.PageSize,
                        FirstName = userResourceParameter.FirstName

                    });
                default:
                    return Url.Link("Query", new
                    {
                        PageNo = userResourceParameter.PageNo,
                        pageSisze = userResourceParameter.PageSize,
                        FirstName = userResourceParameter.FirstName

                    });
            }
        }

        /*
                                               COUNT
        */
        [Authorize]
        [HttpGet("count")]
        public IActionResult GetCount()
        {
            var counts = _userDetailRepositary.GetCount();
            return Ok($"Success : {counts}");
        }
        /*
                                              PARTICULAR USER


        */
        [Authorize]
        [HttpGet("{userId}", Name = "GetUser")]
        public IActionResult GetUser(Guid userId)
        {
            if (_userDetailRepositary.UserExits(userId))
            {
                var UserFromRepo = _userDetailRepositary.GetUser(userId);
                var emails = _userDetailRepositary.GetEmailIds(UserFromRepo.UserId);
                var Address = _userDetailRepositary.GetAddressIds(UserFromRepo.UserId);
                var Phone = _userDetailRepositary.GetPhoneIds(UserFromRepo.UserId);
                var AssetDto = _userDetailRepositary.GetAssetIds(UserFromRepo.UserId);
                UserFromRepo.Phones = Phone.ToList();
                UserFromRepo.Emails = emails.ToList();
                UserFromRepo.Address = Address.ToList();
                UserFromRepo.AssetDtos = AssetDto.ToList();
                return new JsonResult(UserFromRepo);
            }
            else {
                return NotFound("Check the userId");
            }
            
            
        }
        /*

                                                DELETE USER

        */
        [Authorize]
        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(Guid userId)
        {
            if (!_userDetailRepositary.UserExits(userId))
            {
                return NotFound();
            }
            var userFromRepo = _userDetailRepositary.GetUser(userId);
            if (userFromRepo == null)
            {
                return NotFound();
            }
            _userDetailRepositary.DeleteUser(userFromRepo);
            _userDetailRepositary.Save();

            return StatusCode(200, "Address book deleted successfully");
        }
        /*
                                                    CREATE USER

        */
        [Authorize]
        [HttpPost]
        public ActionResult<UserDto> CreateUser([FromBody] UserCreatingDto user)
        {
            if (!_userDetailRepositary.IsPasswordValid(user.password))
            {
                return BadRequest("Password is not valid");
            }
            foreach (var item in user.Emails)
            {
                if (!_userDetailRepositary.metaExist(item.type))
                {
                    return NotFound("Email type is not exist");
                }
                if (_userDetailRepositary.EmailExist(item.email))
                {
                    return Conflict("Email is already exist");
                }
                item.type = (_userDetailRepositary.TypeFinder(item.type)).TypeId.ToString();


            }
            foreach (var item in user.Phones)
            {
                if (!_userDetailRepositary.metaExist(item.type))
                    return NotFound("Phone number type is not exist");
                item.type = (_userDetailRepositary.TypeFinder(item.type)).TypeId.ToString();

            }
            foreach (var item in user.Address)
            {
                if (!_userDetailRepositary.metaExist(item.Country))
                {
                    return NotFound($"Countrytype is not exist{item.Country}");
                }
                if (!_userDetailRepositary.metaExist(item.Type))
                {
                    return NotFound("Addresstype is not exist");
                }
                item.Type = (_userDetailRepositary.TypeFinder(item.Type)).TypeId.ToString();
                item.Country = (_userDetailRepositary.TypeFinder(item.Country)).TypeId.ToString();
            }


            var userEntity = _mapper.Map<Entities.User>(user);
            _userDetailRepositary.AddUser(userEntity);
            _userDetailRepositary.Save();

            var userToReturn = _mapper.Map<UserDto>(userEntity);
            return StatusCode(201,$"GetUserID : {userToReturn.UserId}");

            /*return CreatedAtRoute("GetUserId",new { userId=userToReturn.UserId},userToReturn);*/
        }


        /*
                                                  UPDATA USER

        */

        [Authorize]
        [HttpPut("{userId}")]
        public ActionResult<UserDto> UpdateUser(Guid userId, [FromBody] UserUpdatingDto user)
        {

            if (!_userDetailRepositary.UserExits(userId))
            {
                return new JsonResult(userId);
            }

            if (!_userDetailRepositary.IsPasswordValid(user.password))
            {
                return BadRequest("Password is not valid");
            }

            foreach (var item in user.Emails)
            {
                if (!_userDetailRepositary.metaExist(item.type))
                {
                    return NotFound("Email type is not exist");
                }
                if (_userDetailRepositary.EmailExist(item.email))
                {
                    return Conflict("Email is already exist");
                }
                item.type = (_userDetailRepositary.TypeFinder(item.type)).TypeId.ToString();
            }

            foreach (var item in user.Phones)
            {
                if (!_userDetailRepositary.metaExist(item.type))
                    return NotFound("Phone number type is not exist");
                item.type = (_userDetailRepositary.TypeFinder(item.type)).TypeId.ToString();

            }
             
            foreach (var item in user.Address)
            {
                if (!_userDetailRepositary.metaExist(item.Country))
                {
                    return NotFound($"Countrytype is not exist{item.Country}");
                }
                if (!_userDetailRepositary.metaExist(item.Type))
                {
                    return NotFound($"Addresstype is not exist");
                }
                item.Type = (_userDetailRepositary.TypeFinder(item.Type)).TypeId.ToString();
                item.Country = (_userDetailRepositary.TypeFinder(item.Country)).TypeId.ToString();
            }
            var userFromRepo = _userDetailRepositary.GetUser(userId);
            if (userFromRepo == null)
            {
                return NotFound();
            }
            var AddressGuid =_userDetailRepositary.GetAddressIds(userId).ToList();
            foreach (var item in userFromRepo.Address.ToList()) {
                item.AddressId = AddressGuid[0].AddressId; 
            }
            var EmailGuid = _userDetailRepositary.GetEmailIds(userId).ToList();
            var PhoneGuid = _userDetailRepositary.GetPhoneIds(userId).ToList();
            foreach(var item in userFromRepo.Emails.ToList())
            {
                item.EmailId = EmailGuid[0].EmailId;
            }
            foreach (var item in userFromRepo.Phones.ToList()) {
                item.PhId = PhoneGuid[0].PhId;
            }
            _mapper.Map(user, userFromRepo);
            _userDetailRepositary.UpdateUser(userFromRepo,userId);
            _userDetailRepositary.Save();
            return StatusCode(200,"");
        }
    
    
            
         



        


        /*
                                               OPTIONS
              */
        [Authorize]
        [HttpOptions("/login")]
        public IActionResult GetUserOptions()
        {
            Response.Headers.Add("Allow", "GET,POST,DELETE,HEAD,OPTIONS,PUT");
            return Ok();
        }



    /*

                                USER COLLECTION DATA NOT USED...


    */


    [HttpGet("/Collection/{ids}", Name = "GetBandCollection")]
    public IActionResult GetUserCollection([FromRoute]
        [ModelBinder(BinderType=typeof(ArrayModelBuilder))]IEnumerable<Guid> ids)
    {
        if (ids == null)
            return BadRequest();

        var userEntities = _userDetailRepositary.GetAllUsers();

        if (ids.Count() != userEntities.Count())
            return NotFound();

        var userToReturn = _mapper.Map<IEnumerable<UserDto>>(userEntities);
        return Ok(userToReturn);
    }




}
}
