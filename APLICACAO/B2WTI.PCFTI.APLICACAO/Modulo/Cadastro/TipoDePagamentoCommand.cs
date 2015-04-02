
namespace B2WTI.PCFTI.APLICACAO.Modulo.Cadastro
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DataContexts;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.UnitOfWork;
    using System.Collections.Generic;

    public static class TipoDePagamentoCommand
    {

        public static IEnumerable<TipoDePagamento> ListarTodosOsBlocos()
        {
            IEnumerable<TipoDePagamento> ret = null;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<TipoDePagamento> tipodepagamentoRepository = new Repository<TipoDePagamento>(context, unitOfWork);
                    ITipoDePagamentoService tipodepagamentoService = new TipoDePagamentoService(tipodepagamentoRepository);

                    ret = tipodepagamentoService.ListarTodosOsTipoDePagamento();
                }
            }
            catch
            { 
            }
            return ret;
        }

    }
}
