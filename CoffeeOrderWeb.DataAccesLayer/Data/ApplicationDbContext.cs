using CoffeeOrderWeb.EntityLayer.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Stripe.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderWeb.DataAccesLayer.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser,AppUserRole,int>
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
           
                optionsBuilder.UseSqlServer("server=localhost;initial catalog=CoffeeWebDb;integrated Security=true; TrustServerCertificate=True");
            
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<OrderDetails>(entity =>
            {
                entity.HasOne(i => i.Order).WithOne(i => i.Details).HasForeignKey<OrderDetails>(i => i.orderId).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Order>(entity =>
            {
                entity.Property(i => i.OrderId).ValueGeneratedOnAdd();
                entity.HasOne(i => i.User).WithMany(i => i.Orders).HasForeignKey(i => i.UserId).OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<PaymentInformation>(entity =>
            {
                entity.HasOne(i => i.User).WithMany(i => i.PaymentInformations).HasForeignKey(i => i.UserId).OnDelete(DeleteBehavior.Cascade);
            });
            SeedRoles(builder);
        }

        private static void SeedRoles(ModelBuilder builder)
        {
           


            builder.Entity<AppUserRole>().HasData(

                new AppUserRole() {Id = 1 ,Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new AppUserRole() {Id = 2 ,Name = "User", ConcurrencyStamp = "2", NormalizedName = "User" }


                );
        }

       
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<PaymentInformation> PaymentInformations { get; set; }

        public DbSet<Menu> Menus { get; set; }
    }
}
