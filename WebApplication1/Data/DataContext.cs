using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ShopUser> ShopUsers { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Categories)
                .WithMany(c => c.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductProductCategory",
                    j => j
                        .HasOne<ProductCategory>()
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_ProductProductCategory_Categories")
                        .OnDelete(DeleteBehavior.Cascade),
                    j => j
                        .HasOne<Product>()
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_ProductProductCategory_Products")
                        .OnDelete(DeleteBehavior.Cascade)
                );
            modelBuilder.Entity<Basket>()
                .HasOne(b => b.User)
                .WithOne()
                .HasForeignKey<Basket>(b => b.ShopUserId);
    
            modelBuilder.Entity<BasketItem>()
                .HasOne(bi => bi.Product)
                .WithMany()
                .HasForeignKey(bi => bi.ProductId);

            modelBuilder.Entity<BasketItem>()
                .HasOne(bi => bi.Basket)
                .WithMany(b => b.Items)
                .HasForeignKey(bi => bi.BasketId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany()
                .HasForeignKey(o => o.ShopUserId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<ShopUser>()
                .HasOne(su => su.Basket)
                .WithOne(b => b.User)
                .HasForeignKey<Basket>(b => b.ShopUserId);

            modelBuilder.Entity<ShopUser>()
                .HasMany(su => su.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.ShopUserId);
        }

    }
}
