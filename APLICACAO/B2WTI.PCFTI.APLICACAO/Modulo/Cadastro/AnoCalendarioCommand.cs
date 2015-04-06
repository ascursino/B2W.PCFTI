
namespace B2WTI.PCFTI.APLICACAO.Modulo.Cadastro
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DataContexts;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.UnitOfWork;
    using System.Collections.Generic;

    public static class AnoCalendarioCommand
    {

        public static IEnumerable<AnoCalendario> ListarTodasOsAnosCalendario()
        {
            IEnumerable<AnoCalendario> ret = null;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<AnoCalendario> anocalendarioRepository = new Repository<AnoCalendario>(context, unitOfWork);
                    IAnoCalendarioService anocalendarioService = new AnoCalendarioService(anocalendarioRepository);

                    ret = anocalendarioService.ListarTodasOsAnosCalendario();
                }
            }
            catch
            { 
            }
            return ret;
        }

    }
}
