using Deal_Management_System.DTOs;
using Deal_Management_System.Models;

namespace Deal_Management_System.Services
{
    public interface IAuthService
    {
         Task<User?> RegisterUserAsync(RegisterUserDTO userDTO);
         Task<string?> LoginAsync(LoginUserDTO userDTO);
    }
}
