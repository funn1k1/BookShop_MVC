﻿using System.ComponentModel.DataAnnotations;

namespace BookShopWeb.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }

        public string? PostalCode { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
