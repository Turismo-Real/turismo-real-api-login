using api_login.CORE.DTOs;
using api_login.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace api_login.CORE.Interfaces
{
    public interface ILoginRepository
    {
        Task<bool> LoginAsync(string email, string pass);
    }
}
