using API_Airbnb.Data.Context;
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;


namespace API_Airbnb.Data.Repositories.PromoCodeRepository
{
    public class PromoCodeRepository : GenericRepository<ArPromoCodes>, IPromoCodeRepository
    {
        public readonly AirbnbContext _context;
        public PromoCodeRepository(AirbnbContext context) : base(context)
        {
            _context = context;
        }

        public List<ArPromoCodes>? GetAllWithTrans()
        {
         return _context.ArPromoCodes.Include(trans=>trans.ArTransactions).ToList();
        }

        public ArPromoCodes? GetByIdWithTrans(int Id)
        {
            return _context.ArPromoCodes.Include(trans => trans.ArTransactions).Where(pc=>pc.Id==Id).FirstOrDefault();
        }
    }
}
