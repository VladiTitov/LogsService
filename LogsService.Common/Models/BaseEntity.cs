using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LogsService.Common.Models
{
    public class BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
