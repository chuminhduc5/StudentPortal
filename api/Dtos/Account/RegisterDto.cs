using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Account
{
    public class RegisterDto
    {
        public string StudentCode { get; set; }
        public string Password { get; set; }
    }
}