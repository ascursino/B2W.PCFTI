
namespace B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.UnitOfWork
{
    using Core.States;
    using Repositories;
    using System;
    using System.Data;

    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
        IRepository<T> Repository<T>() where T : class, IObjectState;
        void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.Unspecified);
        bool Commit();
        void Rollback();
    }
}
