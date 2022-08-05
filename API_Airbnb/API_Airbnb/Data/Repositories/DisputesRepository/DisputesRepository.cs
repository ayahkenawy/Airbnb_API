using API_Airbnb.Data.Context;
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.GenericRepository;

namespace API_Airbnb.Data.Repositories.DisputesRepository
{
    public class DisputesRepository : GenericRepository<ArDisputes>, IDisputesRepository
    {
        public readonly AirbnbContext _context;
        public DisputesRepository(AirbnbContext context) : base(context)
        {
            _context = context;
        }
        public List<ArDisputes>? GetByBookingId(int id)
        {
            return _context.ArDisputes.Where(b=>b.BookingId==id && b.Status==true).ToList();
        }
        public List<ArDisputes>? GetByPropertyId(int id)
        {
            return _context.ArDisputes.Where(u => u.PropertyId == id && u.Status==true).ToList();
        }


    }
}
