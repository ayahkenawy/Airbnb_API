using API_Airbnb.Data.Context;
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.GenericRepository;

namespace API_Airbnb.Data.Repositories.RoomTypeRepository
{
    public class RoomTypeRepository : GenericRepository<ArRoomType>, IRoomTypeRepository
    {
        public readonly AirbnbContext _context;
        public RoomTypeRepository(AirbnbContext context) : base(context)
        {
            _context = context;
        }

    }
}
