using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.GenericRepository;

namespace API_Airbnb.Data.Repositories.PropertyReviewsRepository
{
    public interface IPropertyReviewsRepository : IGenericRepository<ArPropertyReviews>
    {
        List<ArPropertyReviews>? GetByBookingId(int id);
        List<ArPropertyReviews>? GetByPropertyId(int id);
    }
}
