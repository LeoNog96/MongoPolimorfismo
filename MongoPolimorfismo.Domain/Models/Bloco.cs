using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoPolimorfismo.Domain.Models
{
    public class Bloco
    {
        public Bloco()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Campo> Campos { get; set; }
    }
}
