
using Newtonsoft.Json;

namespace NoteBookAPI.Entities.Dto
{
    public class ErrorDto
    {
        /// <summary>
        /// Error status code
        /// </summary>
        [JsonProperty(PropertyName = "status_code")]
        public string StatusCode { get; set; }
        /// <summary>
        /// Error message
        /// </summary>
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
        /// <summary>
        /// Error Description
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}
