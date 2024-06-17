using CoffeeOrderWeb.BusinessLogicLayer.DTOs;
using CoffeeOrderWeb.EntityLayer.Model;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeOrderWeb.PresentationLayer.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly IValidator<UserInformationDTO> _validator;
        public UserController(UserManager<AppUser> userManager,IValidator<UserInformationDTO> validator) {
            
            _userManager = userManager;
            _validator = validator;
            
        }
        public async Task<IActionResult> MyAccount()
        {
            var user = await _userManager.GetUserAsync(User);

            

            UserInformationDTO userInformation = new UserInformationDTO()
            {
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                City = user.City,
                Region = user.Region,
                FullAdress = user.FullAdress,
                UserName = user.UserName,
                PostalCode = user.PostalCode
            };






            return View(userInformation);
        }
        [HttpPost]

        public async Task<IActionResult> MyAccount(UserInformationDTO userInformation)
        {
            var user = await _userManager.GetUserAsync(User);
            userInformation.AuthenticatedUserGuid = user.RowGuid;
            var check =  _validator.Validate(userInformation);
            
            

            foreach (var error in check.Errors) {

                ModelState.AddModelError(String.Empty, error.ErrorMessage);
            
            }
            if (ModelState.IsValid)
            {
                user.Name = userInformation.Name;
                user.LastName = userInformation.LastName;
                user.Email = userInformation.Email;
                user.City = userInformation.City;
                user.Region = userInformation.Region;
                user.UserName = userInformation.UserName;
                user.FullAdress = userInformation.FullAdress;
                if(userInformation.Password != null && await _userManager.CheckPasswordAsync(user, userInformation.currentPassword)) {

                   
                      var result = await _userManager.ChangePasswordAsync(user,userInformation.currentPassword,userInformation.Password);
                      if(!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(String.Empty,error.Description);
                        }
                    }
                
                
                }
            }

            await _userManager.UpdateAsync(user);
             
            

            
            




            return View();
        }
    }
}
