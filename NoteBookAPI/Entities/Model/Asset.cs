using NoteBookAPI.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace NoteBookAPI.Entities
{
    [DataContract]
    public class Asset : BaseModel
    {
        ///<summary>
        ///UserId of asset
        ///</summary>
        [ForeignKey("UserId")]
        [DataMember(Name = "user_id")]
        public Guid UserId { get; set; }

        ///<summary>
        /// binary array of the image
        ///</summary>
        [Required]
        [MaxLength]
        [DataMember(Name = "file")]
        public string File { get; set; }

    }
}
