using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using TestWebApp.Factories;
using WebApplication1.Data;
using WebApplication1.Models;
using WebApplication1.Services;

namespace TestWebApp.Services
{
    public class TestUserService
    {
        [Fact]
        public async Task GetUsersAsync_ReturnsAllUsers()
        {
           
            using (var context = DbFactory.CreateDbContextForSQLite())
            {
               
                context.ShopUsers.Add(new ShopUser { Name = "User1", Email = "user1@example.com", Password = "password1" });
                context.ShopUsers.Add(new ShopUser { Name = "User2", Email = "user2@example.com", Password = "password2" });
                context.ShopUsers.Add(new ShopUser { Name = "User3", Email = "user3@example.com", Password = "password3" });
                await context.SaveChangesAsync();

                var userService = new UserService(context);

                
                var result = await userService.GetUsersAsync();

                
                Assert.NotNull(result);
                Assert.Equal(3, result.Count);
            } 
        }

        [Fact]
        public async Task GetUserByUsernameAsync_UserExists_ReturnsUserAndNullErrorMessage()
        {
            using (var context = DbFactory.CreateDbContextForSQLite())
            {
              
                var testUsername = "TestUser";
                context.ShopUsers.Add(new ShopUser { Name = testUsername, Email = "test@example.com", Password = "testpassword" });
                await context.SaveChangesAsync();

                var userService = new UserService(context);

                
                var (user, errorMessage) = await userService.GetUserByUsernameAsync(testUsername);

                
                Assert.NotNull(user);
                Assert.Equal(testUsername, user.name);
                Assert.Null(errorMessage);
            }
        }

        [Fact]
        public async Task GetUserByUsernameAsync_UserDoesNotExist_ReturnsNullUserAndErrorMessage()
        {
            using (var context = DbFactory.CreateDbContextForSQLite())
            {
               
                var userService = new UserService(context);

                
                var (user, errorMessage) = await userService.GetUserByUsernameAsync("NonexistentUser");

                
                Assert.Null(user);
                Assert.Equal("User not found", errorMessage);
            }
        }

    }
}
