using Asi.Data.V1;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Asi.Application.Repository.V1
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        private readonly AsiDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(AsiDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }


        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return _dbSet.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> match)
        {
            return _context.Set<TEntity>().Where(match);
        }

    }
}
