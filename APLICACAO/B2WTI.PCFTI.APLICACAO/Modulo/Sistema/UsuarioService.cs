
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
        
    public interface IUsuarioService : IService<Usuario>
    {
        Usuario NovoUsuario(Usuario Usuario);
        IEnumerable<Usuario> ListarTodosOsUsuarios();
        IEnumerable<Usuario> BuscarUsuarios(string filtro);
        IEnumerable<Usuario> CarregarUsuarioPeloLogin(string loginwindows);
    }

    public class UsuarioService : Service<Usuario>, IUsuarioService
    {
        private readonly IRepositoryAsync<Usuario> _repository;

        public UsuarioService(IRepositoryAsync<Usuario> repository)
            : base(repository)
        {
            _repository = repository;
        }

        public Usuario NovoUsuario(Usuario usuario)
        {
            return _repository.NovoUsuario(usuario);
        }

        public IEnumerable<Usuario> ListarTodosOsUsuarios()
        {
            return from item in _repository.Queryable()
                   select item;
        }

        public IEnumerable<Usuario> BuscarUsuarios(string filtro)
        {
            return from item in _repository.Queryable()
                   where item.Nome.Contains(filtro)
                   || item.Email.Contains(filtro)
                   || item.LoginWindows.Contains(filtro)
                   select item;
        }

        public IEnumerable<Usuario> CarregarUsuarioPeloLogin(string loginwindows)
        {

            var usuario = from user in _repository.Queryable()
                          where user.LoginWindows.Equals(loginwindows)
                          select user;

            return usuario;

        }
    }
}
