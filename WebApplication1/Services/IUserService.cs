using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IUserService
    {
        public void SetUserPassword(ShopUser user, string password);
    }
}
