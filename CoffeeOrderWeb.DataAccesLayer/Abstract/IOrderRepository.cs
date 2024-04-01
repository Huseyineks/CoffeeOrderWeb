using CoffeeOrderWeb.EntityLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderWeb.DataAccesLayer.Abstract
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
    }
}
