
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

    public interface IResponsavelService : IService<Responsavel>
    {
        Responsavel NovoResponsavel(Responsavel responsavel);
        IEnumerable<Responsavel> ListarTodosOsResponsaveis();
        IEnumerable<Responsavel> BuscarResponsaveis(string filtro);
    }

    public class ResponsavelService : Service<Responsavel>, IResponsavelService
    {
        private readonly IRepositoryAsync<Responsavel> _repository;

        public ResponsavelService(IRepositoryAsync<Responsavel> repository)
            : base(repository)
        {
            _repository = repository;
        }

        public Responsavel NovoResponsavel(Responsavel responsavel)
        {
            return _repository.NovoResponsavel(responsavel);
        }

        public IEnumerable<Responsavel> ListarTodosOsResponsaveis()
        {
            return from item in _repository.Queryable()
                   where item.Ativo.Equals(true)
                   select item;
        }

        public IEnumerable<Responsavel> BuscarResponsaveis(string filtro)
        {
            return from item in _repository.Queryable()
                   where item.Ativo.Equals(true)
                   select item;
        }

    }
}
