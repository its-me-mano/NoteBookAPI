
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Entities.Model
{
    public class BaseModelDto
    {
        ///<summary>
        /// Id 
        ///</summary>
        [Key]
        public Guid Id { get; set; }
        ///<summary>
        /// Time of creation
        ///</summary>
        public DateTime DateCreated { get; set; }
        ///<summary>
        /// UpdateTime of the table
        ///</summary>
        public DateTime DateUpdated { get; set; }
        ///<summary>
        /// Table created by the user
        ///</summary>
        public Guid CreateBy { get; set; }
        ///<summary>
        /// Table updated by the user
        ///</summary>
        public Guid UpdateBy { get; set; }
    }
}
