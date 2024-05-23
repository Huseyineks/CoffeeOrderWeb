using CoffeeOrderWeb.BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

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
        
        public IActionResult AddMore(Guid ?guid)
        {
            var order = _orderService.Get(i => i.RowGuid == guid);
            if (order.ProductPrice.Contains(','))
            {
                order.ProductPrice = order.ProductPrice.Replace(',', '.');
            }
            var floatPrice = float.Parse(order.ProductPrice, NumberStyles.Float, CultureInfo.InvariantCulture);
            var price = floatPrice + floatPrice/order.ProductCount;
            order.ProductCount++;

            
            order.ProductPrice = price.ToString();

            _orderService.Update(order);
            _orderService.Save();


            return RedirectToAction("Index","Basket");
        }
       
    }
}
