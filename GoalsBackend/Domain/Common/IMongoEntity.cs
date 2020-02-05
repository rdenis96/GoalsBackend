using MongoDB.Bson;

namespace Domain.Common
{
    public interface IMongoEntity
    {
        ObjectId Id { get; set; }
    }
}
