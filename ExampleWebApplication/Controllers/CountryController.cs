using ExampleWebApplication.Dtos;
using ExampleWebApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWebApplication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CountryController: ControllerBase
{
    private readonly ICountryRepository _countryRepository;
    private readonly ICountryMapper _categoryMapper;
    private readonly IOwnerMapper _ownerMapper;

    public CountryController(ICountryRepository countryRepository, ICountryMapper categoryMapper, IOwnerMapper ownerMapper)
    {
        _countryRepository = countryRepository;
        _categoryMapper = categoryMapper;
        _ownerMapper = ownerMapper;
    }

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Country>))]
    public IActionResult GetAll()
    {
        return Ok(_categoryMapper.ToDtos(_countryRepository.GetAllCountries()));
    }

    [HttpGet("{countryId}")]
    [ProducesResponseType(200, Type = typeof(Country))]
    public IActionResult Get(int countryId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        if (!_countryRepository.CountryExistsById(countryId))
        {
            return NotFound();
        }

        return Ok(_categoryMapper.ToDto(_countryRepository.GetCountryById(countryId)!));
    }

    [HttpGet("{countryId}/owners")]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Owner>))]
    public IActionResult GetOwnersByCountryId(int countryId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        
        if (!_countryRepository.CountryExistsById(countryId))
        {
            return NotFound();
        }

        return Ok(_ownerMapper.ToDtos(_countryRepository.GetOwnersByCountryId(countryId)));

    }

    [HttpPost]
    public IActionResult Create(Country country)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        return Ok(_countryRepository.Create(_categoryMapper.ToDao(country)));
    }
}