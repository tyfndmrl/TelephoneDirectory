using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using TelephoneDirectory.Framework.Bases.Interfaces;
using TelephoneDirectory.Framework.Repository.Attributes;
using TelephoneDirectory.Framework.Repository.Models.Configurations;
using TelephoneDirectory.Framework.Repository.Repositories.Interfaces;

namespace TelephoneDirectory.Framework.Repository.Repositories
{
    public class MongoRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IMongoCollection<TEntity> _collection;
        public MongoRepository(IOptions<MongoConfiguration> mongoConfiguration)
        {
            var client = new MongoClient(mongoConfiguration.Value.ConnectionString);
            var database = client.GetDatabase(mongoConfiguration.Value.DatabaseName);
            var collectionName = GetCollectionName();
            _collection = database.GetCollection<TEntity>(collectionName ?? typeof(TEntity).Name);
        }
        public IMongoQueryable<TEntity> Queryable => _collection.AsQueryable();

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity is IHasCreationDate creationDateEntity)
                creationDateEntity.CreatedDate = DateTime.UtcNow;

            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<TEntity> UpdateAsync(object id, TEntity entity)
        {
            if (entity is IHasModificationDate modificationDateEntity)
                modificationDateEntity.LastModificationDate = DateTime.UtcNow;

            var filter = Builders<TEntity>.Filter.Eq("_id", id);
            await _collection.ReplaceOneAsync(filter, entity);
            return entity;
        }

        public async Task DeleteAsync(object id)
        {
            var filter = Builders<TEntity>.Filter.Eq("_id", id);
            if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
            {
                var entity = await GetByIdAsync(id);
                if (entity is IHasModificationDate modificationdate)
                    modificationdate.LastModificationDate = DateTime.UtcNow;

                ((ISoftDelete)entity).IsDeleted = true;
                await _collection.ReplaceOneAsync(filter, entity);
            }
            else
                await _collection.DeleteOneAsync(filter);
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            var filter = EntityFilter(id, true);
            var data = await _collection.FindAsync(filter);
            return await data.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var filter = ApplySoftDeleteFilter();
            var data = await _collection.FindAsync(filter);
            return await data.ToListAsync();
        }

        private FilterDefinition<TEntity> EntityFilter(object id, bool applyFilters = false)
        {
            var filters = new List<FilterDefinition<TEntity>>
            {
                Builders<TEntity>.Filter.Eq("_id", id)
            };

            if (applyFilters)
            {
                var filter = ApplySoftDeleteFilter();
                if (filter != null)
                    filters.Add(filter);
            }

            return Builders<TEntity>.Filter.And(filters);
        }

        private FilterDefinition<TEntity> ApplySoftDeleteFilter()
        {
            if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
                return Builders<TEntity>.Filter.Eq("IsDeleted", false);

            return null;
        }

        private string GetCollectionName()
        {
            return (typeof(TEntity).GetCustomAttributes(typeof(BsonCollectionAttribute), true).FirstOrDefault()
                as BsonCollectionAttribute).CollectionName;
        }
    }
}
