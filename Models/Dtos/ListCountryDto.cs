using System.ComponentModel.DataAnnotations;

namespace CountryManagement.Models.Dtos
{
    public class ListCountryDto
    {
        public required string CountryCode { get; set; }
        public required string CountryName { get; set; }
    }
}
