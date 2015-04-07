
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

    public interface IUsuarioRegraService : IService<UsuarioRegra>
    {
        UsuarioRegra NovoUsuarioRegra(UsuarioRegra UsuarioRegra);
        IEnumerable<UsuarioRegra> ListarTodosOsUsuariosRegras();
        IEnumerable<UsuarioRegra> BuscarVersoes(string filtro);
    }

    public class UsuarioRegraService : Service<UsuarioRegra>, IUsuarioRegraService
    {
        private readonly IRepositoryAsync<UsuarioRegra> _repository;

        public UsuarioRegraService(IRepositoryAsync<UsuarioRegra> repository)
            : base(repository)
        {
            _repository = repository;
        }

        public UsuarioRegra NovoUsuarioRegra(UsuarioRegra usuarioregra)
        {
            return _repository.NovoUsuarioRegra(usuarioregra);
        }

        public IEnumerable<UsuarioRegra> ListarTodosOsUsuariosRegras()
        {
            return from item in _repository.Queryable()
                   select item;
        }

        public IEnumerable<UsuarioRegra> BuscarVersoes(string filtro)
        {
            return from item in _repository.Queryable()
                   select item;
        }
    }
}
