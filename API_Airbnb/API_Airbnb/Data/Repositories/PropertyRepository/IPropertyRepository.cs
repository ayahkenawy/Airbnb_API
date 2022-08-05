using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.GenericRepository;

namespace API_Airbnb.Data.Repositories.PropertyRepository
{
    public interface IPropertyRepository:IGenericRepository<ArProperties>
    {
        public List<ArProperties> GetWithAllData();
        public ArProperties GetWithAllDataByID(int Id);
        public List<ArProperties> GetWithByHostId(string Id);
    }
}
