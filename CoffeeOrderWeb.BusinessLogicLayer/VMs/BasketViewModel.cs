using CoffeeOrderWeb.BusinessLogicLayer.DTOs;
using CoffeeOrderWeb.EntityLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderWeb.BusinessLogicLayer.VMs
{
    public class BasketViewModel
    {
        public List<Order> orders { get; set; }

        public OrderDetailsDTO? orderDetails { get; set; }
    }
}
