
namespace B2WTI.PCFTI.APLICACAO.Modulo.Cadastro
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DataContexts;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.UnitOfWork;
    using System.Collections.Generic;

    public static class TipoBlocoCommand
    {

        public static IEnumerable<TipoBloco> ListarTodosOsTiposBloco()
        {
            IEnumerable<TipoBloco> ret = null;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<TipoBloco> tipoblocoRepository = new Repository<TipoBloco>(context, unitOfWork);
                    ITipoBlocoService tipoblocoService = new TipoBlocoService(tipoblocoRepository);

                    ret = tipoblocoService.ListarTodosOsTiposBloco();
                }
            }
            catch
            { 
            }
            return ret;
        }

    }
}
