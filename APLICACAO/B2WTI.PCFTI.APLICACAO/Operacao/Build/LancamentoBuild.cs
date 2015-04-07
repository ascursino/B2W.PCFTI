
namespace B2WTI.PCFTI.APLICACAO.Operacao.Build
{
    using B2WTI.PCFTI.APLICACAO.Modulo.Orcamento;
    using DOMINIO.Model.Orcamento;
    using INFRAESTRUTURA.HORIZONTAL;
    using INFRAESTRUTURA.TRANSVERSAL.DataContexts;
    using INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using INFRAESTRUTURA.TRANSVERSAL.UnitOfWork;
    using System;
    using System.Collections.Generic;

    public class LancamentoBuild
    {

        #region CRIAÇÃO

        public Lancamento CriarNovoLancamento(Lancamento lancamento, bool Atualizar = false)
        {
            if (lancamento == null)
            {
                lancamento = new Lancamento();
                lancamento.LancamentoId = Guid.Empty;
            }

            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<Lancamento> lancamentoRepository = new Repository<Lancamento>(context, unitOfWork);
                ILancamentoService lancamentoService = new LancamentoService(lancamentoRepository);
                if (!ExisteLancamento(lancamento.LancamentoId))
                {
                    lancamento = lancamentoService.NovoLancamento(lancamento);
                    unitOfWork.SaveChanges();
                }
                else if (Atualizar)
                {
                    lancamento = AtualizarLancamento(lancamento);
                    unitOfWork.SaveChanges();
                }

                unitOfWork.Dispose();
                (new Execute()).Sistema.Versao.NovaVersaoParaCriacao(lancamento);
            }

            return lancamento;
        }

        public List<Lancamento> CriarMuitosNovosLancamentos(List<Lancamento> lancamentos, bool Atualizar = false)
        {
            List<Lancamento> ret = null;
            try
            {
                ret = new List<Lancamento>();
                foreach (Lancamento item in lancamentos)
                {
                    Lancamento result = CriarNovoLancamento(item, Atualizar);
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

        public Lancamento AtualizarLancamento(Lancamento lancamento)
        {
            if (lancamento == null)
                return lancamento;

            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<Lancamento> lancamentoRepository = new Repository<Lancamento>(context, unitOfWork);
                ILancamentoService lancamentoService = new LancamentoService(lancamentoRepository);
                lancamento.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Modified;
                lancamentoService.Update(lancamento);
                unitOfWork.SaveChanges();
                unitOfWork.Dispose();
                (new Execute()).Sistema.Versao.NovaVersaoParaEdicao(lancamento);
            }

            return lancamento;
        }

        public List<Lancamento> AtualizarMuitosLancamentos(List<Lancamento> lancamentos)
        {
            List<Lancamento> ret = null;
            try
            {
                ret = new List<Lancamento>();
                foreach (Lancamento item in lancamentos)
                {
                    Lancamento result = AtualizarLancamento(item);
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

        public bool ExisteLancamento(Guid LancamentoId)
        {
            bool ret = false;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Lancamento> lancamentoRepository = new Repository<Lancamento>(context, unitOfWork);
                    ILancamentoService lancamentoService = new LancamentoService(lancamentoRepository);

                    ret = (!(lancamentoService.Find(LancamentoId) == null));
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public Lancamento CarregarLancamento(Guid LancamentoId)
        {
            Lancamento ret = null;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Lancamento> lancamentoRepository = new Repository<Lancamento>(context, unitOfWork);
                    ILancamentoService lancamentoService = new LancamentoService(lancamentoRepository);

                    ret = lancamentoService.Find(LancamentoId);
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

        public bool ExcluirLancamento(Lancamento lancamento)
        {
            bool ret = true;

            if (lancamento == null)
                return false;

            if (lancamento.LancamentoId == Guid.Empty)
                return false;

            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Lancamento> lancamentoRepository = new Repository<Lancamento>(context, unitOfWork);
                    ILancamentoService lancamentoService = new LancamentoService(lancamentoRepository);
                    lancamento.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Deleted;
                    lancamentoService.Delete(lancamento.LancamentoId);
                    unitOfWork.SaveChanges();
                    (new Execute()).Sistema.Versao.NovaVersaoParaExclusao(lancamento);
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public List<Guid> ExcluirMuitosLancamentos(List<Lancamento> lancamentos)
        {
            List<Guid> ret = null;
            try
            {
                ret = new List<Guid>();
                foreach (Lancamento item in lancamentos)
                {
                    bool result = ExcluirLancamento(item);

                    if (result)
                        ret.Add(item.LancamentoId);
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
