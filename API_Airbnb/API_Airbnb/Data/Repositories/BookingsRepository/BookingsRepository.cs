using API_Airbnb.Data.Context;
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.GenericRepository;

namespace API_Airbnb.Data.Repositories.BookingsRepository
{
    public class BookingsRepository : GenericRepository<ArBookings>, IBookingsRepository
    {
        private readonly AirbnbContext _context;

        public BookingsRepository(AirbnbContext context) : base(context)
        {
            _context = context;
        }
    }
}
