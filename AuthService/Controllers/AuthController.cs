using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AuthService.Models;
using AuthService.Services;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace AuthService.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthRequest request)
        {
            var response = await _authService.Authenticate(request);
            if (response.Token == null)
                return Unauthorized(response);

            return Ok(response);
        }



    }
}
