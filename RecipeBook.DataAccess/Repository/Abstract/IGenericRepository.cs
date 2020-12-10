using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeBook.DataAccess.Repository.Abstract
{
    public interface IGenericRepository<TEntity>
    {
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
        TEntity Find(int id);
    }
}
