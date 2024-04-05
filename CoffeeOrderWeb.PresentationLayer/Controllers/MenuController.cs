using CoffeeOrderWeb.BusinessLogicLayer.Abstract;
using CoffeeOrderWeb.BusinessLogicLayer.VMs;
using CoffeeOrderWeb.EntityLayer.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace CoffeeOrderWeb.PresentationLayer.Controllers
{
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailsService _orderDetailsService;
        private readonly UserManager<AppUser> _userManager;
        public MenuController(IMenuService menuService, IOrderService orderService, IOrderDetailsService orderDetailsService, UserManager<AppUser> userManager)
        {
            _menuService = menuService;
            _orderService = orderService;
            _orderDetailsService = orderDetailsService;
            _userManager = userManager;
            
        }
        public IActionResult Index()
        {
            

            MenuViewModel viewModel = new MenuViewModel()
            {
                menus = _menuService.GetAll()
            };
            return View(viewModel);
        }

        [HttpPost]

        public async Task<IActionResult> Index(MenuViewModel viewModel)
        {
            var menu = _menuService.Get(i => i.MenuId == viewModel.orderDetails.OrderId);
            var user = await _userManager.GetUserAsync(User);
            Order newOrder = new Order()
            {
                
                ProductName = menu.ProductName,
                ProductPrice = menu.ProductPrice,
                UserId = user.Id,
                Details = new OrderDetails()
                {
                    ColdOrHot = viewModel.orderDetails.ColdOrHot,
                    MoreCaffein = viewModel.orderDetails.MoreCaffein,
                    Note = viewModel.orderDetails.Note,
                    Size = viewModel.orderDetails.Size
                    
                }
        };
            _orderService.Add(newOrder);
            _orderService.Save();






            return RedirectToAction("Index","Menu");
        }
    }
}






