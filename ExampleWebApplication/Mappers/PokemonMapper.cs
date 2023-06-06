using ExampleWebApplication.Dtos;
using ExampleWebApplication.Interfaces;
using ExampleWebApplication.Models;
using ExampleWebApplication.Models.Daos;
using ExampleWebApplication.Models.Dtos;
using Riok.Mapperly.Abstractions;

namespace ExampleWebApplication.Mappers;

[Mapper]
public partial class PokemonMapper: IPokemonMapper
{
    public partial Pokemon ToDto(PokemonDao pokemonDao);
    public partial ICollection<Pokemon> ToDtos(ICollection<PokemonDao> pokemons);
    public partial PokemonDao ToDao(Pokemon pokemon);
    public partial ICollection<PokemonDao> ToDaos(ICollection<Pokemon> pokemonDto);
}