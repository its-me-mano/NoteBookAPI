using NoteBookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Helper
{
    public class ReturnUpdateStatus
    {
        ///<summary>
        ///return status number
        ///</summary>
        public int status { get; set; }
        ///<summary>
        ///return status description
        ///</summary>
        public string description { get; set; }
        ///<summary>
        ///Updatinguser
        ///</summary>
        public UserUpdatingDto user { get; set; }
    }
}
