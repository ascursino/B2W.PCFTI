
namespace B2WTI.PCFTI.APLICACAO.Operacao.Build
{
    using APLICACAO.Modulo.Cadastro;
    using DOMINIO.Model.Global;
    using INFRAESTRUTURA.HORIZONTAL;
    using INFRAESTRUTURA.TRANSVERSAL.DataContexts;
    using INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using INFRAESTRUTURA.TRANSVERSAL.UnitOfWork;
    using System;
    using System.Collections.Generic;

    public class TipoServicoBuild
    {

        #region CRIAÇÃO

        public TipoServico CriarNovoTipoServico(TipoServico tiposervico, bool Atualizar = false)
        {
            if (tiposervico == null)
            {
                tiposervico = new TipoServico();
                tiposervico.TipoServicoId = Guid.Empty;
            }

            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<TipoServico> tiposervicoRepository = new Repository<TipoServico>(context, unitOfWork);
                ITipoServicoService tiposervicoService = new TipoServicoService(tiposervicoRepository);
                if (!ExisteTipoServico(tiposervico.TipoServicoId))
                {
                    tiposervico = tiposervicoService.NovoTipoServico(tiposervico);
                    unitOfWork.SaveChanges();
                }
                else if (Atualizar)
                {
                    tiposervico = AtualizarTipoServico(tiposervico);
                    unitOfWork.SaveChanges();
                }

                unitOfWork.Dispose();
            }

            return tiposervico;
        }

        public List<TipoServico> CriarMuitosNovosTiposServicos(List<TipoServico> tiposervicos, bool Atualizar = false)
        {
            List<TipoServico> ret = null;
            try
            {
                ret = new List<TipoServico>();
                foreach (TipoServico item in tiposervicos)
                {
                    TipoServico result = CriarNovoTipoServico(item, Atualizar);
                    if (result != null)
                        ret.Add(result);
                }
            }
            catch
            {
            }
            return ret;
        }

        #endregion

        #region ATUALIZAÇÃO

        public TipoServico AtualizarTipoServico(TipoServico tiposervico)
        {
            if (tiposervico == null)
                return tiposervico;

            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<TipoServico> tiposervicoRepository = new Repository<TipoServico>(context, unitOfWork);
                ITipoServicoService tiposervicoService = new TipoServicoService(tiposervicoRepository);
                tiposervico.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Modified;
                tiposervicoService.Update(tiposervico);
                unitOfWork.SaveChanges();
            }

            return tiposervico;
        }

        public List<TipoServico> AtualizarMuitosTiposServicos(List<TipoServico> tiposervicos)
        {
            List<TipoServico> ret = null;
            try
            {
                ret = new List<TipoServico>();
                foreach (TipoServico item in tiposervicos)
                {
                    TipoServico result = AtualizarTipoServico(item);
                    ret.Add(result);
                }
            }
            catch
            {
            }
            return ret;
        }

        #endregion

        #region LEITURA

        public bool ExisteTipoServico(Guid TipoServicoId)
        {
            bool ret = false;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<TipoServico> tiposervicoRepository = new Repository<TipoServico>(context, unitOfWork);
                    ITipoServicoService tiposervicoService = new TipoServicoService(tiposervicoRepository);

                    ret = (!(tiposervicoService.Find(TipoServicoId) == null));
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public TipoServico CarregarTipoServico(Guid TipoServicoId)
        {
            TipoServico ret = null;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<TipoServico> tiposervicoRepository = new Repository<TipoServico>(context, unitOfWork);
                    ITipoServicoService tiposervicoService = new TipoServicoService(tiposervicoRepository);

                    ret = tiposervicoService.Find(TipoServicoId);
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

        public bool ExcluirTipoServico(TipoServico tiposervico)
        {
            bool ret = true;

            if (tiposervico == null)
                return false;

            if (tiposervico.TipoServicoId == Guid.Empty)
                return false;

            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<TipoServico> TipoServicoRepository = new Repository<TipoServico>(context, unitOfWork);
                    ITipoServicoService TipoServicoService = new TipoServicoService(TipoServicoRepository);
                    tiposervico.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Deleted;
                    TipoServicoService.Delete(tiposervico.TipoServicoId);
                    unitOfWork.SaveChanges();
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public List<Guid> ExcluirMuitosTiposServicos(List<TipoServico> tiposervicos)
        {
            List<Guid> ret = null;
            try
            {
                ret = new List<Guid>();
                foreach (TipoServico item in tiposervicos)
                {
                    bool result = ExcluirTipoServico(item);

                    if (result)
                        ret.Add(item.TipoServicoId);
                }
            }
            catch
            {
            }
            return ret;
        }

        #endregion

    }
}
