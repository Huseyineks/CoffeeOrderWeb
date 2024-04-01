using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderWeb.EntityLayer.Model
{
    public class OrderDetails
    {
        [Key]
        public int MenuDetailsId { get; set; }
        
        public string Size { get; set; }

        public string ColdOrHot { get; set; }

        public bool MoreCaffein { get; set; }

        public string Note { get; set; }

        //relation

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        
    }
}
