
namespace B2WTI.PCFTI.APLICACAO.Modulo.Cadastro
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DataContexts;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.UnitOfWork;
    using System.Collections.Generic;

    public static class BlocoCommand
    {

        public static IEnumerable<Bloco> ListarTodosOsBlocos()
        {
            IEnumerable<Bloco> ret = null;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Bloco> BlocoRepository = new Repository<Bloco>(context, unitOfWork);
                    IBlocoService BlocoService = new BlocoService(BlocoRepository);

                    ret = BlocoService.ListarTodosOsBlocos();
                }
            }
            catch
            { 
            }
            return ret;
        }

    }
}
