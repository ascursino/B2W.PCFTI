

namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.Repositories
{
    using B2WTI.PCFTI.DOMINIO.Model.Sistema;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class VersaoRep
    {

        public static Versao NovaVersao(this IRepository<Versao> repository, Versao versao)
        {
            versao.VersaoId = Guid.NewGuid();

            repository.Insert(versao);

            return versao;
        }

        public static IEnumerable<Versao> BuscarVersao(this IRepository<Versao> repository, string TextoArgumentoBusca)
        {
            return from item in repository.Queryable()
                   select item;
        }

        public static bool ExcluirVersao(this IRepository<Versao> repository, Guid VersaoId)
        {
            bool ret = true;
            try
            {
                Versao versao = null;

                var query = from item in repository.Queryable()
                            where item.VersaoId == VersaoId
                            select item;

                versao = query.SingleOrDefault<Versao>();

                if (versao != null)
                    throw new Exception("O Versão não pode ser excluida, pois a mesma não foi encontrada na base de dados.");

                repository.Delete(versao);
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

    }

}


