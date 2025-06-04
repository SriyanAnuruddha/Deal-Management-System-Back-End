using Deal_Management_System.DTOs;
using Deal_Management_System.Models;
using Deal_Management_System.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Deal_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
 
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(RegisterUserDTO userDTO)
        {
            var user = await authService.RegisterUserAsync(userDTO);
            if (user is null)
                return BadRequest("Username is already exists!");
            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginUserDTO userDTO)
        {
            var token = await authService.LoginAsync(userDTO);
            if (token is null)
                return BadRequest("Invalid username or password!");
            return Ok(token);
        }

        [Authorize]
        [HttpGet("authonly")]
        public IActionResult AuthenticatedOnlyEndpoint()
        {
            return Ok("You are authenticated!");
        }

        [Authorize(Roles ="admin")]
        [HttpGet("admin")]
        public IActionResult AdminEndPoint()
        {
            return Ok("You are admin!");
        }

    }
}
