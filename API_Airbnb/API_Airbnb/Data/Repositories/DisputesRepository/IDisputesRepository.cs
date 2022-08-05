using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.GenericRepository;

namespace API_Airbnb.Data.Repositories.DisputesRepository
{
    public interface IDisputesRepository : IGenericRepository<ArDisputes>
    {
        List<ArDisputes>? GetByBookingId(int id);
        List<ArDisputes>? GetByPropertyId(int id);
    }
}
