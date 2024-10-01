using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace crudApi.Models
{
    public class Student
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string city { get; set; }
    }
}
