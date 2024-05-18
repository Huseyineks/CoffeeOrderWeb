using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderWeb.EntityLayer.Model
{
    public class CreditCard
    {
        public int Id { get; set; }

        public string CardName { get; set; }

        public string CardNumber { get; set; }

        public string CardType { get; set; } = string.Empty;

        public string CardDate { get; set; }

        public string CardCvv { get; set; }

        //relation

        public int UserId { get; set; }

        public virtual AppUser User { get; set; }


    }
}
