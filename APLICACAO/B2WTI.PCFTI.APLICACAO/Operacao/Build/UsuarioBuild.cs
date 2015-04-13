
namespace B2WTI.PCFTI.APLICACAO.Operacao.Build
{
    using B2WTI.PCFTI.APLICACAO.Modulo.Sistema;
    using B2WTI.PCFTI.DOMINIO.Model.Sistema;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Core.Providers;
    using INFRAESTRUTURA.HORIZONTAL;
    using INFRAESTRUTURA.TRANSVERSAL.DataContexts;
    using INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using INFRAESTRUTURA.TRANSVERSAL.UnitOfWork;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Data.Entity;
    using System.Text;
    
    public class UsuarioBuild
    {

        #region CRIAÇÃO

        //Generica
        public Usuario CriarNovoUsuario(Usuario usuario, bool Atualizar = false)
        {
            if (usuario == null)
            {
                usuario = new Usuario();
                usuario.UsuarioId = Guid.Empty;
            }

            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<Usuario> usuarioRepository = new Repository<Usuario>(context, unitOfWork);
                IUsuarioService usuarioService = new UsuarioService(usuarioRepository);
                if (!ExisteUsuario(usuario.UsuarioId))
                {
                    usuario = usuarioService.NovoUsuario(usuario);
                    unitOfWork.SaveChanges();
                }
                else if (Atualizar)
                {
                    usuario = AtualizarUsuario(usuario);
                    unitOfWork.SaveChanges();
                }

                unitOfWork.Dispose();
                (new Execute()).Sistema.Versao.NovaVersaoParaCriacao(usuario);
                
                SolicitarAtivacao(usuario);
            }

            return usuario;
        }

        #endregion

        #region ATUALIZAÇÃO

        //Generica
        public Usuario AtualizarUsuario(Usuario usuario)
        {
            if (usuario == null)
                return usuario;

            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<Usuario> usuarioRepository = new Repository<Usuario>(context, unitOfWork);
                IUsuarioService usuarioService = new UsuarioService(usuarioRepository);
                usuario.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Modified;
                usuarioService.Update(usuario);
                unitOfWork.SaveChanges();
                (new Execute()).Sistema.Versao.NovaVersaoParaEdicao(usuario);
            }

            return usuario;
        }


        #endregion

        #region LEITURA

        public bool ExisteUsuario(Guid UsuarioId)
        {
            bool ret = false;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Usuario> usuarioRepository = new Repository<Usuario>(context, unitOfWork);
                    IUsuarioService usuarioService = new UsuarioService(usuarioRepository);

                    ret = (!(usuarioService.Find(UsuarioId) == null));
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public Usuario CarregarUsuario(Guid UsuarioId)
        {
            Usuario ret = null;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Usuario> usuarioRepository = new Repository<Usuario>(context, unitOfWork);
                    IUsuarioService usuarioService = new UsuarioService(usuarioRepository);

                    ret = usuarioService.Find(UsuarioId);
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = null;
            }
            return ret;
        }

        public Usuario CarregarUsuario(string LoginWindows)
        {
            Usuario ret = null;
            try
            {
                ret = new Usuario();
                using (PCFTIDataContext context = new PCFTIDataContext())
                {

                    var usr = (from user in context.Usuario
                                   .Include(p => p.UsuarioRegras)
                                   .Include(p=> p.UsuarioRegras.Select(t=>t.Regra))
                                where user.LoginWindows.Equals(LoginWindows)
                                select user)
                                .SingleOrDefault<Usuario>();
                    
                    ret = usr;
                }
            }
            catch
            {
                ret = null;
            }
            return ret;
        }

        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> ret = null;
            try
            {
                ret = new List<Usuario>();
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Usuario> usuarioRepository = new Repository<Usuario>(context, unitOfWork);
                    IUsuarioService usuarioService = new UsuarioService(usuarioRepository);
                    ret = usuarioService.ListarTodosOsUsuarios().ToList<Usuario>();
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = null;
            }
            return ret;
        }

        public List<Usuario> BuscarUsuarios(string filtro)
        {
            List<Usuario> ret = null;
            try
            {
                ret = new List<Usuario>();
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Usuario> usuarioRepository = new Repository<Usuario>(context, unitOfWork);
                    IUsuarioService usuarioService = new UsuarioService(usuarioRepository);
                    ret = usuarioService.BuscarUsuarios(filtro).ToList<Usuario>();
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = null;
            }
            return ret;
        }

        #endregion

        #region EXCLUSÃO

        //Genecico
        public bool ExcluirUsuario(Usuario usuario)
        {
            bool ret = true;

            if (usuario == null)
                return false;

            if (usuario.UsuarioId == Guid.Empty)
                return false;

            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Usuario> UsuarioRepository = new Repository<Usuario>(context, unitOfWork);
                    IUsuarioService UsuarioService = new UsuarioService(UsuarioRepository);
                    usuario.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Deleted;
                    UsuarioService.Delete(usuario.UsuarioId);
                    unitOfWork.SaveChanges();
                    (new Execute()).Sistema.Versao.NovaVersaoParaExclusao(usuario);
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        #endregion

        #region OUTRAS ( BUSINESS )

        public bool SolicitarAtivacao(Usuario usuario)
        {
            if (usuario == null)
                return false;

            bool ret = true;

            try
            {
                List<string> emails = new List<string>();
                emails.Add(usuario.Email);


                StringBuilder sb = new StringBuilder();
                sb.AppendLine(string.Format("Prezado(a) {0};", usuario.Nome));
                sb.AppendLine("<br/><br/>");
                sb.AppendLine("Por favor, clique no link abaixo para ativar sua conta.");
                sb.AppendLine("<br/><br/>");
                sb.AppendLine(string.Format("<a href='http://app.portalti.b2w/pcfti/Sistema/Usuario/Ativar/{0}'>http://app.portalti.b2w/pcfti/Sistema/Usuario/Editar/{0}</a>", usuario.UsuarioId));
                sb.AppendLine("<br/><br/>Agradecemos sua compreensão");
                
                ret = MailProvider.EnviarEmail(emails, "PCFTI - Ativação de acesso ao sistema. ", sb.ToString());

            }
            catch
            {
                ret = false;
            }

            return ret;
        }

        #endregion
    }
}
