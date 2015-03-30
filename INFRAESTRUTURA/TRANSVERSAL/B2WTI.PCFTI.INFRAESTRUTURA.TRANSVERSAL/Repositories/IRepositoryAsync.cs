
namespace B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories
{
    using Core.States;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IRepositoryAsync<T> : IRepository<T> where T : class, IObjectState
    {
        Task<T> FindAsync(params object[] keyValues);
        Task<T> FindAsync(CancellationToken cancellationToken, params object[] keyValues);
        Task<bool> DeleteAsync(params object[] keyValues);
        Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues);
    }
}
