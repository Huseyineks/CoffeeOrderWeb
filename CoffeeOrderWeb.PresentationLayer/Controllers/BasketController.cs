using CoffeeOrderWeb.BusinessLogicLayer.Abstract;
using CoffeeOrderWeb.BusinessLogicLayer.VMs;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeOrderWeb.PresentationLayer.Controllers
{
    public class BasketController : Controller
    {
        private readonly IMenuService _menuService;
        public BasketController(IMenuService menuService) { 
        
            _menuService = menuService;
        
        }
        public IActionResult Index()
        {
            MenuViewModel model = new MenuViewModel()
            {
                menus = _menuService.GetAll()
            };

            return View(model);
        }
    }
}
