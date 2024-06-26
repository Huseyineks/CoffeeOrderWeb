﻿using CoffeeOrderWeb.BusinessLogicLayer.DTOs;
using CoffeeOrderWeb.EntityLayer.Model;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderWeb.BusinessLogicLayer.Validators
{
    public class UserInformationValidator : AbstractValidator<UserInformationDTO>
    {
        private readonly UserManager<AppUser> _userManager;
        private IQueryable<AppUser> _users;
        private readonly AppUser? _currentUser;

        

        public UserInformationValidator(UserManager<AppUser> userManager) {

            _userManager = userManager;
            _users = _userManager.Users.AsQueryable();

            RuleFor(x => x.AuthenticatedUserGuid).Must(IsAuthenticated);
            RuleFor(x => x.Email).EmailAddress().WithMessage("Please enter a valid email.").Must(ExistEmail).WithMessage("Email is used.");
            RuleFor(x => x.Password).Equal(x => x.confirmPassword).WithMessage("Make sure passwords are equal").Must(ExistPassword).WithMessage("Password exist.");
            RuleFor(x => x.UserName).Must(ExistUserName).WithMessage("Username is used.");
            RuleFor(x => x.Name).Must(beAlphabetic).WithMessage("Please enter a valid name.").MinimumLength(3).WithMessage("Your name is short");
            RuleFor(x => x.LastName).Must(beAlphabetic).WithMessage("Please enter a valid lastname.").MinimumLength(3).WithMessage("Your lastname is short");
            RuleFor(x => x.PostalCode).Must(beNumeric).WithMessage("Please enter a valid postal code.");
            

            


        }

        private bool IsAuthenticated(Guid? guid)
        {
            if(guid == null)
            {
                return false;
            }
            _users = _users.Where(i => i.RowGuid != guid);
            return true;
        }
      
     
        private bool beNumeric(string value)
        {
            if (value != null)
            {
                return int.TryParse(value, out _);
            }
            return true;
        }
        private bool beAlphabetic(string value)
        {

            if (value != null)
            {
                return value.All(char.IsLetter);
                
            }
            return true;
        }
        
        private bool ExistUserName(string userName)
        {
            var User = _users.Where(i => i.UserName == userName).FirstOrDefault();

            if(User == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool ExistPassword(string password) { 
        
        var User = _users.Where(i => i.PasswordHash == password).FirstOrDefault();

        

        if (User == null)
        {
            return true;
        }
        else
        {
            return false;
        }
        }
        private bool ExistEmail(string email)
        {

        var User = _users.Where(i => i.Email == email).FirstOrDefault();


        if (User == null)
        {
          return true;
        }
        else
        {
          return false;
        }



        }
    }
}
