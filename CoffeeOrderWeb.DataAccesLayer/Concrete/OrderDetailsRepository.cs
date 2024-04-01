using CoffeeOrderWeb.DataAccesLayer.Data;
using CoffeeOrderWeb.EntityLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderWeb.DataAccesLayer.Concrete
{
    public class OrderDetailsRepository : BaseRepository<OrderDetails>
    {
        private readonly ApplicationDbContext _context;
        public OrderDetailsRepository(ApplicationDbContext context) : base(context) { 
        
        _context = context;
        
        }
    }
}
