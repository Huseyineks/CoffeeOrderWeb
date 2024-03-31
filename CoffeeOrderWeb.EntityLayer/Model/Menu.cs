using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderWeb.EntityLayer.Model
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }
        public string ProductName { get; set; }
        public string ProductContent { get; set; }
        public string ProductImage { get; set; }
        public string ProductPrice { get; set; }
    }
}
