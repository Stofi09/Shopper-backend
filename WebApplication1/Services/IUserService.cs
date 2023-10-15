using WebApplication1.Models;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Services
{
    public interface IUserService
    {
        public void SetUserPassword(ShopUser user, string password);
        public Task<List<UserDTO>> GetUsersAsync();
        public Task<(UserDTO user, string errorMessage)> GetUserByUsernameAsync(string username);
    }
}
