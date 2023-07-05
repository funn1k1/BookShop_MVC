﻿using Microsoft.AspNetCore.Identity;

namespace BookShopWeb.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public int PostalCode { get; set; }
    }
}