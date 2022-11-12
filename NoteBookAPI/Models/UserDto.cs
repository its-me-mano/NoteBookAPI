using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Models
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public ICollection<EmailCreatingDto> Emails { get; set; } = new List<EmailCreatingDto>();
        public ICollection<AddressDto> Address { get; set; } = new List<AddressDto>();
        public ICollection<EmailDto> Emails { get; set; } = new List<EmailDto>();
        public ICollection<PhoneDto> Phones { get; set; } = new List<PhoneDto>();
        public ICollection<AssetDto1> AssetDtos { get; set; } = new List<AssetDto1>();

    }
}
