using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderWeb.BusinessLogicLayer.DTOs
{
    public class PaymentDTO
    {
        public string cardName {  get; set; }

        public string cardNumber { get; set; }

        public string cardExpirationDate { get; set; }

        public string cardCvCode { get; set; }

        public bool IsSaved { get; set; }

    }
}
