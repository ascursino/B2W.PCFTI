
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

    public interface ITipoBlocoService : IService<TipoBloco>
    {
        TipoBloco NovoTipoBloco(TipoBloco TipoBloco);
        IEnumerable<TipoBloco> ListarTodosOsTiposBloco();
        IEnumerable<TipoBloco> BuscarTiposBlocos(string filtro);
    }

    public class TipoBlocoService : Service<TipoBloco>, ITipoBlocoService
    {
        private readonly IRepositoryAsync<TipoBloco> _repository;

        public TipoBlocoService(IRepositoryAsync<TipoBloco> repository)
            : base(repository)
        {
            _repository = repository;
        }

        public TipoBloco NovoTipoBloco(TipoBloco TipoBloco)
        {
            return _repository.NovoTipoBloco(TipoBloco);
        }

        public IEnumerable<TipoBloco> ListarTodosOsTiposBloco()
        {
            return from item in _repository.Queryable()
                   where item.Ativo.Equals(true)
                   select item;
        }

        public IEnumerable<TipoBloco> BuscarTiposBlocos(string filtro)
        {
            return from item in _repository.Queryable()
                   where item.Ativo.Equals(true)
                   && item.Descricao.Contains(filtro)
                   select item;
        }
    }
}
