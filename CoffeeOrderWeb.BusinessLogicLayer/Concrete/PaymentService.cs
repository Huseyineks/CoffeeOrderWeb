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
    public class PaymentService : BaseService<PaymentInformation>, IPaymentService
    {
        private readonly IBaseRepository<PaymentInformation> _repository;
        public PaymentService(IBaseRepository<PaymentInformation> repository) : base(repository)
        {
            _repository = repository;
         

        }
    }
}
