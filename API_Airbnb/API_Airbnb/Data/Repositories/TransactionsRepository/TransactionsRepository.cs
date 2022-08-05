using API_Airbnb.Data.Context;
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.GenericRepository;

namespace API_Airbnb.Data.Repositories.TransactionsRepository
{
    
        public class TransactionsRepository : GenericRepository<ArTransactions>, ITransactionsRepository
    {
            public readonly AirbnbContext _context;
            public TransactionsRepository(AirbnbContext context) : base(context)
            {
                _context = context;
            }


        }


    
}
