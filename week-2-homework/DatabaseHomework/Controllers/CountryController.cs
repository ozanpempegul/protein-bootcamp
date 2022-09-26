using DatabaseHomework.Models;
using DatabaseHomework.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseHomework.Controllers;

[Route("countries")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly ICountryRepository _countryRepository;
    

    public CountryController(ICountryRepository countryRepository)
    {
        _countryRepository = countryRepository;
    }

    [HttpGet("GetCountry/{id}")]
    public async Task<IActionResult> GetCountry(int id)
    {
        Country country = await _countryRepository.GetCountry(id);
        if (country == null) return NotFound();
        return Ok(country);
    }

    [HttpGet("GetCountries")]
    public async Task<IActionResult> GetAllCountries()
    {
        IEnumerable<Country> countries = await _countryRepository.GetAllCountries();
        return Ok(countries);
    }

    [HttpPut("UpdateCountry")]
    public async Task<IActionResult> UpdateCountry([FromQuery] Country country)
    {
        _countryRepository.UpdateCountry(country);
        return Ok(country);
    }

    [HttpPost("AddNewCountry")]
    public async Task<IActionResult> AddNewCountry(Country country)
    {
        _countryRepository.AddCountry(country);
        return Ok(country);
    }

    [HttpDelete("DeleteCountry/{id}")]
    public async Task<IActionResult> DeleteCountry(int id)
    {
        Country country = await _countryRepository.GetCountry(id);
        _countryRepository.DeleteCountry(id);
        return Ok(country);
    }
}
