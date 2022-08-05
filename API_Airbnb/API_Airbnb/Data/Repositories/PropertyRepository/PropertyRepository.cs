using API_Airbnb.Data.Context;
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace API_Airbnb.Data.Repositories.PropertyRepository
{
    public class PropertyRepository : GenericRepository<ArProperties>, IPropertyRepository
    {
        public readonly AirbnbContext _context;
        public PropertyRepository(AirbnbContext context) : base(context)
        {
            _context = context;
        }

        public List<ArProperties>? GetWithAllData()
        {
            var properties = _context.ArProperties.Where(s => s.Status == true)
            .Include(pRev => pRev.ArPropertyReviews).Include(pImg => pImg.ArPropertyImages).Include(trans => trans.ArTransactions)
            .Include(disputes => disputes.ArDisputes).Include(book => book.ArBookings).Include(cur => cur.Currency).Include(usr => usr.User)
            .Include(cat => cat.Category.ArSubcategories).Include(rType => rType.RoomType).Include(proType => proType.PropertyType)
            .Include(coun => coun.Country).Include(city => city.City)
            .ToList();
            return properties;
        }
        public ArProperties? GetWithAllDataByID(int Id)
        {
            var property = _context.ArProperties.Where(s => s.Status == true && s.Id == Id)
            .Include(pRev => pRev.ArPropertyReviews).Include(pImg => pImg.ArPropertyImages).Include(trans => trans.ArTransactions)
            .Include(disputes => disputes.ArDisputes).Include(book => book.ArBookings).Include(cur => cur.Currency).Include(usr => usr.User)
          .Include(cat => cat.Category.ArSubcategories).Include(rType => rType.RoomType).Include(proType => proType.PropertyType)
            .Include(coun => coun.Country).Include(city => city.City).FirstOrDefault();
            return property;
        }

        public List<ArProperties>? GetWithByHostId(string Id)
        {

            var properties = _context.ArProperties.Where(s => s.Status == true && s.UserId == Id)
            .Include(pRev => pRev.ArPropertyReviews).Include(pImg => pImg.ArPropertyImages).Include(trans => trans.ArTransactions)
            .Include(disputes => disputes.ArDisputes).Include(book => book.ArBookings).Include(cur => cur.Currency).Include(usr => usr.User)
            .Include(cat => cat.Category.ArSubcategories).Include(rType => rType.RoomType).Include(proType => proType.PropertyType)
            .Include(coun => coun.Country).Include(city => city.City)
            .ToList();
            return properties;
        }
    }
}
