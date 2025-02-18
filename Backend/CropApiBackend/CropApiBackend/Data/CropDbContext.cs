using Microsoft.EntityFrameworkCore;
using CropApiBackend.Models;

namespace CropApiBackend.Data
{
    public class CropDbContext : DbContext
    {
        public CropDbContext(DbContextOptions<CropDbContext> options) : base(options) { }

            public DbSet<User> Users { get; set; }
            public DbSet<Role> Roles { get; set; }
            public DbSet<Crop> Crops { get; set; }
            public DbSet<Subscription> Subscriptions { get; set; }
            public DbSet<Order> Orders { get; set; }
            public DbSet<Payment> Payments { get; set; }
            public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ensure proper decimal precision to prevent silent truncation
            modelBuilder.Entity<Crop>()
                .Property(c => c.PricePerKg)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalPrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)");

            // Apply other configurations
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<Crop>()
                .HasOne(c => c.Farmer)
                .WithMany()
                .HasForeignKey(c => c.FarmerId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Dealer)
                .WithMany()
                .HasForeignKey(o => o.DealerId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Farmer)
                .WithMany()
                .HasForeignKey(o => o.FarmerId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Crop)
                .WithMany()
                .HasForeignKey(o => o.CropId);

            modelBuilder.Entity<Subscription>()
                .HasOne(s => s.Dealer)
                .WithMany()
                .HasForeignKey(s => s.DealerId);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Order)
                .WithMany()
                .HasForeignKey(p => p.OrderId);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany()
                .HasForeignKey(n => n.UserId);
        }


    }
}
