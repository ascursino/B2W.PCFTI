
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

    public interface ITipoDePagamentoService : IService<TipoDePagamento>
    {
        TipoDePagamento NovoTipoDePagamento(TipoDePagamento tipodepagamento);
        IEnumerable<TipoDePagamento> ListarTodosOsTiposDePagamento();
        IEnumerable<TipoDePagamento> BuscarTiposDePagamento(string filtro);
    }

    public class TipoDePagamentoService : Service<TipoDePagamento>, ITipoDePagamentoService
    {
        private readonly IRepositoryAsync<TipoDePagamento> _repository;

        public TipoDePagamentoService(IRepositoryAsync<TipoDePagamento> repository)
            : base(repository)
        {
            _repository = repository;
        }

        public TipoDePagamento NovoTipoDePagamento(TipoDePagamento tipodepagamento)
        {
            return _repository.NovoTipoDePagamento(tipodepagamento);
        }

        public IEnumerable<TipoDePagamento> ListarTodosOsTiposDePagamento()
        {
            return from item in _repository.Queryable()
                   where item.Ativo.Equals(true)
                   select item;
        }

        public IEnumerable<TipoDePagamento> BuscarTiposDePagamento(string filtro)
        {
            return from item in _repository.Queryable()
                   where item.Ativo.Equals(true)
                   && item.Descricao.Contains(filtro)
                   select item;
        }
    }
}
