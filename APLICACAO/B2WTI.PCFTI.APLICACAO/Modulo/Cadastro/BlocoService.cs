
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

    public interface IBlocoService : IService<Bloco>
    {
        Bloco NovoBloco(Bloco Bloco);
        IEnumerable<Bloco> ListarTodosOsBlocos();
        IEnumerable<Bloco> BuscarBlocos(string filtro);
    }

    public class BlocoService : Service<Bloco>, IBlocoService
    {
        private readonly IRepositoryAsync<Bloco> _repository;

        public BlocoService(IRepositoryAsync<Bloco> repository)
            : base(repository)
        {
            _repository = repository;
        }

        public Bloco NovoBloco(Bloco Bloco)
        {
            return _repository.NovoBloco(Bloco);
        }

        public IEnumerable<Bloco> ListarTodosOsBlocos()
        {
            return from item in _repository.Queryable()
                   where item.Ativo.Equals(true)
                   select item;
        }

        public IEnumerable<Bloco> BuscarBlocos(string filtro)
        {
            return from item in _repository.Queryable()
                   where item.Ativo.Equals(true)
                   && item.Descricao.Contains(filtro)
                   select item;
        }
    }
}
