using Domain.Constants;
using Helpers;
using MongoDB.Driver;

namespace DataLayer
{
    public static class MongoContext
    {
        public static IMongoDatabase GetMongoDatabase()
        {
            string connectionString = AppConfigurationBuilder.Instance.MongoSettings?.Local ?? DefaultConnectionStrings.MongoDefaultConnection;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(Databases.MongoPostsRepository);
            return database;
        }
    }
}
