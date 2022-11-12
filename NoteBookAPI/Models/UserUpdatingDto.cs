using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Models
{
    public class UserUpdatingDto
    {
          public string FirstName { get; set; }
        public string LastName { get; set; }
        public string password { get; set; }

        public ICollection<AddressUpatingDto> Address { get; set; } = new List<AddressUpatingDto>();
        public ICollection<EmailUpdatingDto> Emails { get; set; } = new List<EmailUpdatingDto>();

       public ICollection<PhoneUpdatingDto> Phones { get; set; } = new List<PhoneUpdatingDto>();
        public ICollection<AssetUpdateDto> AssetDtos { get; set; } = new List<AssetUpdateDto>();
    }
}
