
namespace B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DataContexts
{
    using Core.States;
    using System;

    public interface IDataContext : IDisposable
    {
        int SaveChanges();
        void SyncObjectState<T>(T entity) where T : class, IObjectState;
        void SyncObjectsStatePostCommit();
    }
}
