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

        public Guid RowGuid { get; set; }

        public string ProductImage { get; set; }

        public string ProductName { get; set; }

        public string ProductPrice { get; set; }

        public DateTime createdAt { get; set; } = DateTime.Now;



        //relation
        public int UserId { get; set; }
        public virtual AppUser User { get; set; }

        public virtual OrderDetails Details { get; set; }

        public virtual PaymentInformation Payment { get; set; }
    }
}
