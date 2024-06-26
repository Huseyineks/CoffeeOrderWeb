﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeOrderWeb.BusinessLogicLayer.DTOs
{
    public class UserInformationDTO
    {
        public string UserName { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string? Password { get; set; }

        public string? confirmPassword { get; set; }

        public string? currentPassword { get; set; }

        public string City { get; set; }

        public string Region { get; set; }

        public string PostalCode { get; set; }

        public string FullAdress { get; set; }

        // if user authenticated then we have to check by using guid

        public Guid? AuthenticatedUserGuid { get; set; }
    
}
}
