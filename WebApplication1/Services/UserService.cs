using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class UserService : IUserService
    {
        public void SetUserPassword(ShopUser user, string password)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(password);
        }

    }
}
