
namespace B2WTI.PCFTI.APLICACAO.Modulo.Cadastro
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DataContexts;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.UnitOfWork;
    using System.Collections.Generic;

    public static class TipoServicoCommand
    {

        public static IEnumerable<TipoServico> ListarTodosOsBlocos()
        {
            IEnumerable<TipoServico> ret = null;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<TipoServico> tiposervicoRepository = new Repository<TipoServico>(context, unitOfWork);
                    ITipoServicoService tiposervicoService = new TipoServicoService(tiposervicoRepository);

                    ret = tiposervicoService.ListarTodosOsTiposServicos();
                }
            }
            catch
            { 
            }
            return ret;
        }

    }
}
