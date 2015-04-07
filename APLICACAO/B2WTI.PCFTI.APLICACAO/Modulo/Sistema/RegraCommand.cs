
namespace B2WTI.PCFTI.APLICACAO.Modulo.Sistema
{
    using B2WTI.PCFTI.DOMINIO.Model.Sistema;
    using B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DataContexts;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.UnitOfWork;
    using System.Collections.Generic;

    public static class RegraCommand
    {

        public static IEnumerable<Regra> ListarTodosAsRegras()
        {
            IEnumerable<Regra> ret = null;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Regra> regraRepository = new Repository<Regra>(context, unitOfWork);
                    IRegraService regraService = new RegraService(regraRepository);

                    ret = regraService.ListarTodosAsRegras();
                }
            }
            catch
            { 
            }
            return ret;
        }

    }
}
