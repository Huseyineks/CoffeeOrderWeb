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
    public class CreditCardService : BaseService<CreditCard>, ICreditCardService
    {
        public CreditCardService(IBaseRepository<CreditCard> baseRepository) : base(baseRepository) { }
    }
}
