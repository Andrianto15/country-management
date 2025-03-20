﻿using System.ComponentModel.DataAnnotations;

namespace CountryManagement.Models.Dtos
{
    public class UpdateCountryDto
    {
        [MaxLength(3)]
        public required string CountryCode { get; set; }
        [MaxLength(255)]
        public required string CountryName { get; set; }
    }
}
