using System.Threading.Tasks;
using TurismoReal_Login.Core.DTOs;

namespace TurismoReal_Login.Core.Interfaces
{
    public interface ILoginRepository
    {
        Task<ResponseOK> LoginAsync(string email, string pass);
    }
}
