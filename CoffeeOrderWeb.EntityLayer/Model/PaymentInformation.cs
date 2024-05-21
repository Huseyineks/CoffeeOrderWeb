using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderWeb.EntityLayer.Model
{
    public class PaymentInformation
    {
        [Key]
        public int PaymentId { get; set; }

       public string CashOrPayAtAdress { get; set; }

        public bool CreditCard { get; set; }

        public bool PaymentConfirmed { get; set; }

        public string totalPrice { get; set; }
       
        //relation
       

        

        public virtual List<Order> Order { get; set; }


    }
}
