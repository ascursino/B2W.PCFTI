


namespace B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Fakes
{
    using Base;
    using DataContexts;
    using System.Data.Entity;


    public interface IFakeDbContext : IDataContextAsync
    {
        DbSet<T> Set<T>() where T : class;

        void AddFakeDbSet<TEntity, TFakeDbSet>()
            where TEntity : Entity, new()
            where TFakeDbSet : FakeDbSet<TEntity>, IDbSet<TEntity>, new();
    }
}
