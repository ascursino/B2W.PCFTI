
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

    public interface IRegraService : IService<Regra>
    {
        Regra NovaRegra(Regra Regra);
        IEnumerable<Regra> ListarTodosAsRegras();
        IEnumerable<Regra> BuscarVersoes(string filtro);
    }

    public class RegraService : Service<Regra>, IRegraService
    {
        private readonly IRepositoryAsync<Regra> _repository;

        public RegraService(IRepositoryAsync<Regra> repository)
            : base(repository)
        {
            _repository = repository;
        }

        public Regra NovaRegra(Regra regra)
        {
            return _repository.NovaRegra(regra);
        }

        public IEnumerable<Regra> ListarTodosAsRegras()
        {
            return from item in _repository.Queryable()
                   select item;
        }

        public IEnumerable<Regra> BuscarVersoes(string filtro)
        {
            return from item in _repository.Queryable()
                   select item;
        }
    }
}
