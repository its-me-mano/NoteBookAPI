using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NoteBookAPI.Entities;
using NoteBookAPI.Helper;
using NoteBookAPI.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace NoteBookAPI.Services
{
    public class Service : IService

    {
        private readonly IUserDetailRepository userDetailRepository;
        private IConfiguration configuration;
        private readonly IMapper mapper;
        public Service(IUserDetailRepository _UserDetailRepositary,IMapper _mapper,IConfiguration _configuration)
        {
            userDetailRepository = _UserDetailRepositary ?? throw new ArgumentNullException(nameof(_UserDetailRepositary));
            mapper = _mapper ?? throw new ArgumentNullException(nameof(_mapper));
        
            configuration = _configuration ?? throw new ArgumentNullException(nameof(_configuration));
        }
        public metaDataDto FetchMetaData(string search) 
        {
            RefTerm RefTermFromRepo = userDetailRepository.getRefTerm(search);
            IEnumerable<Guid> ResultFromRepo = userDetailRepository.getRefSetGroup(RefTermFromRepo.ReftermId);
            IEnumerable<RefSet> RefSetFromRepo = userDetailRepository.getRefSet(ResultFromRepo);
            IEnumerable<RefSetDto> value = mapper.Map<IEnumerable<RefSetDto>>(RefSetFromRepo);
            metaDataDto meta = new metaDataDto();
            meta.Description = RefTermFromRepo.Description;
            meta.ReftermId = RefTermFromRepo.ReftermId;
            meta.Types = RefTermFromRepo.Key;
            meta.RefSets = value.ToList();
            return meta;
        }

        public string GetLoggedId(ClaimsPrincipal User) {
            string LoggedUserId="";
            try
            {
                if (!String.IsNullOrEmpty(ClaimTypes.NameIdentifier))
                {
                    LoggedUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                }
            }
            catch (Exception e) {
                LoggedUserId = "6ebb437a-03e5-4ebf-83fa-652f548368f2";
            }
             return LoggedUserId;
        }
        public string ImageToString(IFormFile file)
        {
            MemoryStream ms = new MemoryStream();
            file.CopyTo(ms);
            byte[] fileBytes = ms.ToArray();
            return (Convert.ToBase64String(fileBytes));
        }

      

        public byte[] StringToImage(String assetId) {
            Asset Image64 = userDetailRepository.GetImage(Guid.Parse(assetId));

            MemoryStream outputStream = new MemoryStream(Convert.FromBase64String(Image64.File));

            byte[] bytesInStream = outputStream.ToArray();
            return bytesInStream;
        }

        public bool checkPageNumberLimit(int PageSize,int PageNo) {
            int CountBook = userDetailRepository.GetCount();
            double MaxPageNo = (double)CountBook / (double)(PageSize);
            int MaxiPage = Convert.ToInt32(Math.Ceiling(MaxPageNo));
            if (MaxiPage < PageNo)
            {
                return true;
            }
            else {
                return false;
            }
        }

        public PageList<User> AppendingValues(PageList<User> items) {
            foreach (User user in items)
            {
                user.Emails = userDetailRepository.GetEmailIds(user.Id).ToList();
                user.Address = userDetailRepository.GetAddressIds(user.Id).ToList();
                user.Phones =userDetailRepository.GetPhoneIds(user.Id).ToList();
                user.Assets = userDetailRepository.GetAssetIds(user.Id).ToList();
            }
            return items;
        }

        public User AppendingValueForUser(Guid userId) {
            User UserFromRepo = userDetailRepository.GetUser(userId);
            UserFromRepo.Emails = userDetailRepository.GetEmailIds(UserFromRepo.Id).ToList();
            UserFromRepo.Address = userDetailRepository.GetAddressIds(UserFromRepo.Id).ToList();
            UserFromRepo.Phones = userDetailRepository.GetPhoneIds(UserFromRepo.Id).ToList();
            UserFromRepo.Assets = userDetailRepository.GetAssetIds(UserFromRepo.Id).ToList();
            return UserFromRepo;
        }
         
        public bool emailValidation(EmailCreatingDto email) {
            return true;
        }
        public string RefTermKeyToGuidString(string type) {
            return (userDetailRepository.TypeFinder(type)).Id.ToString();
        }

        public bool AuthenticateUser(User login, LoginCredentialsDto input)
        {
            //Validate the User Credentials    
            if (login.password == input.password)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public metaDataDto MetaData(string searchKey) {
            switch (searchKey)
            {
                case "ADDRESS_TYPE":
                    string search = "ADDRESS_TYPE";
                    metaDataDto meta = FetchMetaData(search);
                    return meta;
                case "PHONE_NUMBER_TYPE":
                    string search1 = "PHONE_NUMBER_TYPE";
                    metaDataDto meta1 = FetchMetaData(search1);
                    return meta1;
                case "EMAIL_ADDRESS_TYPE":
                    string search2 = "EMAIL_ADDRESS_TYPE";
                    metaDataDto meta2 = FetchMetaData(search2);
                    return meta2;
                case "COUNTRY":
                    string search3 = "COUNTRY";
                    metaDataDto meta3 = FetchMetaData(search3);
                    return meta3;
                default:
                    return null;
            }
        }
        public string GenerateJSONWebToken(User userInfo,IConfiguration _config)
        {
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            Claim[] claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, userInfo.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, userInfo.LastName),
            new Claim(JwtRegisteredClaimNames.Sub, userInfo.password),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            JwtSecurityToken token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool IsPasswordValid(string password)
        {
            if (password.Length > 8)
            {
                bool upper = false;
                bool Number = false;
                bool lower = false;

                foreach (char str in password)
                {
                    if (Char.IsUpper(str))
                    {
                        upper = true;
                    }
                    if (Char.IsDigit(str))
                        Number = true;
                    if (Char.IsLower(str))
                        lower = true;

                }
                if (upper && Number && lower)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }
    }
}

