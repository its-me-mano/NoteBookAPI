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
    public class SetRefTerm : BaseModel
    {
        ///<summary>
        /// refset Id 
        ///</summary>
        [DataMember(Name = "refSet_id")]
        [ForeignKey("RefSetid")]
        public Guid RefSetid { get; set; }

        ///<summary>
        /// refterm id 
        ///</summary>
        [ForeignKey("ReftermId")]
        [DataMember(Name = "refterm_id")]
        public Guid ReftermId { get; set; }
    }
}
