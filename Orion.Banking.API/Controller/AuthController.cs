using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Orion.Banking.Application.Interfaces;

namespace Orion.Banking.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authService.LoginAsync(request.Username, request.Password);
            return Ok(new { Token = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            await _authService.RegisterAsync(request.Username, request.Password, request.Email);
            return Ok("User registered successfully");
        }
    }

    public record LoginRequest(string Username, string Password);
    public record RegisterRequest(string Username, string Password, string Email);

}

