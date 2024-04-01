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
                // Kullan�c� bilgilerine eri�im
                var userName = user.Name;
                var email = user.Email;
                var lastname = user.LastName;


                // Eri�ilen bilgileri kullanarak i�lem yapabilirsiniz
                // �rne�in, bir view'e bu bilgileri g�ndererek g�r�nt�leme yapabilirsiniz
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
                // Kullan�c� bulunamad� veya kimlik do�rulanamad�
                // �lgili i�lemi ger�ekle�tirin, �rne�in hata sayfas�na y�nlendirin
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
