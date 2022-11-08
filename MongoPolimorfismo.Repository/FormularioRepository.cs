using MongoPolimorfismo.Domain.Models;
using MongoPolimorfismo.Domain.Repositories;

namespace MongoPolimorfismo.Repository
{
    public class FormularioRepository : RepositoryBase<Formulario>, IFormularioRepository
    {
    }
}
