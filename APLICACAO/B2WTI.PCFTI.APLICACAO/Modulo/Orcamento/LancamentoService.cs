
namespace B2WTI.PCFTI.APLICACAO.Modulo.Orcamento
{
    using B2WTI.PCFTI.DOMINIO.Model.Orcamento;
    using B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL.Repositories;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Services;
    using System.Collections.Generic;
    using System.Linq;


    public interface ILancamentoService : IService<Lancamento>
    {
        Lancamento NovoLancamento(Lancamento lancamento);
        IEnumerable<Lancamento> ListarTodosOsLancamentos();
    }

    public class LancamentoService : Service<Lancamento>, ILancamentoService
    {
        private readonly IRepositoryAsync<Lancamento> _repository;

        public LancamentoService(IRepositoryAsync<Lancamento> repository)
            : base(repository)
        {
            _repository = repository;
        }

        public Lancamento NovoLancamento(Lancamento lancamento)
        {
            return _repository.NovoLancamento(lancamento);
        }

        public IEnumerable<Lancamento> ListarTodosOsLancamentos()
        {
            return from item in _repository.Queryable()
                   select item;
        }
    }
}
