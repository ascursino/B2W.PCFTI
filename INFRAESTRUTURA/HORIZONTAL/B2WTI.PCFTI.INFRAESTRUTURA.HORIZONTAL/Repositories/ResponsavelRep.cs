
namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.Repositories
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public static class ResponsavelRep
    {

        public static Responsavel NovoResponsavel(this IRepository<Responsavel> repository, Responsavel Responsavel)
        {
            Responsavel.ResponsavelId = Guid.NewGuid();
            Responsavel.Ativo = true;
            repository.Insert(Responsavel);
            
            return Responsavel;
        }

        public static IEnumerable<Responsavel> BuscarResponsavel(this IRepository<Responsavel> repository, string TextoArgumentoBusca)
        {
            return from item in repository.Queryable()
                   where item.Ativo.Equals(true)
                   select item;
        }

        public static bool ExcluirResponsavel(this IRepository<Responsavel> repository, Guid ResponsavelId)
        { 
            bool ret = true;
            try
            {
                Responsavel Responsavel = null;

                var query = from item in repository.Queryable()
                            where item.ResponsavelId == ResponsavelId
                            select item;

                Responsavel = query.SingleOrDefault<Responsavel>();

                if (Responsavel != null)
                    throw new Exception("O Responsavel não pode ser excluido, pois o mesmo não foi encontrado na base de dados.");

                repository.Delete(Responsavel);
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

    }

}
