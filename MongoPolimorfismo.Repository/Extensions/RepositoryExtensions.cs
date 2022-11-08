using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;
using MongoPolimorfismo.Domain.Models;
using MongoPolimorfismo.Domain.Repositories;

namespace MongoPolimorfismo.Repository.Extensions
{
    public static class RepositoryExtensions
    {
        public static void ConfigurarRepository(this IServiceCollection services)
        {
            services.AddTransient<IFormularioPreenchidoRepository, FormularioPreenchidoRepository>();
            services.AddTransient<IFormularioRepository, FormularioRepository>();
        }

        public static void ConfigurarPolimorfismo()
        {
            BsonClassMap.RegisterClassMap<Campo>(p =>
            {
                p.AutoMap();
                p.SetIsRootClass(true);
            });
            BsonClassMap.RegisterClassMap<CampoNumerico>();
            BsonClassMap.RegisterClassMap<CampoTexto>();
        }
    }
}
