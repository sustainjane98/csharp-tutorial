using ExampleWebApplication.Dtos;
using ExampleWebApplication.Interfaces;
using ExampleWebApplication.Models;
using Riok.Mapperly.Abstractions;
using Country = ExampleWebApplication.Dtos.Country;

namespace ExampleWebApplication.Mappers;

[Mapper]
public partial class CountryMapper: ICountryMapper
{
    public partial Country ToDto(Models.Daos.Country category);

    public partial ICollection<Country> ToDtos(ICollection<Models.Daos.Country> category);

    public partial Models.Daos.Country ToDao(Country category);

    public partial ICollection<Models.Daos.Country> ToDaos(ICollection<Country> categoryDto);
}