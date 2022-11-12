using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Entities
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string password { get; set; }
        public ICollection<Address> Address { get; set; } = new List<Address>();
        public ICollection<Email> Emails { get; set; } = new List<Email>();

        public ICollection<Phone> Phones { get; set; } = new List<Phone>();
        public ICollection<AssetDto> AssetDtos { get; set; } = new List<AssetDto>();
    }
}
