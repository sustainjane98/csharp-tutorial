using ExampleWebApplication.Models;
using ExampleWebApplication.Models.Daos;

namespace ExampleWebApplication.Interfaces;

public interface ICountryRepository
{
    public ICollection<Country> GetAllCountries();

    public Country? GetCountryById(int id);

    public ICollection<OwnerDao> GetOwnersByCountryId(int countryId);

    public bool CountryExistsById(int id);

    public bool Create(Country country);
    
    public bool Save();
}