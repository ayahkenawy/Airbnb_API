using API_Airbnb.Data.Context;
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.GenericRepository;

namespace API_Airbnb.Data.Repositories.PropertyReviewsRepository
{
    public class PropertyReviewsRepository:GenericRepository<ArPropertyReviews>, IPropertyReviewsRepository
    {
        public readonly AirbnbContext _context;
    public PropertyReviewsRepository(AirbnbContext context) : base(context)
    {
        _context = context;
    }
        public List<ArPropertyReviews>? GetByBookingId(int id)
        {
            return _context.ArPropertyReviews.Where(b => b.BookingId == id && b.Status == true).ToList();
        }
        public List<ArPropertyReviews>? GetByPropertyId(int id)
        {
            return _context.ArPropertyReviews.Where(u => u.PropertyId == id && u.Status == true).ToList();
        }

    }
}
