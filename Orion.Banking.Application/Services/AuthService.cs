using Orion.Banking.Application.Interfaces;
using Orion.Banking.Domain.Entities;
using System.Security.Cryptography;
using System.Text;


namespace Orion.Banking.Application.Services
{
    public class AuthService : IAuthService
        {
            private readonly IAuthRepository _authRepository;

            public AuthService(IAuthRepository authRepository)
            {
                _authRepository = authRepository;
            }

            public async Task<string> LoginAsync(string username, string password)
            {
                var user = await _authRepository.GetByUsernameAsync(username);
                if (user == null || !VerifyPassword(password, user.PasswordHash))
                    throw new UnauthorizedAccessException("Invalid credentials");

                // TODO: Generate JWT here
                return "JWT_TOKEN_PLACEHOLDER";
            }

            public async Task RegisterAsync(string username, string password, string email)
            {
                var hashedPassword = HashPassword(password);
                var user = new User
                {
                    Username = username,
                    PasswordHash = hashedPassword,
                    Email = email
                };

                await _authRepository.AddUserAsync(user);
            }

            private string HashPassword(string password)
            {
                using var sha256 = SHA256.Create();
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }

            private bool VerifyPassword(string password, string storedHash)
            {
                var hash = HashPassword(password);
                return hash == storedHash;
            }

    }
}

