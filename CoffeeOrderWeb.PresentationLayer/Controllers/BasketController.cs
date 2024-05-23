using CoffeeOrderWeb.BusinessLogicLayer.Abstract;
using CoffeeOrderWeb.BusinessLogicLayer.VMs;
using CoffeeOrderWeb.EntityLayer.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace CoffeeOrderWeb.PresentationLayer.Controllers
{
    public class BasketController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IOrderDetailsService _orderDetailsService;
        private readonly UserManager<AppUser> _userManager;
        public BasketController(IOrderService orderService,UserManager<AppUser> userManager, IOrderDetailsService orderDetailsService)
        {

            _orderService = orderService;
            _userManager = userManager;
            _orderDetailsService = orderDetailsService;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var userOrders= _orderService.GetOrderDetails(i => i.UserId == user.Id);
            userOrders = userOrders.AsQueryable().Where(i => i.Status == OrderStatus.InBasket).ToList();
            BasketViewModel basketViewModel = new BasketViewModel()
            {
                orders = userOrders,
                orderDetails = null

            };

          
            

            return View(basketViewModel);
        }


        [HttpPost]
        public  IActionResult Index(BasketViewModel viewModel)
        {

            var orderDetail = _orderDetailsService.Get(i => i.orderId == viewModel.orderDetails.OrderId);
            orderDetail.ColdOrHot = viewModel.orderDetails.ColdOrHot;
            orderDetail.Size = viewModel.orderDetails.Size;
            orderDetail.MoreCaffein = viewModel.orderDetails.MoreCaffein;
            orderDetail.Note = viewModel.orderDetails.Note;

            _orderDetailsService.Update(orderDetail);
            _orderDetailsService.Save();


            return RedirectToAction("Index","Basket");
        }

         
    }
}
