using System;
using System.Collections.Generic;
using System.Text;

namespace api_login.CORE.DTOs
{
    public class BadResponse
    {
        public BadResponse(string message, string error)
        {
            this.message = message;
            this.error = error;
        }

        public string message { get; set; }
        public string error { get; set; }
    }
}
