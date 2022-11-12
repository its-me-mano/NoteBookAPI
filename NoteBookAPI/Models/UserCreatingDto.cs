using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Models
{
    public class UserCreatingDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string password { get; set; }

        public ICollection<AddressCreatingDto> Address { get; set; } = new List<AddressCreatingDto>();
        public ICollection<EmailCreatingDto> Emails { get; set; } = new List<EmailCreatingDto>();

       public ICollection<PhoneCreatingDto> Phones { get; set; } = new List<PhoneCreatingDto>();
        public ICollection<AssetDtoCreating> AssetDtos { get; set; } = new List<AssetDtoCreating>();

    }
}
