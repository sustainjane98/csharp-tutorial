using ExampleWebApplication.Dtos;
using ExampleWebApplication.Interfaces;
using ExampleWebApplication.Mappers;
using ExampleWebApplication.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ExampleWebApplication.Controllers;

public class PokemonController: ODataController
{
    private readonly IPokemonRepository _pokemonRepository;
    private readonly IPokemonMapper _mapper;


    public PokemonController(IPokemonRepository pokemonRepository, IPokemonMapper mapper)
    {
        _pokemonRepository = pokemonRepository;
        _mapper = mapper;
    }
    
    [EnableQuery]
    public ActionResult<IQueryable<Pokemon>> Get()
    {
        var pokemons = (_pokemonRepository.GetPokemons().ProjectToDto());
        
        return Ok(pokemons);
    }
    
    [EnableQuery]
    public IActionResult Get([FromODataUri] int key)
    {
        
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        if (!_pokemonRepository.PokemonExists(key))
        {
            return NotFound();
        }

        return Ok(_pokemonRepository.GetPokemon(key).ProjectToDto());
    }
    
    [HttpPost]
    [ProducesResponseType(200, Type= typeof(int))]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [Consumes("application/json")]
    public async Task<IActionResult> Post (Pokemon pokemon)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var (result, isSaved) = await _pokemonRepository.CreateAsync(_mapper.ToDao(pokemon));


        if (isSaved)
        {
            return Created(result);
        }

        return BadRequest("Entity not saved");
    }

    [ProducesResponseType(200, Type= typeof(int))]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> Patch([FromODataUri] int key, Delta<Pokemon> pokemon)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        if (!_pokemonRepository.PokemonExists(key))
        {
            return BadRequest("Entity doesn't exist");
        }

        var (id, isSaved) = await _pokemonRepository.UpdateAsync(_mapper.ToDao(pokemon.GetInstance()));

        if (isSaved)
        {
            return Updated(id);
        }
        
        return BadRequest("Entity not updated");
    }

}