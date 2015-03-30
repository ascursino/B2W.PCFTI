
namespace B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DataContexts
{
    using System.Threading;
    using System.Threading.Tasks;

    public interface IDataContextAsync : IDataContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<int> SaveChangesAsync();
    }
}
