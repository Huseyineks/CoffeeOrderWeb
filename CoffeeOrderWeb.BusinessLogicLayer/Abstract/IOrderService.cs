using CoffeeOrderWeb.EntityLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderWeb.BusinessLogicLayer.Abstract
{
    public interface IOrderService : IBaseService<Order>
    {
        public List<Order> GetOrderDetails(Expression<Func<Order,bool>> filter);
    }
}
