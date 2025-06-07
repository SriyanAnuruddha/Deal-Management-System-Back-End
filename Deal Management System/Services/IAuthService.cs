using Deal_Management_System.DTOs;
using Deal_Management_System.Models;

namespace Deal_Management_System.Services
{
    public interface IAuthService
    {
         Task<UserResponseDTO?> RegisterUserAsync(UserDTO userDTO);
         Task<UserResponseDTO?> LoginAsync(UserDTO userDTO);
    }
}
