using API_Airbnb.Data.Context;
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.GenericRepository;

namespace API_Airbnb.Data.Repositories.CountryRepository
{
    public class CountryRepository : GenericRepository<ArCountries>, ICountryRepository
    {
        public readonly AirbnbContext _context;
        public CountryRepository(AirbnbContext context) : base(context)
        {
            _context = context;
        }
    
    }
}
