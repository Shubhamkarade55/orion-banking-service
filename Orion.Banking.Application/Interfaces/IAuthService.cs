using System.Threading.Tasks;

namespace Orion.Banking.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(string username, string password); 
        Task RegisterAsync(string username, string password, string email);
    }
}
