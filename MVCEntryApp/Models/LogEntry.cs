using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MVCEntryApp.Models
{
    public class LogEntry
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("DateTime")]
        public DateTime DateTime { get; set; }

        [BsonElement("IpAddress")]
        public string IpAddress { get; set; } = null!;
    }
}
