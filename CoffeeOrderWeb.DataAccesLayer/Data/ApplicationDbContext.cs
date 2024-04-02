using CoffeeOrderWeb.EntityLayer.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<PaymentInformation> PaymentInformations { get; set; }

        public DbSet<Menu> Menus { get; set; }
    }
}
