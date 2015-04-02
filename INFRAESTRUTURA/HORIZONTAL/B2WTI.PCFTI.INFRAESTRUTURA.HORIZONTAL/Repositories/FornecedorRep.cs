
namespace B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.Repositories
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public static class FornecedorRep
    {

        public static Fornecedor NovoFornecedor(this IRepository<Fornecedor> repository, Fornecedor fornecedor)
        {
            fornecedor.FornecedorId = Guid.NewGuid();
            fornecedor.Ativo = true;
            repository.Insert(fornecedor);
            
            return fornecedor;
        }

        public static IEnumerable<Fornecedor> BuscarFornecedor(this IRepository<Fornecedor> repository, string TextoArgumentoBusca)
        {
            return from item in repository.Queryable()
                   where item.NomeFantasia.Contains(TextoArgumentoBusca)
                   || item.RazaoSocial.Contains(TextoArgumentoBusca)
                   || item.CNPJ.Contains(TextoArgumentoBusca)
                   select item;
        }

        public static bool ExcluirFornecedor(this IRepository<Fornecedor> repository, Guid FornecedorId)
        { 
            bool ret = true;
            try
            {
                Fornecedor fornecedor = null;

                var query = from item in repository.Queryable()
                            where item.FornecedorId == FornecedorId
                            select item;

                fornecedor = query.SingleOrDefault<Fornecedor>();

                if (fornecedor != null)
                    throw new Exception("O fornecedor não pode ser excluido, pois o mesmo não foi encontrado na base de dados.");

                repository.Delete(fornecedor);
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

    }

}
