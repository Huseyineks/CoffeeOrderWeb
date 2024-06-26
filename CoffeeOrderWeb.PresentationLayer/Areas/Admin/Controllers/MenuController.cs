﻿using CoffeeOrderWeb.BusinessLogicLayer.Abstract;
using CoffeeOrderWeb.BusinessLogicLayer.DTOs;
using CoffeeOrderWeb.BusinessLogicLayer.VMs;
using CoffeeOrderWeb.EntityLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeOrderWeb.PresentationLayer.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMenuService _menuService;
        public MenuController(IMenuService menuService,IWebHostEnvironment webHostEnvironment) { 
        
            _menuService = menuService;
            _webHostEnvironment = webHostEnvironment;
        
        }

        [HttpGet]
        public IActionResult Index()
        {
            MenuViewModel model = new MenuViewModel()
            {
                menus = _menuService.GetAll(),
                
            };
            return View(model);
        }

       
        private string UploadFile(MenuDTO menu)
        {
            string? fileName = null;

            if (menu.ProductImage != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + '-' + menu.ProductImage.FileName;
                string filePath = Path.Combine(uploadDir, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    menu.ProductImage.CopyTo(fileStream);
                }
            }
            return fileName;
        }

        public IActionResult AddMenu() {


            return View();
        
        }

        [HttpPost]
        public IActionResult AddMenu(MenuDTO menu) { 
        
        string fileName = UploadFile(menu);

            Menu newMenu = new Menu()
            {
                ProductContent = menu.ProductContent,
                ProductImage = fileName,
                ProductName = menu.ProductName,
                ProductPrice = menu.ProductPrice
            };

            _menuService.Add(newMenu);

            _menuService.Save();

            return Redirect("/Admin/Menu/Index");
        
        
        }
        public IActionResult EditMenu(int ?id) { 
        
        Menu menu = _menuService.Get(i => i.MenuId == id);

        return View(menu);
        
        
        }
        [HttpPost]

        public IActionResult EditMenu(Menu updatedMenu)
        {
            _menuService.Update(updatedMenu);
            _menuService.Save();

            return Redirect("/Admin/Menu/Index");
        }
       

        
        public IActionResult RemoveMenu(int? id)
        {
            _menuService.Remove(_menuService.Get(i => i.MenuId == id));

            _menuService.Save();

            return Redirect("/Admin/Menu/Index");
        }
    }
}
