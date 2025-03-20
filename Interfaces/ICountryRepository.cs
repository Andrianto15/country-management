using CountryManagement.Models.Dtos;
using CountryManagement.Models.Entities;

namespace CountryManagement.Interfaces
{
    public interface ICountryRepository
    {
        Task<IReadOnlyList<Country>> GetCountriesAsync();
        Task<Country> GetCountryByIdAsync(Guid id);
        Task<Country> AddCountryAsync(Country country);
        Task<Country> UpdateCountryAsync(Country country);
        Task DeleteCountryAsync(Country country);
    }
}
