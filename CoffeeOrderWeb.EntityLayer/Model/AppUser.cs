using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderWeb.EntityLayer.Model
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string City { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        public string FullAdress { get; set; }


        //relation
        
        public virtual List<Order>? Orders { get; set; }

        public virtual List<CreditCard>? CreditCards { get; set; }


    }
}
