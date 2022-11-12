using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Models
{
    public class EmailCreatingDto
    {

        public string email { get; set; } 

        public string type { get; set; }
    }
}
