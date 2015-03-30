
namespace B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.UnitOfWork
{
    using Core.States;
    using Repositories;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IUnitOfWorkAsync : IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IRepositoryAsync<T> RepositoryAsync<T>() where T : class, IObjectState;
    }
}
