
namespace B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Specifications
{
    using System;

    public interface ISpecification<TEntity>
    {
        bool IsSatisfiedBy(TEntity entity);
    }
}
