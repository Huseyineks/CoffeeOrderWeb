using CoffeeOrderWeb.BusinessLogicLayer.Abstract;
using CoffeeOrderWeb.DataAccesLayer.Abstract;
using CoffeeOrderWeb.EntityLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderWeb.BusinessLogicLayer.Concrete
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        private readonly IBaseRepository<Order> _repository;
        public OrderService(IBaseRepository<Order> repository) : base(repository)
        {
            _repository = repository;

        }
    }
}
