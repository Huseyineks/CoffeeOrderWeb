using CoffeeOrderWeb.DataAccesLayer.Abstract;
using CoffeeOrderWeb.DataAccesLayer.Data;
using CoffeeOrderWeb.EntityLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderWeb.DataAccesLayer.Concrete
{
    public class OrderRepository : BaseRepository<Order>,IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context) : base(context) { 
        
        _context = context;
        
        }

        public List<Order> GetOrderDetails(Expression<Func<Order, bool>> filter)
        {
            var orders = _context.Orders.Where(filter).Include(i => i.Details);


            return orders.ToList();
        }


    }
}
