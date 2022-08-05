using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.GenericRepository;

namespace API_Airbnb.Data.Repositories.BookingsRepository;

public interface IBookingsRepository : IGenericRepository<ArBookings>
{
}
