using CoffeeOrderWeb.BusinessLogicLayer.Abstract;
using CoffeeOrderWeb.BusinessLogicLayer.Concrete;
using CoffeeOrderWeb.BusinessLogicLayer.VMs;
using CoffeeOrderWeb.EntityLayer.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CoffeeOrderWeb.PresentationLayer.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMenuService _menuService;
        private readonly IOrderDetailsService _orderDetailsService;

        public OrderController(IOrderService orderService,UserManager<AppUser> userManager,IMenuService menuService,IOrderDetailsService orderDetailsService)
        {
            _orderService = orderService;
            _userManager = userManager;
            _menuService = menuService;
            _orderDetailsService = orderDetailsService;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder(MenuViewModel viewModel) {

            var menu = _menuService.Get(i => i.MenuId == viewModel.orderDetails.OrderId);
            var user = await _userManager.GetUserAsync(User);
            Order newOrder = new Order()
            {
                RowGuid = Guid.NewGuid(),
                ProductImage = menu.ProductImage,
                ProductName = menu.ProductName,
                ProductPrice = menu.ProductPrice,
                UserId = user.Id,
                Status = OrderStatus.InBasket,
                ProductCount = 1,
                Details = new OrderDetails()
                {
                    ColdOrHot = viewModel.orderDetails.ColdOrHot,
                    MoreCaffein = viewModel.orderDetails.MoreCaffein,
                    Note = viewModel.orderDetails.Note,
                    Size = viewModel.orderDetails.Size

                }

            };
            if (await checkIfSame(newOrder, user))
            {
                return RedirectToAction("Index", "Menu");
            }
            _orderService.Add(newOrder);
            _orderService.Save();






            return RedirectToAction("Index", "Menu");

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
        public IActionResult Reduce(Guid? guid)
        {
            var order = _orderService.Get(i => i.RowGuid == guid);
            if(order.ProductCount == 1) { 
            
                _orderService.Remove(order);
                _orderService.Save();
                return RedirectToAction("Index", "Home");
            
            }
            if (order.ProductPrice.Contains(','))
            {
                order.ProductPrice = order.ProductPrice.Replace(',', '.');
            }
            var floatPrice = float.Parse(order.ProductPrice, NumberStyles.Float, CultureInfo.InvariantCulture);
            var price = floatPrice - floatPrice / order.ProductCount;
            order.ProductCount--;


            order.ProductPrice = price.ToString();

            _orderService.Update(order);
            _orderService.Save();


            return RedirectToAction("Index", "Basket");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateOrder(BasketViewModel viewModel)
        {
            var order = _orderService.GetOrderDetails(i => i.OrderId == viewModel.orderDetails.OrderId)[0];
            var user = await _userManager.GetUserAsync(User);
          
            order.Details.Size = viewModel.orderDetails.Size;
            order.Details.ColdOrHot = viewModel.orderDetails.ColdOrHot;
            order.Details.MoreCaffein = viewModel.orderDetails.MoreCaffein;
            order.Details.Note = viewModel.orderDetails.Note;

            if (await checkIfSame(order, user))
            {
                _orderService.Remove(order);
                _orderService.Save();

                return RedirectToAction("Index", "Basket");
            }



            _orderService.Update(order);
            _orderService.Save();


            return RedirectToAction("Index", "Basket");
        }
        public async Task<bool> checkIfSame(Order newOrder, AppUser user)
        {
            var orders = _orderService.GetOrderDetails(i => i.UserId == user.Id).Where(i => i.Status == OrderStatus.InBasket).ToList();


            foreach (var order in orders)
            {
                if (order.Details.MoreCaffein == newOrder.Details.MoreCaffein &&
                     order.Details.Note.ToLower() == newOrder.Details.Note.ToLower() &&
                     order.Details.ColdOrHot == newOrder.Details.ColdOrHot &&
                     order.Details.Size == newOrder.Details.Size &&
                     order.ProductName == newOrder.ProductName)
                {
                    if (order.ProductPrice.Contains(','))
                    {
                        order.ProductPrice = order.ProductPrice.Replace(',', '.');
                    }
                    var floatPrice = float.Parse(order.ProductPrice, NumberStyles.Float, CultureInfo.InvariantCulture);
                    var totalPrice = floatPrice + floatPrice / order.ProductCount;
                    order.ProductPrice = totalPrice.ToString();
                    order.ProductCount++;
                    _orderService.Update(order);
                    _orderService.Save();
                    return true;
                }
            }
            return false;

        }

    }
}
