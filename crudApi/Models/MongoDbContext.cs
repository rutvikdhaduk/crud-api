using MongoDB.Driver;

namespace crudApi.Models
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _db;

        public MongoDbContext(string connectionString, string dbName)
        {
            var client = new MongoClient(connectionString);
            _db = client.GetDatabase(dbName);
        }

        public IMongoCollection<Student> Students => _db.GetCollection<Student>("Students");
    }
}
