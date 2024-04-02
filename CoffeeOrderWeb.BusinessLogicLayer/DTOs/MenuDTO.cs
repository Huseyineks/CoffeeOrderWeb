using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderWeb.BusinessLogicLayer.DTOs
{
    public class MenuDTO
    {
        
        public string ProductName { get; set; }
        public string ProductContent { get; set; }
        public IFormFile ProductImage { get; set; }
        public string ProductPrice { get; set; }
    }
}
