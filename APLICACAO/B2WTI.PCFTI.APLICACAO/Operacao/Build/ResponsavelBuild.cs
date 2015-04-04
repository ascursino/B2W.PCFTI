
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

    public class ResponsavelBuild
    {

        #region CRIAÇÃO

        public Responsavel CriarNovoResponsavel(Responsavel responsavel, bool Atualizar = false)
        {
            if (responsavel == null)
            {
                responsavel = new Responsavel();
                responsavel.ResponsavelId = Guid.Empty;
            }

            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<Responsavel> ResponsavelRepository = new Repository<Responsavel>(context, unitOfWork);
                IResponsavelService ResponsavelService = new ResponsavelService(ResponsavelRepository);
                if (!ExisteResponsavel(responsavel.ResponsavelId))
                {
                    responsavel = ResponsavelService.NovoResponsavel(responsavel);
                    unitOfWork.SaveChanges();
                }
                else if (Atualizar)
                {
                    responsavel = AtualizarResponsavel(responsavel);
                    unitOfWork.SaveChanges();
                }

                unitOfWork.Dispose();
            }

            return responsavel;
        }

        public List<Responsavel> CriarMuitosNovosResponsaveis(List<Responsavel> responsaveis, bool Atualizar = false)
        {
            List<Responsavel> ret = null;
            try
            {
                ret = new List<Responsavel>();
                foreach (Responsavel Responsavel in responsaveis)
                {
                    Responsavel result = CriarNovoResponsavel(Responsavel, Atualizar);
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

        public Responsavel AtualizarResponsavel(Responsavel responsavel)
        {
            if (responsavel == null)
                return responsavel;

            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<Responsavel> responsavelRepository = new Repository<Responsavel>(context, unitOfWork);
                IResponsavelService responsavelService = new ResponsavelService(responsavelRepository);
                responsavel.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Modified;
                responsavelService.Update(responsavel);
                unitOfWork.SaveChanges();
            }

            return responsavel;
        }

        public List<Responsavel> AtualizarMuitosResponsaveis(List<Responsavel> responsaveis)
        {
            List<Responsavel> ret = null;
            try
            {
                ret = new List<Responsavel>();
                foreach (Responsavel responsavel in responsaveis)
                {
                    Responsavel result = AtualizarResponsavel(responsavel);
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

        public bool ExisteResponsavel(Guid ResponsavelId)
        {
            bool ret = false;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Responsavel> responsavelRepository = new Repository<Responsavel>(context, unitOfWork);
                    IResponsavelService responsavelService = new ResponsavelService(responsavelRepository);

                    ret = (!(responsavelService.Find(ResponsavelId) == null));
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public Responsavel CarregarResponsavel(Guid ResponsavelId)
        {
            Responsavel ret = null;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Responsavel> responsavelRepository = new Repository<Responsavel>(context, unitOfWork);
                    IResponsavelService responsavelService = new ResponsavelService(responsavelRepository);

                    ret = responsavelService.Find(ResponsavelId);
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

        public bool ExcluirResponsavel(Responsavel responsavel)
        {
            bool ret = true;

            if (responsavel == null)
                return false;

            if (responsavel.ResponsavelId == Guid.Empty)
                return false;

            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Responsavel> responsavelRepository = new Repository<Responsavel>(context, unitOfWork);
                    IResponsavelService responsavelService = new ResponsavelService(responsavelRepository);
                    responsavel.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Deleted;
                    responsavelService.Delete(responsavel.ResponsavelId);
                    unitOfWork.SaveChanges();
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public List<Guid> ExcluirMuitosResponsaveis(List<Responsavel> responsaveis)
        {
            List<Guid> ret = null;
            try
            {
                ret = new List<Guid>();
                foreach (Responsavel responsavel in responsaveis)
                {
                    bool result = ExcluirResponsavel(responsavel);

                    if (result)
                        ret.Add(responsavel.ResponsavelId);
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
