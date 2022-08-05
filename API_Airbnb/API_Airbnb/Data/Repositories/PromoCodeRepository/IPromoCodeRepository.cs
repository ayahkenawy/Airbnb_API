using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.GenericRepository;

namespace API_Airbnb.Data.Repositories.PromoCodeRepository
{
    public interface IPromoCodeRepository: IGenericRepository<ArPromoCodes>
    {
        public List<ArPromoCodes> GetAllWithTrans();
        public ArPromoCodes GetByIdWithTrans(int Id);
    }
}
