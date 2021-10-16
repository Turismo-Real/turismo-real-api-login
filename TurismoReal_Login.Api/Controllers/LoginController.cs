using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TurismoReal_Login.Core.DTOs;
using TurismoReal_Login.Core.Interfaces;
using TurismoReal_Login.Core.Log;

namespace TurismoReal_Login.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [HttpPost]
        public async Task<ResponseOK> Login([FromBody] LoginPayload payload)
        {
            LogModel log = new LogModel();
            log.servicio = "turismo-real-login";
            log.payload = payload;
            DateTime startService = DateTime.Now;

            ResponseOK result = await _loginRepository.LoginAsync(payload.email, payload.password);
            
            // LOG
            log.inicioSolicitud = startService;
            log.finSolicitud = DateTime.Now;
            log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
            log.statusCode = 200;
            log.response = result;
            Console.WriteLine(log.parseJson());
            // LOG

            return result;
        }
    }
}
