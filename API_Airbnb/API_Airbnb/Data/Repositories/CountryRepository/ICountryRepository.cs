using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.GenericRepository;

namespace API_Airbnb.Data.Repositories.CountryRepository
{
    public interface ICountryRepository : IGenericRepository<ArCountries>
    {
    }
}
