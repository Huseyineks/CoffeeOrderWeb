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
    public class OrderDetailsService : BaseService<OrderDetails>,IOrderDetailsService
    {
        private readonly IBaseRepository<OrderDetails> _repository;
        public OrderDetailsService(IBaseRepository<OrderDetails> repository) : base(repository) { 
            _repository = repository;
        
        }

    }
}
