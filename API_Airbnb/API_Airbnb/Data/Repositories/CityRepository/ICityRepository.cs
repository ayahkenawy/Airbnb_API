using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.GenericRepository;

namespace API_Airbnb.Data.Repositories.CityRepository
{
    public interface ICityRepository : IGenericRepository<ArCities>
    {
        public List<ArCities> GetByCountryID(int countryID);    
    }
}
