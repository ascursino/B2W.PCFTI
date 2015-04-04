
namespace B2WTI.PCFTI.APLICACAO.Modulo.Orcamento
{
    using B2WTI.PCFTI.DOMINIO.Model.Orcamento;
    using B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DataContexts;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.UnitOfWork;
    using System.Collections.Generic;

    public static class LancamentoCommand
    {

        public static IEnumerable<Lancamento> ListarTodosOsBlocos()
        {
            IEnumerable<Lancamento> ret = null;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Lancamento> lancamentoRepository = new Repository<Lancamento>(context, unitOfWork);
                    ILancamentoService lancamentoService = new LancamentoService(lancamentoRepository);

                    ret = lancamentoService.ListarTodosOsLancamentos();
                }
            }
            catch
            { 
            }
            return ret;
        }

    }
}
