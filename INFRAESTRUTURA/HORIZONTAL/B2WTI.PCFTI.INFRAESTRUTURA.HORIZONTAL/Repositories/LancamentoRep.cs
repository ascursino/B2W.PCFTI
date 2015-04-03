
namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.Repositories
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using B2WTI.PCFTI.DOMINIO.Model.Orcamento;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class LancamentoRep
    {

        public static Lancamento NovoLancamento(this IRepository<Lancamento> repository, Lancamento lancamento)
        {
            lancamento.LancamentoId = Guid.NewGuid();
            repository.Insert(lancamento);

            return lancamento;
        }

        public static IEnumerable<Lancamento> BuscarLancamento(this IRepository<Lancamento> repository, string TextoArgumentoBusca)
        {
            return from item in repository.Queryable()
                   select item;
        }

        public static bool ExcluirLancamento(this IRepository<Lancamento> repository, Guid LancamentoId)
        {
            bool ret = true;
            try
            {
                Lancamento lancamento = null;

                var query = from item in repository.Queryable()
                            where item.LancamentoId == LancamentoId
                            select item;

                lancamento = query.SingleOrDefault<Lancamento>();

                if (lancamento != null)
                    throw new Exception("O Lancamento não pode ser excluido, pois o mesmo não foi encontrado na base de dados.");

                repository.Delete(lancamento);
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

    }

}
