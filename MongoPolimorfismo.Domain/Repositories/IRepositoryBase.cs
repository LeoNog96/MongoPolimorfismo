using System.Linq.Expressions;

namespace MongoPolimorfismo.Domain.Repositories
{
    public interface IRepositoryBase<T>
    {
        /// <summary>
        /// Lista todos os registro do banco
        /// </summary>
        /// <returns> Retorna uma lista com todos os registros do banco</returns>
        Task<List<T>> BuscarTodosAsync();

        /// <summary>
        /// Lista todos os registro do banco
        /// </summary>
        /// <param name="expressao"> id do registro ser buscado </param>
        /// <returns> Retorna uma lista com todos os registros do banco</returns>
        Task<List<T>> BuscarTodosAsync(Expression<System.Func<T, bool>> expressao);

        /// <summary>
        /// Busca determinado registro no banco
        /// </summary>
        /// <param name="expressao"> id do registro ser buscado </param>
        /// <returns> Retorna uma lista com todos os registros do banco</returns>
        Task<T> BuscarAsync(Expression<System.Func<T, bool>> expressao);

        /// <summary>
        /// Persite uma entidade no banco
        /// </summary>
        /// <param name="entidade"> Entidade a ser persisitido </param>
        /// <returns>Retorna a entidade já persistida no banco</returns>
        Task<T> SalvarAsync(T entidade);

        /// <summary>
        /// Persite uma range de entidades no banco
        /// </summary>
        /// <param name="entidade"> Lista de Entidades a serem persisitidas </param>
        /// <returns>Retorna a Lista com as entidades já persistidas no banco</returns>
        Task<List<T>> SalvarMuitosAsync(List<T> entidade);

        /// <summary>
        /// Atualiza um registro no banco
        /// </summary>
        /// <param name="expressao">Id da entidade a ser atualizada</param>
        Task AlterarAsync(Expression<System.Func<T, bool>> expressao, T entidade);


        /// <summary>
        /// Remove um registro no banco
        /// </summary>
        /// <param name="expressao">Id da entidade a ser removida</param>
        Task RemoverAsync(Expression<System.Func<T, bool>> expressao);
    }
}
