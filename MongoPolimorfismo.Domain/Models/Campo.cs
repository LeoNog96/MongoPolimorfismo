using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoPolimorfismo.Domain.Models
{
    public class Campo
    {
        public Campo()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public object Valor { get; set; }
    }
}
