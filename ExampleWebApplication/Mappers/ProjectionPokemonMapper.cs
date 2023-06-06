using ExampleWebApplication.Dtos;
using ExampleWebApplication.Interfaces;
using ExampleWebApplication.Models;
using ExampleWebApplication.Models.Daos;
using ExampleWebApplication.Models.Dtos;
using Riok.Mapperly.Abstractions;

namespace ExampleWebApplication.Mappers;

public static class ProjectionPokemonMapper
{

    public static IQueryable<Pokemon> ProjectToDto(this IQueryable<PokemonDao> pokemonDao) =>
        pokemonDao.Select(e => new Pokemon
        {
            Id = e.Id,
            Name = e.Name,
            BirthDate = e.BirthDate,
            Categories = e.Categories.Select(categoryDao => new Category {Id = categoryDao.Id, Name = categoryDao.Name}),
            Owners = e.Owners.Select(dao => new Owner {Id = dao.Id, Gym = dao.Gym, Name = dao.Name})
        });

}