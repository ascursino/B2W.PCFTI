
namespace B2WTI.PCFTI.APLICACAO.Modulo.Cadastro
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DataContexts;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.UnitOfWork;
    using System.Collections.Generic;

    public static class StatusCommand
    {

        public static IEnumerable<Status> ListarTodosOsBlocos()
        {
            IEnumerable<Status> ret = null;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Status> statusRepository = new Repository<Status>(context, unitOfWork);
                    IStatusService statusService = new StatusService(statusRepository);

                    ret = statusService.ListarTodosOsStatus();
                }
            }
            catch
            { 
            }
            return ret;
        }

    }
}
