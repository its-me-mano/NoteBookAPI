using NoteBookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Helper
{
    public class ReturnCreateStatus
    {
        ///<summary>
        ///status number
        ///</summary>
        public int status { get; set; }
        ///<summary>
        ///description
        ///</summary>
        public string description { get; set; }
        ///<summary>
        ///the user to return
        ///</summary>
        public UserCreatingDto user { get; set; }
    }
}
