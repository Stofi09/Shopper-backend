namespace WebApplication1.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public int ShopUserId { get; set; }
        public virtual ShopUser User { get; set; }
        public virtual ICollection<BasketItem> Items { get; set; }
    }
}
