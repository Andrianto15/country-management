using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CountryManagement.Models.Entities
{
    public class Country
    {
        public Guid Id { get; set; }
        [MaxLength(3)]
        public required string CountryCode { get; set; }
        [MaxLength(255)]
        public required string CountryName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
