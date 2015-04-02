
namespace B2WTI.PCFTI.APLICACAO.Modulo.Cadastro
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DataContexts;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.UnitOfWork;
    using System.Collections.Generic;

    public static class PropriedadeCommand
    {

        public static IEnumerable<Propriedade> ListarTodasAsPropriedades()
        {
            IEnumerable<Propriedade> ret = null;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Propriedade> propriedadeRepository = new Repository<Propriedade>(context, unitOfWork);
                    IPropriedadeService propriedadeService = new PropriedadeService(propriedadeRepository);

                    ret = propriedadeService.ListarTodasAsPropriedades();
                }
            }
            catch
            { 
            }
            return ret;
        }

    }
}
