using Microsoft.EntityFrameworkCore;
using BelanjaYuk_BE.Models;

namespace BelanjaYuk_BE.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<UserPassword> UserPasswords { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<HomeAddress> HomeAddresses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSeller> UserSellers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BuyerCart> BuyerCarts { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<BuyerTransaction> BuyerTransactions { get; set; }
        public DbSet<BuyerTransactionDetail> BuyerTransactionDetails { get; set; }


    }
}
