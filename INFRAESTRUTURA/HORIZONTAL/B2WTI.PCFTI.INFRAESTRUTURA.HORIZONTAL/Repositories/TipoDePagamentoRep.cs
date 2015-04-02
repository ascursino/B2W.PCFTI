
namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.Repositories
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class TipoDePagamentoRep
    {

        public static TipoDePagamento NovoTipoDePagamento(this IRepository<TipoDePagamento> repository, TipoDePagamento tipodepagamento)
        {
            tipodepagamento.TipoDePagamentoId = Guid.NewGuid();
            tipodepagamento.Ativo = true;
            repository.Insert(tipodepagamento);

            return tipodepagamento;
        }

        public static IEnumerable<TipoDePagamento> BuscarTipoDePagamento(this IRepository<TipoDePagamento> repository, string TextoArgumentoBusca)
        {
            return from item in repository.Queryable()
                   where item.Ativo.Equals(true)
                   select item;
        }

        public static bool ExcluirTipoDePagamento(this IRepository<TipoDePagamento> repository, Guid TipoDePagamentoId)
        { 
            bool ret = true;
            try
            {
                TipoDePagamento tipodepagamento = null;

                var query = from item in repository.Queryable()
                            where item.TipoDePagamentoId == TipoDePagamentoId
                            select item;

                tipodepagamento = query.SingleOrDefault<TipoDePagamento>();

                if (tipodepagamento != null)
                    throw new Exception("O Tipo de Pagamento não pode ser excluido, pois o mesmo não foi encontrado na base de dados.");

                repository.Delete(tipodepagamento);
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

    }

}
