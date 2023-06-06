using ExampleWebApplication.Dtos;
using ExampleWebApplication.Models;
using ExampleWebApplication.Models.Daos;
using ExampleWebApplication.Models.Dtos;

namespace ExampleWebApplication.Interfaces;

public interface IPokemonMapper: IMapper<Pokemon, PokemonDao> { }