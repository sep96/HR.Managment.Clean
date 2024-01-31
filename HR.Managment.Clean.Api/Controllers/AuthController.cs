using HR.Managment.Application.Contracts.Identity;
using HR.Managment.Application.Model.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HR.Managment.Clean.Api.Controllers
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
        public virtual async Task<AuthResponse> Login([FromBody] AuthRequest request)
        {
            return await _authService.Login(request);
        }

        [HttpPost("Register")]
        public virtual async Task<RegistrationResponse> Register([FromBody] RegistrationRequest request)
        {
            return await _authService.Register(request);
        }
    }
}
