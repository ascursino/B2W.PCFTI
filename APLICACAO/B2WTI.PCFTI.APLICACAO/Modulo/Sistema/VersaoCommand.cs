
namespace B2WTI.PCFTI.APLICACAO.Modulo.Sistema
{
    using B2WTI.PCFTI.DOMINIO.Model.Sistema;
    using B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DataContexts;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.UnitOfWork;
    using System.Collections.Generic;

    public static class VersaoCommand
    {

        public static IEnumerable<Versao> ListarTodosAsVersoes()
        {
            IEnumerable<Versao> ret = null;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Versao> versaoRepository = new Repository<Versao>(context, unitOfWork);
                    IVersaoService versaoService = new VersaoService(versaoRepository);

                    ret = versaoService.ListarTodosAsVersoes();
                }
            }
            catch
            { 
            }
            return ret;
        }

    }
}
