using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext _dbContext;

        public UserService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<(UserDTO user, string errorMessage)> GetUserByUsernameAsync(string username)
        {
            try
            {
                var user = await _dbContext.ShopUsers
                                         .Where(u => u.Name == username)
                                         .Select(u => new UserDTO
                                         {
                                             name = u.Name,
                                             email = u.Email
                                         })
                                         .FirstOrDefaultAsync();

                if (user == null)
                {
                    return (null, "User not found");
                }

                return (user, null);
            }
            catch (Exception ex)
            {
                return (null, "An error occurred while processing your request.");
            }
        }

        public async Task<List<UserDTO>> GetUsersAsync()
        {
            return await _dbContext.ShopUsers
                                 .Select(user => new UserDTO
                                 {
                                     name = user.Name,
                                     email = user.Email
                                 })
                                 .ToListAsync();
        }


        public void SetUserPassword(ShopUser user, string password)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(password);
        }

    }
}
