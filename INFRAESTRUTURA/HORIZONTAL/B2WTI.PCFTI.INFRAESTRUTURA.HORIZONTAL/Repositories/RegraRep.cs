
namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.RepositoriesRegra
{
    using B2WTI.PCFTI.DOMINIO.Model.Sistema;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class RegraRep
    {

        public static Regra NovoRegra(this IRepository<Regra> repository, Regra regra)
        {
            regra.RegraId = Guid.NewGuid();
            repository.Insert(regra);

            return regra;
        }

        public static IEnumerable<Regra> BuscarRegra(this IRepository<Regra> repository, string TextoArgumentoBusca)
        {
            return from item in repository.Queryable()
                   select item;
        }

        public static bool ExcluirRegra(this IRepository<Regra> repository, Guid RegraId)
        {
            bool ret = true;
            try
            {
                Regra regra = null;

                var query = from item in repository.Queryable()
                            where item.RegraId == RegraId
                            select item;

                regra = query.SingleOrDefault<Regra>();

                if (regra != null)
                    throw new Exception("O Regra não pode ser excluida, pois a mesma não foi encontrada na base de dados.");

                repository.Delete(regra);
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

    }

}


