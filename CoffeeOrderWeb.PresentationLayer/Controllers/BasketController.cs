using CoffeeOrderWeb.BusinessLogicLayer.Abstract;
using CoffeeOrderWeb.BusinessLogicLayer.VMs;
using CoffeeOrderWeb.EntityLayer.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeOrderWeb.PresentationLayer.Controllers
{
    public class BasketController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<AppUser> _userManager;
        public BasketController(IOrderService orderService,UserManager<AppUser> userManager) {

            _orderService = orderService;
            _userManager = userManager;
        
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            List<Order> userOrders = _orderService.GetClassifiedList(i => i.UserId == user.Id);
            

            return View(userOrders);
        }
    }
}
