using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class ShopUser
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        public virtual Basket Basket { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
