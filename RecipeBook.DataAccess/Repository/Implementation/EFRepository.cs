using Microsoft.EntityFrameworkCore;
using RecipeBook.DataAccess.Repository.Abstract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecipeBook.DataAccess.Repository.Implementation
{
    public class EFRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbContext context;
        private readonly DbSet<TEntity> set;

        public EFRepository(DbContext _context)
        {
            context = _context;
            set = context.Set<TEntity>();
        }
        public void Create(TEntity entity)
        {
            set.Add(entity);
            Save();
        }
        private void Save()
        {
            context.SaveChanges();
        }
        public void Delete(TEntity entity)
        {
            set.Remove(entity);
            Save();
        }

        public TEntity Find(int id)
        {
            return set.Find(id);
        }


        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Helper.ToListAsync(set.AsAsyncEnumerable<TEntity>());
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            Save();
        }
    }
    public static class Helper
    {
        public static async Task<List<TEntity>> ToListAsync<TEntity>(this IAsyncEnumerable<TEntity> items)
        {
            var results = new List<TEntity>();
            await foreach (var item in items.WithCancellation(default)
                                            .ConfigureAwait(false))
                results.Add(item);
            return results;
        }
    }
}
