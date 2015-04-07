
namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.Repositories
{
    using B2WTI.PCFTI.DOMINIO.Model.Sistema;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class UsuarioRegraRep
    {

        public static UsuarioRegra NovoUsuarioRegra(this IRepository<UsuarioRegra> repository, UsuarioRegra usuarioregra)
        {
            repository.Insert(usuarioregra);

            return usuarioregra;
        }

        public static IEnumerable<UsuarioRegra> BuscarUsuarioRegra(this IRepository<UsuarioRegra> repository, string TextoArgumentoBusca)
        {
            return from item in repository.Queryable()
                   select item;
        }

        public static bool ExcluirUsuarioRegra(this IRepository<UsuarioRegra> repository, Guid UsuarioId, Guid RegraId)
        {
            bool ret = true;
            try
            {
                UsuarioRegra usuarioregra = null;

                var query = from item in repository.Queryable()
                            where item.UsuarioId == UsuarioId
                            && item.RegraId == RegraId
                            select item;

                usuarioregra = query.SingleOrDefault<UsuarioRegra>();

                if (usuarioregra != null)
                    throw new Exception("O víncolo UsuarioRegra não pode ser excluido, pois o mesmo não foi encontrado na base de dados.");

                repository.Delete(usuarioregra);
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

    }

}


