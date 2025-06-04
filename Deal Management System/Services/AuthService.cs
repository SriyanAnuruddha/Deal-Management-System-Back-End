using Deal_Management_System.Data;
using Deal_Management_System.DTOs;
using Deal_Management_System.Models;
using Deal_Management_System.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Deal_Management_System.Services
{
    public class AuthService(AppDBContext context,IConfiguration configuration) : IAuthService
    {
        public async Task<string?> LoginAsync(LoginUserDTO userDTO)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Username == userDTO.Username);
            if(user is null)
            {
                return null;
            }

            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, userDTO.Password) == PasswordVerificationResult.Failed)
            {
                return null;
            }

            return CreateToken(user);

        }

        public async Task<User?> RegisterUserAsync(RegisterUserDTO userDTO)
        {
            if (await context.Users.AnyAsync(u => u.Username.ToLower() == userDTO.Username.ToLower()))
            {
                return null;
            }

            var user = new User();

            var hashedPassword = new PasswordHasher<User>()
                .HashPassword(user, userDTO.Password);

            user.Username = userDTO.Username;
            user.PasswordHash = hashedPassword;
            user.Role = userDTO.Role;

            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.Role,user.Role)

            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("AppSettings:Issuer"),
                audience: configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor); // this will creates the token

        }
    }
}
