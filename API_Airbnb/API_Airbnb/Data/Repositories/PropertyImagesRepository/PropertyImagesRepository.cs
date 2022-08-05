using System;

using API_Airbnb.Data.Context;
using API_Airbnb.Data.Models;
using API_Airbnb.Data.Repositories.GenericRepository;
namespace API_Airbnb.Data.Repositories.PropertyImagesRepository
{
  
        public class PropertyImagesRepository : GenericRepository<ArPropertyImages>, IPropertyImagesRepository
        {
            public readonly AirbnbContext _context;
            public PropertyImagesRepository(AirbnbContext context) : base(context)
            {
                _context = context;
            }


        }


    
}
