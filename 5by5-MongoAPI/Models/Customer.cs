using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace _5by5_MongoAPI.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
}