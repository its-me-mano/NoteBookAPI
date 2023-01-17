using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
namespace NoteBookAPI.Models
{
    public class LoginCredentialsDto
    {
        ///<summary>
        ///email address
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "email_address")]
        public string EmailAddress { get; set; }
        ///<summary>
        ///password
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "password")]
        public string password { get; set; }

    }
}
