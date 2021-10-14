namespace TurismoReal_Login.Core.DTOs
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
