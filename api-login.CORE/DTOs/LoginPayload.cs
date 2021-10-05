using System;
using System.Collections.Generic;
using System.Text;

namespace api_login.CORE.DTOs
{
    public class LoginPayload
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
