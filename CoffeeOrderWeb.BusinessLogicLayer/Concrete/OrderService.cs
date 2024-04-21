using CoffeeOrderWeb.BusinessLogicLayer.Abstract;
using CoffeeOrderWeb.DataAccesLayer.Abstract;
using CoffeeOrderWeb.EntityLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderWeb.BusinessLogicLayer.Concrete
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        IOrderRepository _orderRepository;
        public OrderService(IBaseRepository<Order> repository,IOrderRepository orderRepository) : base(repository)
        {
            _orderRepository = orderRepository;
           

        }

        

        public List<Order> GetOrderDetails(Expression<Func<Order, bool>> filter)
        {
            return _orderRepository.GetOrderDetails(filter);
        }
    }
}
