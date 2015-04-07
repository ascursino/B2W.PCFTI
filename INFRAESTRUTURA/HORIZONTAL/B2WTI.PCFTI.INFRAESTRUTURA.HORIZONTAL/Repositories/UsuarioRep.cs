
namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.Repositories
{
    using B2WTI.PCFTI.DOMINIO.Model.Sistema;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class UsuarioRep
    {

        public static Usuario NovoUsuario(this IRepository<Usuario> repository, Usuario usuario)
        {
            usuario.UsuarioId = Guid.NewGuid();
            repository.Insert(usuario);

            return usuario;
        }

        public static IEnumerable<Usuario> BuscarUsuario(this IRepository<Usuario> repository, string TextoArgumentoBusca)
        {
            return from item in repository.Queryable()
                   select item;
        }

        public static bool ExcluirUsuario(this IRepository<Usuario> repository, Guid UsuarioId)
        {
            bool ret = true;
            try
            {
                Usuario usuario = null;

                var query = from item in repository.Queryable()
                            where item.UsuarioId == UsuarioId
                            select item;

                usuario = query.SingleOrDefault<Usuario>();

                if (usuario != null)
                    throw new Exception("O Usuario não pode ser excluido, pois o mesmo não foi encontrado na base de dados.");

                repository.Delete(usuario);
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

    }

}


