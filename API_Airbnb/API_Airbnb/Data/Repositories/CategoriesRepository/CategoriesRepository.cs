

using API_Airbnb.Data.Context;
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace API_Airbnb.Data.Repositories.CategoriesRepository
{

    public class CategoriesRepository : GenericRepository<ArCategories>, ICategoriesRepository
    {
        public readonly AirbnbContext _context;
        public CategoriesRepository(AirbnbContext context) : base(context)
        {
            _context = context;
        }
        public List<ArCategories>? GetAllWithSub()
        {
            var catergories = _context.ArCategories.Include(sub => sub.ArSubcategories).ToList();
            return catergories;
        }

        public ArCategories? GetByIdWithSub(int id)
        {
            var catergory = _context.ArCategories.Where(s=>s.Id==id).Include(sub => sub.ArSubcategories).FirstOrDefault();
            return catergory;
        }
    }







}
