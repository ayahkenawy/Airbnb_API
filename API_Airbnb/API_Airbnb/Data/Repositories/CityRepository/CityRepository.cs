using API_Airbnb.Data.Context;
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.GenericRepository;

namespace API_Airbnb.Data.Repositories.CityRepository
{
    public class CityRepository : GenericRepository<ArCities>, ICityRepository
    {
        public readonly AirbnbContext _context;
        public CityRepository(AirbnbContext context) : base(context)
        {
            _context = context;
        }

        public List<ArCities> GetByCountryID(int countryID)
        {
           return _context.ArCities.Where(ctry=>ctry.CountryId==countryID).ToList();
        }
    }
}
