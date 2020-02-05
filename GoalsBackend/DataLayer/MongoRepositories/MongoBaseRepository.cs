using DataLayer.MongoRepositories.Interfaces;
using Domain.Common;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.MongoRepositories
{
    public abstract class MongoBaseRepository<TEntity> : IMongoBaseRepository<TEntity> where TEntity : class, IMongoEntity, new()
    {
        protected readonly IMongoCollection<TEntity> _collection;

        public MongoBaseRepository(string collectionName)
        {
            _collection = MongoContext.GetMongoDatabase().GetCollection<TEntity>(collectionName);
        }

        public async Task<TEntity> CreateAsync(TEntity obj)
        {
            _collection.InsertOneAsync(obj).GetAwaiter().GetResult();
            var taskResult = await _collection.FindAsync(x => x.Id == obj.Id);
            var result = taskResult.FirstOrDefault();
            return result;
        }

        public async Task<ICollection<TEntity>> GetAll()
        {
            var taskResult = await _collection.FindAsync(_ => true);
            var result = taskResult.ToList();
            return result;
        }

        public async Task<TEntity> GetById(ObjectId objId)
        {
            var taskResult = await _collection.FindAsync(x => x.Id == objId);
            var result = taskResult.FirstOrDefault();
            return result;
        }

        public async Task<TEntity> UpdateAsync(TEntity obj)
        {
            await _collection.ReplaceOneAsync(x => x.Id == obj.Id, obj);
            var taskResult = await _collection.FindAsync(x => x.Id == obj.Id);
            var result = taskResult.FirstOrDefault();
            return result;
        }

        public async Task<bool> DeleteAsync(TEntity obj)
        {
            var result = await _collection.DeleteOneAsync(x => x.Id == obj.Id);
            return result.IsAcknowledged;
        }
    }
}
