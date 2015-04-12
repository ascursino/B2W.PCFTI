
namespace B2WTI.PCFTI.APLICACAO.Operacao.Build
{
    using System.Linq;
    using APLICACAO.Modulo.Cadastro;
    using DOMINIO.Model.Global;
    using INFRAESTRUTURA.HORIZONTAL;
    using INFRAESTRUTURA.TRANSVERSAL.DataContexts;
    using INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using INFRAESTRUTURA.TRANSVERSAL.UnitOfWork;
    using System;
    using System.Collections.Generic;

    public class StatusBuild
    {

        #region CRIAÇÃO

        public Status CriarNovoStatus(Status status, bool Atualizar = false)
        {
            if (status == null)
            {
                status = new Status();
                status.StatusId = Guid.Empty;
            }

            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<Status> statusRepository = new Repository<Status>(context, unitOfWork);
                IStatusService statusService = new StatusService(statusRepository);
                if (!ExisteStatus(status.StatusId))
                {
                    status = statusService.NovoStatus(status);
                    unitOfWork.SaveChanges();
                }
                else if (Atualizar)
                {
                    status = AtualizarStatus(status);
                    unitOfWork.SaveChanges();
                }

                unitOfWork.Dispose();
                (new Execute()).Sistema.Versao.NovaVersaoParaCriacao(status);
            }

            return status;
        }

        public List<Status> CriarMuitosNovosStatus(List<Status> status, bool Atualizar = false)
        {
            List<Status> ret = null;
            try
            {
                ret = new List<Status>();
                foreach (Status item in status)
                {
                    Status result = CriarNovoStatus(item, Atualizar);
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

        public Status AtualizarStatus(Status status)
        {
            if (status == null)
                return status;

            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<Status> statusRepository = new Repository<Status>(context, unitOfWork);
                IStatusService statusService = new StatusService(statusRepository);
                status.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Modified;
                statusService.Update(status);
                unitOfWork.SaveChanges();
                (new Execute()).Sistema.Versao.NovaVersaoParaEdicao(status);
            }

            return status;
        }

        public List<Status> AtualizarMuitosStatus(List<Status> status)
        {
            List<Status> ret = null;
            try
            {
                ret = new List<Status>();
                foreach (Status item in status)
                {
                    Status result = AtualizarStatus(item);
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

        public bool ExisteStatus(Guid StatusId)
        {
            bool ret = false;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Status> statusRepository = new Repository<Status>(context, unitOfWork);
                    IStatusService statusService = new StatusService(statusRepository);

                    ret = (!(statusService.Find(StatusId) == null));
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public Status CarregarStatus(Guid StatusId)
        {
            Status ret = null;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Status> statusRepository = new Repository<Status>(context, unitOfWork);
                    IStatusService statusService = new StatusService(statusRepository);

                    ret = statusService.Find(StatusId);
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = null;
            }
            return ret;
        }

        public List<Status> ListarStatus()
        {
            List<Status> ret = null;
            try
            {
                ret = new List<Status>();
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Status> statusRepository = new Repository<Status>(context, unitOfWork);
                    IStatusService statusService = new StatusService(statusRepository);
                    ret = statusService.ListarTodosOsStatus().ToList<Status>();
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = null;
            }
            return ret;
        }

        public List<Status> BuscarStatus(string filtro)
        {
            List<Status> ret = null;
            try
            {
                ret = new List<Status>();
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Status> statusRepository = new Repository<Status>(context, unitOfWork);
                    IStatusService statusService = new StatusService(statusRepository);
                    ret = statusService.BuscarStatus(filtro).ToList<Status>();
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

        public bool ExcluirStatus(Status status)
        {
            bool ret = true;

            if (status == null)
                return false;

            if (status.StatusId == Guid.Empty)
                return false;

            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Status> StatusRepository = new Repository<Status>(context, unitOfWork);
                    IStatusService StatusService = new StatusService(StatusRepository);
                    status.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Deleted;
                    StatusService.Delete(status.StatusId);
                    unitOfWork.SaveChanges();
                    (new Execute()).Sistema.Versao.NovaVersaoParaExclusao(status);
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public List<Guid> ExcluirMuitosStatus(List<Status> status)
        {
            List<Guid> ret = null;
            try
            {
                ret = new List<Guid>();
                foreach (Status item in status)
                {
                    bool result = ExcluirStatus(item);

                    if (result)
                        ret.Add(item.StatusId);
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
