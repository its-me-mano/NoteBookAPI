
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


namespace NoteBookAPI.Models
{
    public class LoginCredentialsDto
    {
        [Required]
        [JsonProperty(PropertyName = "email_address")]
        public string EmailAddress { get; set; }
        [Required]
        [JsonProperty(PropertyName = "password")]
        public string password { get; set; }

    }
}
