
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace NoteBookAPI.Entities.Model
{
    [DataContract]
    public class BaseModel
    {
        ///<summary>
        /// Id 
        ///</summary>
        [Key]
        [DataMember(Name = "id")]
        public Guid Id { get; set; }
        ///<summary>
        /// Time of creation
        ///</summary>
        [DataMember(Name="date_created")]
        public DateTime DateCreated { get; set; }
        ///<summary>
        /// UpdateTime of the table
        ///</summary>
        [DataMember(Name = "date_updated")]
        public DateTime DateUpdated { get; set; }
        ///<summary>
        /// Table created by the user
        ///</summary>
        [DataMember(Name = "create_by")]
        public Guid CreateBy { get; set; }
        ///<summary>
        /// Table updated by the user
        ///</summary>
        [DataMember(Name="update_by")]
        public Guid UpdateBy { get; set; }
    }
}
