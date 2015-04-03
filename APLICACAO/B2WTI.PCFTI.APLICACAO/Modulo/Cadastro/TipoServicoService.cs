
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

    public interface ITipoServicoService : IService<TipoServico>
    {
        TipoServico NovoTipoServico(TipoServico tiposervico);
        IEnumerable<TipoServico> ListarTodosOsTiposServicos();
    }

    public class TipoServicoService : Service<TipoServico>, ITipoServicoService
    {
        private readonly IRepositoryAsync<TipoServico> _repository;

        public TipoServicoService(IRepositoryAsync<TipoServico> repository)
            : base(repository)
        {
            _repository = repository;
        }

        public TipoServico NovoTipoServico(TipoServico tiposervico)
        {
            return _repository.NovoTipoServico(tiposervico);
        }

        public IEnumerable<TipoServico> ListarTodosOsTiposServicos()
        {
            return from item in _repository.Queryable()
                   where item.Ativo.Equals(true)
                   select item;
        }
    }
}
