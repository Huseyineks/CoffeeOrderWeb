using CoffeeOrderWeb.BusinessLogicLayer.Abstract;
using CoffeeOrderWeb.EntityLayer.Model;
using CoffeeOrderWeb.PresentationLayer.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoffeeOrderWeb.PresentationLayer.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly UserManager<AppUser> _userManager;

        

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
            


        }

        public async Task<IActionResult> Index() {
            
            var user = await _userManager.GetUserAsync(User);
            
            if (user != null)
            {
                // Kullanýcý bilgilerine eriþim
                var userName = user.Name;
                var email = user.Email;
                var lastname = user.LastName;


                // Eriþilen bilgileri kullanarak iþlem yapabilirsiniz
                // Örneðin, bir view'e bu bilgileri göndererek görüntüleme yapabilirsiniz
                return View(new AppUser
                {
                    Name = userName,
                    Email = email,
                    LastName = lastname,
                    EmailConfirmed = User.Identity.IsAuthenticated
                });
            }
            else
            {
                // Kullanýcý bulunamadý veya kimlik doðrulanamadý
                // Ýlgili iþlemi gerçekleþtirin, örneðin hata sayfasýna yönlendirin
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
