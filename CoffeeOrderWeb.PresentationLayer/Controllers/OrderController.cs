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
        public IActionResult RemoveOrder(Guid? id)
        {
            _orderService.Remove(_orderService.Get(i => i.RowGuid == id));

            _orderService.Save();

            return RedirectToAction("Index","Basket");
        }
        public IActionResult Edit() { 
        
        
        return View();
        
        }
       
    }
}
