
namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.Repositories
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class AnoCalendarioRep
    {

        public static  AnoCalendario NovaPropriedade(this IRepository<AnoCalendario> repository, AnoCalendario propriedade)
        {
            propriedade.Ativo = true;
            repository.Insert(propriedade);
            
            return propriedade;
        }

        public static IEnumerable<AnoCalendario> BuscarPropriedade(this IRepository< AnoCalendario> repository, string TextoArgumentoBusca)
        {
            return from item in repository.Queryable()
                   where item.Ativo.Equals(true)
                   select item;
        }

        public static bool ExcluirPropriedade(this IRepository<AnoCalendario> repository, int Ano)
        { 
            bool ret = true;
            try
            {
                AnoCalendario propriedade = null;

                var query = from item in repository.Queryable()
                            where item.Ano == Ano
                            select item;

                propriedade = query.SingleOrDefault<AnoCalendario>();

                if (propriedade != null)
                    throw new Exception("O objeto Propriedade não pode ser excluido, pois o mesmo não foi encontrado na base de dados.");

                repository.Delete(propriedade);
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

    }

}
