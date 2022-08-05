using Microsoft.AspNetCore.Mvc;

namespace API_Airbnb.Data.Repositories.GenericRepository
{
    public interface IGenericRepository<TEntity> 
        where TEntity : class
    {
        List<TEntity> GetAll();

        TEntity? GetById(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void SaveChanges();
      
        

    }
}
