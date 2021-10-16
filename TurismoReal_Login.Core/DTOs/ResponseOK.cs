namespace TurismoReal_Login.Core.DTOs
{
    public class ResponseOK
    {
        public ResponseOK() { }
        public ResponseOK(string mensaje, bool login, string tipo)
        {
            this.mensaje = mensaje;
            this.login = login;
            this.tipo = tipo;
        }
        public string mensaje { get; set; }
        public bool login { get; set; }
        public string tipo { get; set; }
    }
}
