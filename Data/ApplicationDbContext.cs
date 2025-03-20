using CountryManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CountryManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }
    }
}
