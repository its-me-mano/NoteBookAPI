using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;


namespace NoteBookAPI.Models
{
    public class EmailDto
    {
        ///<summary>
        ///user Id
        ///</summary>
        public Guid UserId { get; set; }
        ///<summary>
        ///email Id
        ///</summary>
        public Guid Id { get; set; }
        ///<summary>
        ///email address
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "email_address")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Enter Valid email address")]
        public string EmailAddress { get; set; }
        ///<summary>
        ///type id of email
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "type")]
        public Guid TypeId { get; set; }

    }
}
