using Orion.Banking.Domain.Entities;
using System.Threading.Tasks;

namespace Orion.Banking.Application.Interfaces
{
    // Must be an interface, not a class
    public interface IAuthRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task AddUserAsync(User user);
    }
}
