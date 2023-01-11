using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Models
{
    public class RefSetDto
    {

        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        public Guid Id { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}
