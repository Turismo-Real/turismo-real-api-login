using api_login.INFRASTRUCTURE.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_login.CORE.DTOs;
using api_login.CORE.Interfaces;

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
            return responseOK;
        }
    }
}
