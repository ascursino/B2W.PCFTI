
namespace B2WTI.PCFTI.APLICACAO.Operacao.Build
{
    using APLICACAO.Modulo.Sistema;
    using DOMINIO.Model.Sistema;
    using INFRAESTRUTURA.HORIZONTAL;
    using INFRAESTRUTURA.TRANSVERSAL.DataContexts;
    using INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using INFRAESTRUTURA.TRANSVERSAL.UnitOfWork;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    
    public class UsuarioRegraBuild
    {

        #region CRIAÇÃO

        //Generica
        public UsuarioRegra CriarNovoUsuarioRegra(UsuarioRegra usuarioregra, bool Atualizar = false)
        {
            if (usuarioregra == null)
            {
                usuarioregra = new UsuarioRegra();
                usuarioregra.UsuarioId = Guid.Empty;
                usuarioregra.RegraId = Guid.Empty;
            }

            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<UsuarioRegra> usuarioregraRepository = new Repository<UsuarioRegra>(context, unitOfWork);
                IUsuarioRegraService usuarioregraService = new UsuarioRegraService(usuarioregraRepository);
                if (!ExisteUsuarioRegra(usuarioregra.UsuarioId, usuarioregra.RegraId))
                {
                    usuarioregra = usuarioregraService.NovoUsuarioRegra(usuarioregra);
                    unitOfWork.SaveChanges();
                }
                else if (Atualizar)
                {
                    usuarioregra = AtualizarUsuarioRegra(usuarioregra);
                    unitOfWork.SaveChanges();
                }

                unitOfWork.Dispose();
                (new Execute()).Sistema.Versao.NovaVersaoParaCriacao(usuarioregra);
            }

            return usuarioregra;
        }

        #endregion

        #region ATUALIZAÇÃO

        //Generica
        public UsuarioRegra AtualizarUsuarioRegra(UsuarioRegra usuarioregra)
        {
            if (usuarioregra == null)
                return usuarioregra;

            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<UsuarioRegra> usuarioregraRepository = new Repository<UsuarioRegra>(context, unitOfWork);
                IUsuarioRegraService usuarioregraService = new UsuarioRegraService(usuarioregraRepository);
                usuarioregra.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Modified;
                usuarioregraService.Update(usuarioregra);
                unitOfWork.SaveChanges();
                (new Execute()).Sistema.Versao.NovaVersaoParaEdicao(usuarioregra);
            }

            return usuarioregra;
        }

        #endregion

        #region LEITURA

        public bool ExisteUsuarioRegra(Guid UsuarioId, Guid RegraId)
        {
            bool ret = false;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<UsuarioRegra> usuarioregraRepository = new Repository<UsuarioRegra>(context, unitOfWork);
                    IUsuarioRegraService usuarioregraService = new UsuarioRegraService(usuarioregraRepository);

                    ret = (usuarioregraService.Query(p => 
                        p.UsuarioId == UsuarioId 
                        && p.RegraId == RegraId)
                        .Select()
                        .Count() > 0);

                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public UsuarioRegra CarregarUsuarioRegra(Guid UsuarioId, Guid RegraId)
        {
            UsuarioRegra ret = null;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<UsuarioRegra> usuarioregraRepository = new Repository<UsuarioRegra>(context, unitOfWork);
                    IUsuarioRegraService usuarioregraService = new UsuarioRegraService(usuarioregraRepository);

                    var query = from item in usuarioregraService.Queryable()
                                where item.UsuarioId == UsuarioId
                                && item.RegraId == RegraId
                                select item;

                    ret = query.SingleOrDefault<UsuarioRegra>();    
                        
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = null;
            }
            return ret;
        }

        public List<UsuarioRegra> ListarUsuarioRegras()
        {
            List<UsuarioRegra> ret = null;
            try
            {
                ret = new List<UsuarioRegra>();
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<UsuarioRegra> usuarioregraRepository = new Repository<UsuarioRegra>(context, unitOfWork);
                    IUsuarioRegraService usuarioregraService = new UsuarioRegraService(usuarioregraRepository);
                    ret = usuarioregraService.ListarTodosOsUsuariosRegras().ToList<UsuarioRegra>();
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = null;
            }
            return ret;
        }

        public List<UsuarioRegra> BuscarUsuarioRegras(string filtro)
        {
            List<UsuarioRegra> ret = null;
            try
            {
                ret = new List<UsuarioRegra>();
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<UsuarioRegra> usuarioregraRepository = new Repository<UsuarioRegra>(context, unitOfWork);
                    IUsuarioRegraService usuarioregraService = new UsuarioRegraService(usuarioregraRepository);
                    ret = usuarioregraService.BuscarVersoes(filtro).ToList<UsuarioRegra>();
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
        public bool ExcluirUsuarioRegra(UsuarioRegra usuarioregra)
        {
            bool ret = true;

            if (usuarioregra == null)
                return false;

            if (usuarioregra.UsuarioId == Guid.Empty || usuarioregra.RegraId == Guid.Empty)
                return false;

            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<UsuarioRegra> UsuarioRegraRepository = new Repository<UsuarioRegra>(context, unitOfWork);
                    IUsuarioRegraService UsuarioRegraService = new UsuarioRegraService(UsuarioRegraRepository);
                    usuarioregra.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Deleted;
                    UsuarioRegraService.Delete(usuarioregra);
                    unitOfWork.SaveChanges();
                    (new Execute()).Sistema.Versao.NovaVersaoParaExclusao(usuarioregra);
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public bool ExcluirUsuarioRegra(Usuario usuario)
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
                    IRepositoryAsync<UsuarioRegra> usuarioregraRepository = new Repository<UsuarioRegra>(context, unitOfWork);
                    IUsuarioRegraService usuarioregraService = new UsuarioRegraService(usuarioregraRepository);
                    
                    List<UsuarioRegra> usuarioregras = (from item in usuarioregraService.Queryable()
                                                        where item.UsuarioId == usuario.UsuarioId
                                                        select item)
                                                        .ToList<UsuarioRegra>();

                    Parallel.ForEach<UsuarioRegra>(usuarioregras, usuarioregra => {

                        usuarioregra.AlteradoPor = usuario.AlteradoPor;
                        usuarioregra.AlteradoEm = DateTime.Now;

                        usuarioregra.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Deleted;
                        usuarioregraService.Delete(usuarioregra);

                        (new Execute()).Sistema.Versao.NovaVersaoParaExclusao(usuarioregra);

                    });
                    
                    unitOfWork.SaveChanges();
                }
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
