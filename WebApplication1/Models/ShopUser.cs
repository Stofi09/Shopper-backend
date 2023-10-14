using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ShopUser
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        private string _password;
        [Required]
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = BCrypt.Net.BCrypt.HashPassword(value);
            }
        }
    }
}
