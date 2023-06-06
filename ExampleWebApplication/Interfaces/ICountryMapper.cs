using ExampleWebApplication.Dtos;
using ExampleWebApplication.Models;
using Country = ExampleWebApplication.Dtos.Country;

namespace ExampleWebApplication.Interfaces;

public interface ICountryMapper: IMapper<Country, Models.Daos.Country>{};