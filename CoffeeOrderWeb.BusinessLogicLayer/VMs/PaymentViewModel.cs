using CoffeeOrderWeb.BusinessLogicLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderWeb.BusinessLogicLayer.VMs
{
    public class PaymentViewModel
    {
        public string ?City { get; set; }

        public string ?Region { get; set; }

        public string ?FullAdress { get; set; }

        public PaymentDTO ?creditCard { get; set;}

        public bool ?Cash { get; set;}

        public bool? PayAtAdress { get;set;}

        
    }
}
