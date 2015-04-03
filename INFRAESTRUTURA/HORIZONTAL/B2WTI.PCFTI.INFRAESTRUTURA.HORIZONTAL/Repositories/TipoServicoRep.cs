
namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.Repositories
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class TipoServicoRep
    {

        public static TipoServico NovoTipoServico(this IRepository<TipoServico> repository, TipoServico tiposervico)
        {
            tiposervico.TipoServicoId = Guid.NewGuid();
            tiposervico.Ativo = true;
            repository.Insert(tiposervico);

            return tiposervico;
        }

        public static IEnumerable<TipoServico> BuscarTipoServico(this IRepository<TipoServico> repository, string TextoArgumentoBusca)
        {
            return from item in repository.Queryable()
                   where item.Ativo.Equals(true)
                   select item;
        }

        public static bool ExcluirTipoServico(this IRepository<TipoServico> repository, Guid TipoServicoId)
        {
            bool ret = true;
            try
            {
                TipoServico tiposervico = null;

                var query = from item in repository.Queryable()
                            where item.TipoServicoId == TipoServicoId
                            select item;

                tiposervico = query.SingleOrDefault<TipoServico>();

                if (tiposervico != null)
                    throw new Exception("O Tipo de Servico não pode ser excluido, pois o mesmo não foi encontrado na base de dados.");

                repository.Delete(tiposervico);
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

    }

}
