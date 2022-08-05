using API_Airbnb.Data.Context;
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.GenericRepository;

namespace API_Airbnb.Data.Repositories.CurrenciesRepository;

public class CurrenciesRepository : GenericRepository<ArCurrencies>, ICurrenciesRepository
{
    private readonly AirbnbContext _context;

    public CurrenciesRepository(AirbnbContext context) : base(context)
    {
        _context = context;
    }
}
