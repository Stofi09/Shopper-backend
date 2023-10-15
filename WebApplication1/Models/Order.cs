namespace WebApplication1.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ShopUserId { get; set; }
        public virtual ShopUser User { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual ICollection<OrderItem> Items { get; set; }
    }
}
