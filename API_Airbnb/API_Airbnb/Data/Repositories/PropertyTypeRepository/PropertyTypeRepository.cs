using API_Airbnb.Data.Context;
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.GenericRepository;

namespace API_Airbnb.Data.Repositories.PropertyTypeRepository
{
    public class PropertyTypeRepository : GenericRepository<ArPropertyType>, IPropertyTypeRepository
    {
        private readonly AirbnbContext _context;

        public PropertyTypeRepository(AirbnbContext context) : base(context)
        {
            _context = context;
        }
    }
}
