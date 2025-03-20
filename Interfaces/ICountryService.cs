using CountryManagement.Models.Dtos;
using CountryManagement.Models.Entities;

namespace CountryManagement.Interfaces
{
    public interface ICountryService
    {
        Task<IReadOnlyList<ListCountryDto>> GetCountriesAsync();
        Task<Country?> GetCountryByIdAsync(Guid id);
        Task<Country> AddCountryAsync(AddCountryDto addCountryDto);
        Task<Country?> UpdateCountryAsync(Guid id, UpdateCountryDto updateCountryDto);
        Task<bool> DeleteCountryAsync(Guid id);
    }
}
