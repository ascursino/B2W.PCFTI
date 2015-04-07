
namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.Repositories
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class BlocoRep
    {

        public static Bloco NovoBloco(this IRepository<Bloco> repository, Bloco bloco)
        {
            bloco.BlocoId = Guid.NewGuid();
            bloco.Ativo = true;
            repository.Insert(bloco);

            return bloco;
        }

        public static IEnumerable<Bloco> BuscarBloco(this IRepository<Bloco> repository, string TextoArgumentoBusca)
        {
            return from item in repository.Queryable()
                   where item.Ativo.Equals(true)
                   select item;
        }

        public static bool ExcluirBloco(this IRepository<Bloco> repository, Guid BlocoId)
        {
            bool ret = true;
            try
            {
                Bloco Bloco = null;

                var query = from item in repository.Queryable()
                            where item.BlocoId == BlocoId
                            select item;

                Bloco = query.SingleOrDefault<Bloco>();

                if (Bloco != null)
                    throw new Exception("O Bloco não pode ser excluido, pois o mesmo não foi encontrado na base de dados.");

                repository.Delete(Bloco);
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

    }

}


