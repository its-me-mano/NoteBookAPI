using Newtonsoft.Json;
using NoteBookAPI.Entities.Dto;
using System.ComponentModel.DataAnnotations;


namespace NoteBookAPI.Models
{
    public class EmailCreatingDto 
    {
        ///<summary>
        ///Email address
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "email_address")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Enter Valid email address")]
        public string EmailAddress { get; set; }
        ///<summary>
        ///email type
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "type")]
        public string type { get; set; }
    }
}
