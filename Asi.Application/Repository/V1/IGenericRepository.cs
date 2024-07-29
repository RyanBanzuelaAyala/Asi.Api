using System.Linq.Expressions;

namespace Asi.Application.Repository.V1
{
    public interface IGenericRepository<TEntity> where TEntity : class, new()
    {
        TEntity GetById(int id);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> match);
    }
}
