namespace TurismoReal_Login.Core.DTOs
{
    public class ResponseOK
    {
        public ResponseOK() { }
        public ResponseOK(string message, bool login)
        {
            this.message = message;
            this.login = login;
        }
        public string message { get; set; }
        public bool login { get; set; }
    }
}
