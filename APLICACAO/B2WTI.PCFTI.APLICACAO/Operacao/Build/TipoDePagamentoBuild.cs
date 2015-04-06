
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

    public class TipoDePagamentoBuild
    {

        #region CRIAÇÃO

        public TipoDePagamento CriarNovoTipoDePagamento(TipoDePagamento tipodepagamento, bool Atualizar = false)
        {
            if (tipodepagamento == null)
            {
                tipodepagamento = new TipoDePagamento();
                tipodepagamento.TipoDePagamentoId = Guid.Empty;
            }

            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<TipoDePagamento> tipodepagamentoRepository = new Repository<TipoDePagamento>(context, unitOfWork);
                ITipoDePagamentoService tipodepagamentoService = new TipoDePagamentoService(tipodepagamentoRepository);
                if (!ExisteTipoDePagamento(tipodepagamento.TipoDePagamentoId))
                {
                    tipodepagamento = tipodepagamentoService.NovoTipoDePagamento(tipodepagamento);
                    unitOfWork.SaveChanges();
                }
                else if (Atualizar)
                {
                    tipodepagamento = AtualizarTipoDePagamento(tipodepagamento);
                    unitOfWork.SaveChanges();
                }

                unitOfWork.Dispose();
            }

            return tipodepagamento;
        }

        public List<TipoDePagamento> CriarMuitosNovosTiposDePagamentos(List<TipoDePagamento> tipodepagamentos, bool Atualizar = false)
        {
            List<TipoDePagamento> ret = null;
            try
            {
                ret = new List<TipoDePagamento>();
                foreach (TipoDePagamento item in tipodepagamentos)
                {
                    TipoDePagamento result = CriarNovoTipoDePagamento(item, Atualizar);
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

        public TipoDePagamento AtualizarTipoDePagamento(TipoDePagamento tipodepagamento)
        {
            if (tipodepagamento == null)
                return tipodepagamento;

            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<TipoDePagamento> tipodepagamentoRepository = new Repository<TipoDePagamento>(context, unitOfWork);
                ITipoDePagamentoService tipodepagamentoService = new TipoDePagamentoService(tipodepagamentoRepository);
                tipodepagamento.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Modified;
                tipodepagamentoService.Update(tipodepagamento);
                unitOfWork.SaveChanges();
            }

            return tipodepagamento;
        }

        public List<TipoDePagamento> AtualizarMuitosTiposDePagamentos(List<TipoDePagamento> tipodepagamentos)
        {
            List<TipoDePagamento> ret = null;
            try
            {
                ret = new List<TipoDePagamento>();
                foreach (TipoDePagamento item in tipodepagamentos)
                {
                    TipoDePagamento result = AtualizarTipoDePagamento(item);
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

        public bool ExisteTipoDePagamento(Guid TipoDePagamentoId)
        {
            bool ret = false;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<TipoDePagamento> tipodepagamentoRepository = new Repository<TipoDePagamento>(context, unitOfWork);
                    ITipoDePagamentoService tipodepagamentoService = new TipoDePagamentoService(tipodepagamentoRepository);

                    ret = (!(tipodepagamentoService.Find(TipoDePagamentoId) == null));
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public TipoDePagamento CarregarTipoDePagamento(Guid TipoDePagamentoId)
        {
            TipoDePagamento ret = null;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<TipoDePagamento> tipodepagamentoRepository = new Repository<TipoDePagamento>(context, unitOfWork);
                    ITipoDePagamentoService tipodepagamentoService = new TipoDePagamentoService(tipodepagamentoRepository);

                    ret = tipodepagamentoService.Find(TipoDePagamentoId);
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = null;
            }
            return ret;
        }

        public List<TipoDePagamento> ListarTiposDePagamento()
        {
            List<TipoDePagamento> ret = null;
            try
            {
                ret = new List<TipoDePagamento>();
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<TipoDePagamento> tipodepagamentoRepository = new Repository<TipoDePagamento>(context, unitOfWork);
                    ITipoDePagamentoService tipodepagamentoService = new TipoDePagamentoService(tipodepagamentoRepository);
                    ret = tipodepagamentoService.ListarTodosOsTiposDePagamento().ToList<TipoDePagamento>();
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = null;
            }
            return ret;
        }

        public List<TipoDePagamento> BuscarTiposDePagamento(string filtro)
        {
            List<TipoDePagamento> ret = null;
            try
            {
                ret = new List<TipoDePagamento>();
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<TipoDePagamento> tipodepagamentoRepository = new Repository<TipoDePagamento>(context, unitOfWork);
                    ITipoDePagamentoService tipodepagamentoService = new TipoDePagamentoService(tipodepagamentoRepository);
                    ret = tipodepagamentoService.BuscarTiposDePagamento(filtro).ToList<TipoDePagamento>();
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

        public bool ExcluirTipoDePagamento(TipoDePagamento tipodepagamento)
        {
            bool ret = true;

            if (tipodepagamento == null)
                return false;

            if (tipodepagamento.TipoDePagamentoId == Guid.Empty)
                return false;

            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<TipoDePagamento> tipodepagamentoRepository = new Repository<TipoDePagamento>(context, unitOfWork);
                    ITipoDePagamentoService tipodepagamentoService = new TipoDePagamentoService(tipodepagamentoRepository);
                    tipodepagamento.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Deleted;
                    tipodepagamentoService.Delete(tipodepagamento.TipoDePagamentoId);
                    unitOfWork.SaveChanges();
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public List<Guid> ExcluirMuitosTiposDePagamentos(List<TipoDePagamento> tipodepagamentos)
        {
            List<Guid> ret = null;
            try
            {
                ret = new List<Guid>();
                foreach (TipoDePagamento item in tipodepagamentos)
                {
                    bool result = ExcluirTipoDePagamento(item);

                    if (result)
                        ret.Add(item.TipoDePagamentoId);
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
