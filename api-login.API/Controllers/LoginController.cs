using api_login.INFRASTRUCTURE.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using api_login.CORE.DTOs;
using api_login.CORE.Interfaces;
using api_login.CORE.Log;

namespace api_login.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [HttpGet]
        public async Task<object> Login([FromBody]LoginPayload pyl)
        {
            LogModel log = new LogModel();
            log.servicio = "turismo-real-api-login";
            log.payload = pyl;
            DateTime startService = DateTime.Now;

            ResponseOK responseOK = new ResponseOK();
            bool result = await _loginRepository.LoginAsync(pyl.email, pyl.password);
            if (result)
            {
                responseOK.message = "Usuario Autorizado.";
                responseOK.login = result;
            }
            else
            {
                responseOK.message = "Usuario No Autorizado.";
                responseOK.login = result;
            }

            // LOG
            log.inicioSolicitud = startService;
            log.finSolicitud = DateTime.Now;
            log.tiempoSolicitud = (log.finSolicitud - log.inicioSolicitud).TotalMilliseconds + " ms";
            log.statusCode = 200;
            log.response = responseOK;
            Console.WriteLine(log.parseJson());
            // LOG

            return responseOK;
        }
    }
}
