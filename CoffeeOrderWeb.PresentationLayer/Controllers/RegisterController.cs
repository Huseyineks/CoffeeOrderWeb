﻿using CoffeeOrderWeb.BusinessLogicLayer.DTOs;
using CoffeeOrderWeb.EntityLayer.Model;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeOrderWeb.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly IValidator<UserInformationDTO> _validator;

        public RegisterController(UserManager<AppUser> userManager,IValidator<UserInformationDTO> validator)
        {
            _userManager = userManager;
            _validator = validator;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]

        public async Task<IActionResult> Index(UserInformationDTO newUser)
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
                    FullAdress = newUser.FullAdress,
                    EmailConfirmed = true,
                    RowGuid = Guid.NewGuid()

                };
                var result = await _userManager.CreateAsync(user,newUser.Password);

                if (result.Succeeded) {
                    await _userManager.AddToRoleAsync(user, "Admin");
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
            

            

        }
    }
}
