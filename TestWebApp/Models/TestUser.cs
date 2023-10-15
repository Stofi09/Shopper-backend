using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace TestWebApp.Models
{
    public class TestUser
    {
        [Fact]
        public void ShopUser_NameIsRequired()
        {
            // Arrange
            var user = new ShopUser { Name = null };
            var validationContext = new ValidationContext(user);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(user, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(validationResults, v => v.MemberNames.Contains("Name"));
        }

        [Fact]
        public void ShopUser_EmailIsRequired()
        {
            // Arrange
            var user = new ShopUser { Email = null };
            var validationContext = new ValidationContext(user);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(user, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(validationResults, v => v.MemberNames.Contains("Email"));
        }

        [Fact]
        public void ShopUser_EmailMustBeValidEmailAddress()
        {
            // Arrange
            var user = new ShopUser { Email = "invalid-email" };
            var validationContext = new ValidationContext(user);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(user, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(validationResults, v => v.MemberNames.Contains("Email"));
        }

        [Fact]
        public void ShopUser_PasswordIsRequired()
        {
            // Arrange
            var user = new ShopUser { Password = null };
            var validationContext = new ValidationContext(user);
            var validationResults = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(user, validationContext, validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(validationResults, v => v.MemberNames.Contains("Password"));
        }
    }
}
