using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace TelephoneDirectory.Framework.Repository.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IMongoQueryable<TEntity> Queryable { get; }
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(object id, TEntity entity);
        Task DeleteAsync(object id);
        Task<TEntity> GetByIdAsync(object id);
        Task<IEnumerable<TEntity>> GetAll();
    }
}
