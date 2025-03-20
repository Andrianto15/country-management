using CountryManagement.Data;
using CountryManagement.Interfaces;
using CountryManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CountryManagement.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CountryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //public async Task<IReadOnlyList<Country>> GetCountriesAsync()
        //{
        //    return await dbContext.Countries.ToListAsync();
        //}

        public async Task<Country> GetCountryByIdAsync(Guid id)
        {
            return await dbContext.Countries.FindAsync(id);
        }

        public async Task<Country> AddCountryAsync(Country country)
        {
            await dbContext.Countries.AddAsync(country);
            await dbContext.SaveChangesAsync();

            return country;
        }

        public async Task<Country> UpdateCountryAsync(Country country)
        {
            dbContext.Countries.Update(country);
            await dbContext.SaveChangesAsync();

            return country;
        }

        public async Task DeleteCountryAsync(Country country)
        {
            dbContext.Countries.Remove(country);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Country>> GetCountriesAsync(string? nameFilter, int page, int pageSize)
        {
            var query = dbContext.Countries.AsQueryable();

            // Filter by Name
            if (!string.IsNullOrEmpty(nameFilter))
            {
                query = query.Where(c => c.CountryName.Contains(nameFilter));
            }

            // Paging
            return await query
                .OrderBy(c => c.CountryName)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetTotalCountriesAsync(string? nameFilter)
        {
            var query = dbContext.Countries.AsQueryable();

            if (!string.IsNullOrEmpty(nameFilter))
            {
                query = query.Where(c => c.CountryName.Contains(nameFilter));
            }

            return await query.CountAsync();
        }
    }
}
