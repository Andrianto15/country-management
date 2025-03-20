﻿using CountryManagement.Data;
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

        public async Task<IReadOnlyList<Country>> GetCountriesAsync()
        {
            return await dbContext.Countries.ToListAsync();
        }

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
    }
}
