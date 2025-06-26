using Microsoft.EntityFrameworkCore;
using NLayerApp.DAL.Entities;


namespace NLayerApp.DAL.EF
{
    public class MobileContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }

        public MobileContext(DbContextOptions<MobileContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);
        }
    }
}