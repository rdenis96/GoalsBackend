using Domain.Common;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLayer.MongoRepositories.Interfaces
{
    public interface IMongoBaseRepository<TEntity> where TEntity : class, IMongoEntity, new()
    {
        Task<TEntity> CreateAsync(TEntity obj);

        Task<ICollection<TEntity>> GetAll();

        Task<TEntity> GetById(ObjectId objId);

        Task<TEntity> UpdateAsync(TEntity obj);

        Task<bool> DeleteAsync(TEntity obj);
    }
}
