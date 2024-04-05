using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderWeb.BusinessLogicLayer.DTOs
{
    public class OrderDetailsDTO
    {
        public string Size { get; set; }

        public string ColdOrHot { get; set; }

        public bool MoreCaffein { get; set; }

        public string Note { get; set; } = string.Empty;

        public int OrderId { get; set; }
    }
}
