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

        public string CreditCartType { get; set; }

        public string CreditCartName { get; set; } 

        public string CreditCartNo { get; set; }

        public string CreditCartDate { get; set; }

        public string CreditCartCvv { get; set; }
        public bool IsSaved { get; set; }

        //relation
        public int UserId { get; set; }

        public virtual AppUser User { get; set; }


    }
}
