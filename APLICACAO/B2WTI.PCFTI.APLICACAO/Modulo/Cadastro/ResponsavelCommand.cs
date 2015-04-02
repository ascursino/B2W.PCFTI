
namespace B2WTI.PCFTI.APLICACAO.Modulo.Cadastro
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DataContexts;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.UnitOfWork;
    using System.Collections.Generic;

    public static class ResponsavelCommand
    {

        public static IEnumerable<Responsavel> ListarTodosOsResponsaveis()
        {
            IEnumerable<Responsavel> ret = null;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Responsavel> responsavelRepository = new Repository<Responsavel>(context, unitOfWork);
                    IResponsavelService responsavelService = new ResponsavelService(responsavelRepository);

                    ret = responsavelService.ListarTodosOsResponsaveis();
                }
            }
            catch
            { 
            }
            return ret;
        }

    }
}
