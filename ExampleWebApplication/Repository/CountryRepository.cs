using ExampleWebApplication.Interfaces;
using ExampleWebApplication.Models;
using ExampleWebApplication.Models.Daos;

namespace ExampleWebApplication.Repository;

public class CountryRepository: ICountryRepository
{
    private readonly ApplicationDbContext _context;

    public CountryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public ICollection<Country> GetAllCountries()
    {
        return _context.Countries.ToList();
    }

    public Country? GetCountryById(int id)
    {
        return _context.Countries.FirstOrDefault(p => p.Id == id);
    }

    public ICollection<OwnerDao> GetOwnersByCountryId(int countryId)
    {

        return _context.Owners.Where(p => p.CountryId== countryId).ToList();
        
        return _context.Countries.Where(p => p.Id == countryId).SelectMany(p => p.Owners).ToList();
    }

    public bool CountryExistsById(int id) => _context.Countries.Any(e => e.Id == id);
    public bool Create(Country country)
    {
        _context.Countries.Add(country);

        return Save();
    }

    public bool Save()
    {
        return _context.SaveChanges() > 0;
    }
}