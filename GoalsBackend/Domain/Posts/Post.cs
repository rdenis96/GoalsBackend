using Domain.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;

namespace Domain.Posts
{
    public class Post : IMongoEntity, IEquatable<Post>
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId Id { get; set; }
        public string Description { get; set; }
        [BsonDateTimeOptions]
        public DateTime Date { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Post);
        }

        public bool Equals(Post other)
        {
            return other != null &&
                   Id.Equals(other.Id) &&
                   Description == other.Description &&
                   Date == other.Date;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Description, Date);
        }
    }
}
