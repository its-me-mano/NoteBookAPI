using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Models
{
    public class UploadFile
    {
        public int Id { get; set; }
        public IFormFile files { get; set; }

        public string name { get; set; }



    }
}
