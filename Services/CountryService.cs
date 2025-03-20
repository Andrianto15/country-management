using CountryManagement.Interfaces;
using CountryManagement.Models.Dtos;
using CountryManagement.Models.Entities;
using CountryManagement.Repositories;

namespace CountryManagement.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository countryRepository;
        private readonly ILogger<CountryRepository> logger;

        public CountryService(ICountryRepository countryRepository, ILogger<CountryRepository> logger)
        {
            this.countryRepository = countryRepository;
            this.logger = logger;
        }

        public async Task<IReadOnlyList<ListCountryDto>> GetCountriesAsync()
        {
            var countries = await countryRepository.GetCountriesAsync();

            logger.LogInformation("Fetching all countries from database.");

            return countries.Select(c => new ListCountryDto { CountryCode = c.CountryCode, CountryName = c.CountryName }).ToList();
        }

        public async Task<Country?> GetCountryByIdAsync(Guid id)
        {
            logger.LogInformation("Fetching country with ID: {CountryId}", id);

            return await countryRepository.GetCountryByIdAsync(id);
        }

        public async Task<Country> AddCountryAsync(AddCountryDto addCountryDto)
        {
            var current_date = DateTime.Now;
            var country = new Country
            {
                CountryCode = addCountryDto.CountryCode,
                CountryName = addCountryDto.CountryName,
                CreatedDate = current_date,
                ModifiedDate = current_date
            };

            logger.LogInformation("Adding a new country: {@Country}", country);

            return await countryRepository.AddCountryAsync(country);
        }

        public async Task<Country?> UpdateCountryAsync(Guid id, UpdateCountryDto updateCountryDto)
        {
            var existingCountry = await countryRepository.GetCountryByIdAsync(id);
            if (existingCountry == null)
            {
                return null;
            }

            existingCountry.CountryCode = updateCountryDto.CountryCode;
            existingCountry.CountryName = updateCountryDto.CountryName;
            existingCountry.ModifiedDate = DateTime.Now;

            logger.LogInformation("Updating country with ID: {CountryId}", id);

            return await countryRepository.UpdateCountryAsync(existingCountry);
        }

        public async Task<bool> DeleteCountryAsync(Guid id)
        {
            var existingCountry = await countryRepository.GetCountryByIdAsync(id);
            if (existingCountry == null)
            {
                return false;
            }

            logger.LogInformation("Deleting country with ID: {CountryId}", id);

            await countryRepository.DeleteCountryAsync(existingCountry);
            return true;
        }
    }
}
