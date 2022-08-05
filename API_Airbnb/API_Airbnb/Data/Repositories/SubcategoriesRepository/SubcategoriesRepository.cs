
using API_Airbnb.Data.Context;
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.GenericRepository;

namespace API_Airbnb.Data.Repositories.SubcategoriesRepository
{
    public class SubcategoriesRepository : GenericRepository<ArSubcategories>, ISubcategoriesRepository
    {
        public readonly AirbnbContext _context;
        public SubcategoriesRepository(AirbnbContext context) : base(context)
        {
            _context = context;
        }

    }
}


