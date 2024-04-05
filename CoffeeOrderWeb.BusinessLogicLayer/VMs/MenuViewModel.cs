using CoffeeOrderWeb.BusinessLogicLayer.DTOs;
using CoffeeOrderWeb.EntityLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderWeb.BusinessLogicLayer.VMs
{
    public class MenuViewModel
    {
        public List<Menu>? menus {  get; set; }

        public OrderDetailsDTO? orderDetails { get; set; }
    }
}
