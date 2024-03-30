using CoffeeOrderWeb.BusinessLogicLayer.DTOs;
using CoffeeOrderWeb.EntityLayer.Model;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeOrderWeb.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly IValidator<RegisterUserDTO> _validator;

        public RegisterController(UserManager<AppUser> userManager,IValidator<RegisterUserDTO> validator)
        {
            _userManager = userManager;
            _validator = validator;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Index(RegisterUserDTO newUser)
        {
            var check = _validator.Validate(newUser);

            foreach(var error in check.Errors)
            {
                ModelState.AddModelError(String.Empty, error.ErrorMessage);
            }

            if(!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                AppUser user = new AppUser()
                {
                    Name = newUser.Name,
                    LastName = newUser.LastName,
                    Email = newUser.Email,
                    UserName = newUser.UserName,
                    City = newUser.City,
                    Region = newUser.Region,
                    PostalCode = newUser.PostalCode,
                    FullAdress = newUser.FullAdress

                };
                var result = await _userManager.CreateAsync(user,newUser.Password);

                if (result.Succeeded) {

                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(String.Empty, error.Description);
                    }

                    
                }

                return View(newUser);
            }
            

            return View();

        }
    }
}
