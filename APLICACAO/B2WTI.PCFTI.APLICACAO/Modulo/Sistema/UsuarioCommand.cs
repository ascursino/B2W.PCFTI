
namespace B2WTI.PCFTI.APLICACAO.Modulo.Sistema
{
    using B2WTI.PCFTI.DOMINIO.Model.Sistema;
    using B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DataContexts;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.UnitOfWork;
    using System.Collections.Generic;

    public static class UsuarioCommand
    {

        public static IEnumerable<Usuario> ListarTodosOsUsuarios()
        {
            IEnumerable<Usuario> ret = null;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Usuario> usuarioRepository = new Repository<Usuario>(context, unitOfWork);
                    IUsuarioService usuarioService = new UsuarioService(usuarioRepository);

                    ret = usuarioService.ListarTodosOsUsuarios();
                }
            }
            catch
            { 
            }
            return ret;
        }

    }
}
