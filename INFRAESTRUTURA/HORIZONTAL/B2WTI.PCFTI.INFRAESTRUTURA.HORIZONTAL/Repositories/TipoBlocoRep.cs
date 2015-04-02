
namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.Repositories
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public static class TipoBlocoRep
    {

        public static TipoBloco NovoTipoBloco(this IRepository<TipoBloco> repository, TipoBloco TipoBloco)
        {
            TipoBloco.TipoBlocoId = Guid.NewGuid();
            TipoBloco.Ativo = true;
            repository.Insert(TipoBloco);
            
            return TipoBloco;
        }

        public static IEnumerable<TipoBloco> BuscarTipoBloco(this IRepository<TipoBloco> repository, string TextoArgumentoBusca)
        {
            return from item in repository.Queryable()
                   where item.Ativo.Equals(true)
                   select item;
        }

        public static bool ExcluirTipoBloco(this IRepository<TipoBloco> repository, Guid TipoBlocoId)
        { 
            bool ret = true;
            try
            {
                TipoBloco TipoBloco = null;

                var query = from item in repository.Queryable()
                            where item.TipoBlocoId == TipoBlocoId
                            select item;

                TipoBloco = query.SingleOrDefault<TipoBloco>();

                if (TipoBloco != null)
                    throw new Exception("O TipoBloco não pode ser excluido, pois o mesmo não foi encontrado na base de dados.");

                repository.Delete(TipoBloco);
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

    }

}
