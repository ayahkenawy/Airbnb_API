using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.GenericRepository;

namespace API_Airbnb.Data.Repositories.CategoriesRepository
{
    public interface ICategoriesRepository : IGenericRepository<ArCategories>
    {

        public List<ArCategories> GetAllWithSub();
        public ArCategories GetByIdWithSub(int id);


    }
}
