using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoPolimorfismo.Domain.Models
{
    public class Formulario
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<Bloco> Blocos { get; set; }
    }
}