using CoffeeOrderWeb.BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeOrderWeb.PresentationLayer.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public IActionResult Delete(int? id)
        {
            _orderService.Delete(_orderService.Get(i => i.OrderId == id));

            _orderService.Save();

            return View();
        }
        public IActionResult Edit() { 
        
        
        return View();
        
        }
       
    }
}
