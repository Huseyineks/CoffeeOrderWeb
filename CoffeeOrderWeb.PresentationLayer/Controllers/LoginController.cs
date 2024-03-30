using CoffeeOrderWeb.BusinessLogicLayer.VMs;
using CoffeeOrderWeb.EntityLayer.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeOrderWeb.PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Index(LoginViewModel user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password,false,true);
            
            if (result.Succeeded)
            {
                
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ModelState.AddModelError(String.Empty, "Kullanıcı adı veya parola hatalı.");
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
