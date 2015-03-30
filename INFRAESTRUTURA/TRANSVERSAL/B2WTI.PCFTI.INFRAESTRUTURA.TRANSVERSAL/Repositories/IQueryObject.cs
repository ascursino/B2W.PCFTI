﻿
namespace B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories
{
    ﻿using System;
    using System.Linq.Expressions;

    public interface IQueryObject<T>
    {
        Expression<Func<T, bool>> Query();
        Expression<Func<T, bool>> And(Expression<Func<T, bool>> query);
        Expression<Func<T, bool>> Or(Expression<Func<T, bool>> query);
        Expression<Func<T, bool>> And(IQueryObject<T> queryObject);
        Expression<Func<T, bool>> Or(IQueryObject<T> queryObject);
    }
}
