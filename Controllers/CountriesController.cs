using CountryManagement.Interfaces;
using CountryManagement.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CountryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService countryService;
        private readonly ILogger<CountriesController> logger;

        public CountriesController(ICountryService countryService, ILogger<CountriesController> logger)
        {
            this.countryService = countryService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            logger.LogInformation("Request In. Fetching all countries");

            return Ok(await countryService.GetCountriesAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetCountryById(Guid id)
        {
            logger.LogInformation("Request In. Fetching country with ID: {CountryId}", id);

            var country = await countryService.GetCountryByIdAsync(id);
            if (country == null)
            {
                logger.LogWarning("Country with ID: {CountryId} not found", id);

                return NotFound();
            }
            return Ok(country);
        }

        [HttpPost]
        public async Task<IActionResult> AddCountry(AddCountryDto addUpdateCountryDto) {
            logger.LogInformation("Request In. Adding new country: {@Country}", addUpdateCountryDto);

            var country = await countryService.AddCountryAsync(addUpdateCountryDto);
            return CreatedAtAction(nameof(GetCountryById), new { id = country.Id }, country);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCountry(Guid id, UpdateCountryDto updateCountryDto)
        {
            logger.LogInformation("Request In. Updating country with ID: {CountryId}", id);

            var updatedCountry = await countryService.UpdateCountryAsync(id, updateCountryDto);
            if (updatedCountry == null)
            {
                logger.LogWarning("Country with ID: {CountryId} not found for update", id);

                return NotFound();
            }
            return Ok(updatedCountry);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteCountry(Guid id)
        {
            logger.LogInformation("Request In. Deleting country with ID: {CountryId}", id);

            var success = await countryService.DeleteCountryAsync(id);
            if (!success)
            {
                logger.LogWarning("Country with ID: {CountryId} not found for deletion", id);

                return NotFound();
            }

            return NoContent();
        }
    }
}
