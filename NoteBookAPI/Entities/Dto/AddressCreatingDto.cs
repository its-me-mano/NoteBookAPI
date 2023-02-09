using Newtonsoft.Json;
using NoteBookAPI.Entities.Dto;
using System.ComponentModel.DataAnnotations;

namespace NoteBookAPI.Models
{
    public class AddressCreatingDto 
    {
        ///<summary>
        ///street line 1
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "line1")]
        public string Line1 { get; set; }
        ///<summary>
        ///street line 2
        ///</summary>
        [JsonProperty(PropertyName = "line2")]
        public string Line2 { get; set; }
        ///<summary>
        ///city name
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }
        ///<summary>
        ///statename
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "state_name")]
        public string StateName { get; set; }
        ///<summary>
        ///zipcode of the address
        ///</summary>
        [Required]
        [JsonProperty(PropertyName = "zipcode")]
        public string Zipcode { get; set; }
        ///<summary>
        ///addresss type
        ///</summary>
        public string Type { get; set; }
        ///<summary>
        ///country name
        ///</summary>
        public string Country { get; set; }
       

    }
}
