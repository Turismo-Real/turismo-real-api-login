using System.Threading.Tasks;

namespace TurismoReal_Login.Core.Interfaces
{
    public interface ILoginRepository
    {
        Task<bool> LoginAsync(string email, string pass);
    }
}
