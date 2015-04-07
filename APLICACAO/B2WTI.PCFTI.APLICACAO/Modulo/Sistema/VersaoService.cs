
namespace B2WTI.PCFTI.APLICACAO.Modulo.Sistema
{
    using B2WTI.PCFTI.DOMINIO.Model.Sistema;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Services;
    using B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IVersaoService : IService<Versao>
    {
        Versao NovaVersao(Versao Versao);
        IEnumerable<Versao> ListarTodosAsVersoes();
        IEnumerable<Versao> BuscarVersoes(string filtro);
    }

    public class VersaoService : Service<Versao>, IVersaoService
    {
        private readonly IRepositoryAsync<Versao> _repository;

        public VersaoService(IRepositoryAsync<Versao> repository)
            : base(repository)
        {
            _repository = repository;
        }

        public Versao NovaVersao(Versao Versao)
        {
            return _repository.NovaVersao(Versao);
        }

        public IEnumerable<Versao> ListarTodosAsVersoes()
        {
            return from item in _repository.Queryable()
                   select item;
        }

        public IEnumerable<Versao> BuscarVersoes(string filtro)
        {
            return from item in _repository.Queryable()
                   where item.Entidade.Contains(filtro)
                   || item.EnitdadeId.Contains(filtro)
                   || item.Promotor.Contains(filtro)
                   || item.Dados.Contains(filtro)
                   select item;
        }
    }
}
