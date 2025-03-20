using CountryManagement.Models.Dtos;
using CountryManagement.Models.Entities;

namespace CountryManagement.Interfaces
{
    public interface ICountryRepository
    {
        //Task<IReadOnlyList<Country>> GetCountriesAsync();
        Task<Country> GetCountryByIdAsync(Guid id);
        Task<Country> AddCountryAsync(Country country);
        Task<Country> UpdateCountryAsync(Country country);
        Task DeleteCountryAsync(Country country);
        Task<IReadOnlyList<Country>> GetCountriesAsync(string? nameFilter, int page, int pageSize);
        Task<int> GetTotalCountriesAsync(string? nameFilter); // Total data
    }
}
