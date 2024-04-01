using CoffeeOrderWeb.DataAccesLayer.Data;
using CoffeeOrderWeb.EntityLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderWeb.DataAccesLayer.Concrete
{
    public class PaymentRepository : BaseRepository<PaymentInformation>
    {
        private readonly ApplicationDbContext _context;

        public PaymentRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }
    }
}
