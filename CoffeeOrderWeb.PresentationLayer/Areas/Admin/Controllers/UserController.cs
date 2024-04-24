﻿using CoffeeOrderWeb.EntityLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoffeeOrderWeb.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public UserController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();

            return View(users);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser.Id == user.Id)
            {
                await _userManager.DeleteAsync(user);
                await _signInManager.SignOutAsync();

            }

            else if (user != null)
            {
                await _userManager.DeleteAsync(user);

            }
            return Redirect("/Admin/User/Index");
        }

    }
}
