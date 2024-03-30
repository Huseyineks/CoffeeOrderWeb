using CoffeeOrderWeb.BusinessLogicLayer.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderWeb.BusinessLogicLayer.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserDTO>
    {
        public RegisterUserValidator() {

            RuleFor(x => x.Email).EmailAddress().WithMessage("Please enter a valid email.");
            RuleFor(x => x.Password).Equal(x => x.confirmPassword).WithMessage("Make sure passwords are equal");
        }
    }
}
