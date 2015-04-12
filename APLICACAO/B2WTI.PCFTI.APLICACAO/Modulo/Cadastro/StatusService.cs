
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

    public interface IStatusService : IService<Status>
    {
        Status NovoStatus(Status status);
        IEnumerable<Status> ListarTodosOsStatus();
        IEnumerable<Status> BuscarStatus(string filtro);
    }

    public class StatusService : Service<Status>, IStatusService
    {
        private readonly IRepositoryAsync<Status> _repository;

        public StatusService(IRepositoryAsync<Status> repository)
            : base(repository)
        {
            _repository = repository;
        }

        public Status NovoStatus(Status status)
        {
            return _repository.NovoStatus(status);
        }

        public IEnumerable<Status> ListarTodosOsStatus()
        {
            return from item in _repository.Queryable()
                   where item.Ativo.Equals(true)
                   select item;
        }

        public IEnumerable<Status> BuscarStatus(string filtro)
        {
            return from item in _repository.Queryable()
                   where item.Ativo.Equals(true)
                   && item.Descricao.Contains(filtro)
                   select item;
        }
    }
}
