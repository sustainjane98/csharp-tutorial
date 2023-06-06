using ExampleWebApplication.Dtos;
using ExampleWebApplication.Interfaces;
using ExampleWebApplication.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ExampleWebApplication.Controllers;

public class CategoryController: ODataController
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly ICategoryMapper _mapper;
    private readonly IPokemonMapper _pokemonMapper;

    public CategoryController(ICategoryRepository categoryRepository, ICategoryMapper mapper, IPokemonMapper pokemonMapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _pokemonMapper = pokemonMapper;
    }

    [HttpGet]
    [EnableQuery]
    public IActionResult Get()
    {
        return Ok(_categoryRepository.GetCategories().ProjectToDto());
    }

    [EnableQuery]
    public IActionResult Get([FromODataUri] int key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        if (!_categoryRepository.CategoryExists(key))
        {
            return NotFound();
        }

        return Ok(_categoryRepository.GetCategory(key).ProjectToDto());
    }

    [EnableQuery()]
    public IActionResult GetPokemonsByCategoryId(int categoryId)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        if (!_categoryRepository.CategoryExists(categoryId))
        {
            return NotFound();
        }

        return Ok(_pokemonMapper.ToDtos(_categoryRepository.GetPokemonsByCategoryId((categoryId))));
    }
    
}