
namespace B2WTI.PCFTI.APLICACAO.Modulo.Sistema
{
    using B2WTI.PCFTI.DOMINIO.Model.Sistema;
    using B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DataContexts;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.UnitOfWork;
    using System.Collections.Generic;

    public static class UsuarioRegraCommand
    {

        public static IEnumerable<UsuarioRegra> ListarTodosOsUsuarios()
        {
            IEnumerable<UsuarioRegra> ret = null;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<UsuarioRegra> usuarioregraRepository = new Repository<UsuarioRegra>(context, unitOfWork);
                    IUsuarioRegraService usuarioregraService = new UsuarioRegraService(usuarioregraRepository);

                    ret = usuarioregraService.ListarTodosOsUsuariosRegras();
                }
            }
            catch
            { 
            }
            return ret;
        }

    }
}
