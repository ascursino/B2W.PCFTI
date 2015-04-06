
namespace B2WTI.PCFTI.APLICACAO.Operacao.Build
{
    using APLICACAO.Modulo.Cadastro;
    using DOMINIO.Model.Global;
    using INFRAESTRUTURA.HORIZONTAL;
    using INFRAESTRUTURA.TRANSVERSAL.DataContexts;
    using INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using INFRAESTRUTURA.TRANSVERSAL.UnitOfWork;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class TipoBlocoBuild
    {

        #region CRIAÇÃO

        public TipoBloco CriarNovoTipoBloco(TipoBloco tipobloco, bool Atualizar = false)
        {
            if (tipobloco == null)
            {
                tipobloco = new TipoBloco();
                tipobloco.TipoBlocoId = Guid.Empty;
            }

            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<TipoBloco> TipoBlocoRepository = new Repository<TipoBloco>(context, unitOfWork);
                ITipoBlocoService TipoBlocoService = new TipoBlocoService(TipoBlocoRepository);
                if (!ExisteTipoBloco(tipobloco.TipoBlocoId))
                {
                    tipobloco = TipoBlocoService.NovoTipoBloco(tipobloco);
                    unitOfWork.SaveChanges();
                }
                else if (Atualizar)
                {
                    tipobloco = AtualizarTipoBloco(tipobloco);
                    unitOfWork.SaveChanges();
                }

                unitOfWork.Dispose();
            }

            return tipobloco;
        }

        public List<TipoBloco> CriarMuitosNovosTiposBlocos(List<TipoBloco> tipoblocos, bool Atualizar = false)
        {
            List<TipoBloco> ret = null;
            try
            {
                ret = new List<TipoBloco>();
                foreach (TipoBloco TipoBloco in tipoblocos)
                {
                    TipoBloco result = CriarNovoTipoBloco(TipoBloco, Atualizar);
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

        public TipoBloco AtualizarTipoBloco(TipoBloco tipobloco)
        {
            if (tipobloco == null)
                return tipobloco;

            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<TipoBloco> tipoblocoRepository = new Repository<TipoBloco>(context, unitOfWork);
                ITipoBlocoService tipoblocoService = new TipoBlocoService(tipoblocoRepository);
                tipobloco.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Modified;
                tipoblocoService.Update(tipobloco);
                unitOfWork.SaveChanges();
            }

            return tipobloco;
        }

        public List<TipoBloco> AtualizarMuitosTiposBlocos(List<TipoBloco> tipoblocos)
        {
            List<TipoBloco> ret = null;
            try
            {
                ret = new List<TipoBloco>();
                foreach (TipoBloco TipoBloco in tipoblocos)
                {
                    TipoBloco result = AtualizarTipoBloco(TipoBloco);
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

        public bool ExisteTipoBloco(Guid TipoBlocoId)
        {
            bool ret = false;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<TipoBloco> tipoblocoRepository = new Repository<TipoBloco>(context, unitOfWork);
                    ITipoBlocoService tipoblocoService = new TipoBlocoService(tipoblocoRepository);

                    ret = (!(tipoblocoService.Find(TipoBlocoId) == null));
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public TipoBloco CarregarTipoBloco(Guid TipoBlocoId)
        {
            TipoBloco ret = null;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<TipoBloco> tipoblocoRepository = new Repository<TipoBloco>(context, unitOfWork);
                    ITipoBlocoService tipoblocoService = new TipoBlocoService(tipoblocoRepository);

                    ret = tipoblocoService.Find(TipoBlocoId);
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = null;
            }
            return ret;
        }

        public List<TipoBloco> ListarTiposBlocos()
        {
            List<TipoBloco> ret = null;
            try
            {
                ret = new List<TipoBloco>();
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<TipoBloco> tipoblocoRepository = new Repository<TipoBloco>(context, unitOfWork);
                    ITipoBlocoService tipoblocoService = new TipoBlocoService(tipoblocoRepository);
                    ret = tipoblocoService.ListarTodosOsTiposBloco().ToList<TipoBloco>();
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = null;
            }
            return ret;
        }

        public List<TipoBloco> BuscarTiposBlocos(string filtro)
        {
            List<TipoBloco> ret = null;
            try
            {
                ret = new List<TipoBloco>();
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<TipoBloco> tipoblocoRepository = new Repository<TipoBloco>(context, unitOfWork);
                    ITipoBlocoService tipoblocoService = new TipoBlocoService(tipoblocoRepository);
                    ret = tipoblocoService.BuscarTiposBlocos(filtro).ToList<TipoBloco>();
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

        public bool ExcluirTipoBloco(TipoBloco tipobloco)
        {
            bool ret = true;

            if (tipobloco == null)
                return false;

            if (tipobloco.TipoBlocoId == Guid.Empty)
                return false;

            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<TipoBloco> TipoBlocoRepository = new Repository<TipoBloco>(context, unitOfWork);
                    ITipoBlocoService TipoBlocoService = new TipoBlocoService(TipoBlocoRepository);
                    tipobloco.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Deleted;
                    TipoBlocoService.Delete(tipobloco.TipoBlocoId);
                    unitOfWork.SaveChanges();
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public List<Guid> ExcluirMuitosTiposBlocos(List<TipoBloco> tipoblocos)
        {
            List<Guid> ret = null;
            try
            {
                ret = new List<Guid>();
                foreach (TipoBloco TipoBloco in tipoblocos)
                {
                    bool result = ExcluirTipoBloco(TipoBloco);

                    if (result)
                        ret.Add(TipoBloco.TipoBlocoId);
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
