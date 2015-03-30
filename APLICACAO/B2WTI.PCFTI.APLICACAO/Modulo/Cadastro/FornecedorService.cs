
namespace B2WTI.PCFTI.APLICACAO.Modulo.Cadastro
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Services;
    using B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IFornecedorService : IService<Fornecedor>
    {
        Fornecedor NovoFornecedor(Fornecedor fornecedor);
        IEnumerable<Fornecedor> ListarTodosOsFornecedores();
    }

    public class FornecedorService : Service<Fornecedor>, IFornecedorService
    {
        private readonly IRepositoryAsync<Fornecedor> _repository;

        public FornecedorService(IRepositoryAsync<Fornecedor> repository)
            : base(repository)
        {
            _repository = repository;
        }

        public Fornecedor NovoFornecedor(Fornecedor fornecedor)
        {
            return _repository.NovoFornecedor(fornecedor);
        }

        public IEnumerable<Fornecedor> ListarTodosOsFornecedores()
        {
            return from item in _repository.Queryable()
                   where item.Ativo.Equals(true)
                   select item;
        }
    }
}
