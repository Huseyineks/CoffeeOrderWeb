using CoffeeOrderWeb.BusinessLogicLayer.Abstract;
using CoffeeOrderWeb.BusinessLogicLayer.VMs;
using CoffeeOrderWeb.EntityLayer.Model;
using Microsoft.AspNetCore.Authorization;
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
       
            
        }
        public IActionResult Index()
        {
            

            MenuViewModel viewModel = new MenuViewModel()
            {
                menus = _menuService.GetAll()
            };
            return View(viewModel);
        }

     
    }
}






