using MongoDB.Driver;
using MongoPolimorfismo.Domain.Repositories;
using System.Linq.Expressions;

namespace MongoPolimorfismo.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T>
    {
        private readonly IMongoCollection<T> _collection;
        public RepositoryBase()
        {
            var mongoDbClient = new MongoClient("mongodb://admin:admin@localhost:27017/");
            var mongoDbDatabase = mongoDbClient.GetDatabase("mongodb");

            _collection = mongoDbDatabase.GetCollection<T>(typeof(T).Name);
        }

        public Task AlterarAsync(Expression<Func<T, bool>> expressao, T entidade) => _collection.ReplaceOneAsync(expressao, entidade);

        public Task<T> BuscarAsync(Expression<Func<T, bool>> expressao) => _collection.Find(expressao).FirstOrDefaultAsync();

        public Task<List<T>> BuscarTodosAsync() => _collection.Find(_ => true).ToListAsync();

        public Task<List<T>> BuscarTodosAsync(Expression<Func<T, bool>> expressao) => _collection.Find(expressao).ToListAsync();

        public Task RemoverAsync(Expression<Func<T, bool>> expressao) => _collection.DeleteOneAsync(expressao);

        public async Task<T> SalvarAsync(T entidade)
        {
            await _collection.InsertOneAsync(entidade);
            return entidade;
        }

        public async Task<List<T>> SalvarMuitosAsync(List<T> entidade)
        {
            await _collection.InsertManyAsync(entidade);
            return entidade;
        }
    }
}