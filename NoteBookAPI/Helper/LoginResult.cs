using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBookAPI.Helper
{
    public class LoginResult
    {
        public string accessToken { get; set; }
        public string tokenType = "Bearer";
    }
}
