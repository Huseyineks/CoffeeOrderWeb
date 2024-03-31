using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderWeb.EntityLayer.Model
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public string ProductName { get; set; }

        public string ProductPrice { get; set; }



        //relatin
        public int UserId { get; set; }
        public virtual AppUser User { get; set; }

        public virtual List<OrderDetails> Details { get; set; }
    }
}
