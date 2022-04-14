using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using bossmarket.Entities;

namespace bossmarket.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            var connectionString = Configuration.GetConnectionString("WebApiDatabase");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<Users> Users { get; set; }
        // public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Categori> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Satuan> Satuans { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<StatusOrder> StatusOrders { get; set; }
        public DbSet<StatusPayment> StatusPayments { get; set; }
    }
}