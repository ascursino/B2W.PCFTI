
namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.Repositories
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public static class StatusRep
    {

        public static Status NovoStatus(this IRepository<Status> repository, Status status)
        {
            status.StatusId = Guid.NewGuid();
            status.Ativo = true;
            repository.Insert(status);
            
            return status;
        }

        public static IEnumerable<Status> BuscarStatus(this IRepository<Status> repository, string TextoArgumentoBusca)
        {
            return from item in repository.Queryable()
                   where item.Ativo.Equals(true)
                   select item;
        }

        public static bool ExcluirStatus(this IRepository<Status> repository, Guid StatusId)
        { 
            bool ret = true;
            try
            {
                Status status = null;

                var query = from item in repository.Queryable()
                            where item.StatusId == StatusId
                            select item;

                status = query.SingleOrDefault<Status>();

                if (status != null)
                    throw new Exception("O status não pode ser excluido, pois o mesmo não foi encontrado na base de dados.");

                repository.Delete(status);
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

    }

}
