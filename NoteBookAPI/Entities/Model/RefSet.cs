using NoteBookAPI.Entities.Model;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace NoteBookAPI.Entities
{
    [DataContract]
    public class RefSet : BaseModel 
    {
        ///<summary>
        /// Id of the Refset 
        ///</summary>
        [Required]
        [DataMember(Name = "key")]
        public string Key { get; set; }
        ///<summary>
        /// description of the refset key 
        ///</summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }
    }
}
