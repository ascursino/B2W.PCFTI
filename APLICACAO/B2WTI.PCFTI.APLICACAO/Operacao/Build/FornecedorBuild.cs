
namespace B2WTI.PCFTI.APLICACAO.Operacao.Build
{
    using B2WTI.PCFTI.APLICACAO.Modulo.Cadastro;
    using B2WTI.PCFTI.INFRAESTRUTURA.HORIZONTAL;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DataContexts;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.UnitOfWork;
    using DOMINIO.Model.Global;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FornecedorBuild
    {

        #region CRIAÇÃO

        public Guid CriarNovoFornecedor(Fornecedor fornecedor)
        {
            if (fornecedor == null)
            {
                fornecedor = new Fornecedor();
                fornecedor.FornecedorId = Guid.Empty;
            }

            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<Fornecedor> fornecedorRepository = new Repository<Fornecedor>(context, unitOfWork);
                IFornecedorService fornecedorService = new FornecedorService(fornecedorRepository);
                if (!ExisteFornecedor(fornecedor.FornecedorId))
                {
                    fornecedor = fornecedorService.NovoFornecedor(fornecedor);
                    unitOfWork.SaveChanges();
                }
                unitOfWork.Dispose();
            }

            return fornecedor.FornecedorId;
        }

        public List<Guid> CriarMuitosNovosFornecedores(List<Fornecedor> fornecedores)
        {
            List<Guid> ret = null;
            try
            {
                ret = new List<Guid>();
                foreach (Fornecedor fornecedor in fornecedores)
                {
                    Guid result = CriarNovoFornecedor(fornecedor);
                    if (result != Guid.Empty)
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

        public Fornecedor AtualizarFornecedor(Fornecedor fornecedor)
        {
            if (fornecedor == null)
                return fornecedor;

            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<Fornecedor> fornecedorRepository = new Repository<Fornecedor>(context, unitOfWork);
                IFornecedorService fornecedorService = new FornecedorService(fornecedorRepository);
                fornecedor.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Modified;
                fornecedor = fornecedorService.NovoFornecedor(fornecedor);
                unitOfWork.SaveChanges();
            }

            return fornecedor;
        }

        public List<Fornecedor> AtualizarMuitosFornecedores(List<Fornecedor> fornecedores)
        {
            List<Fornecedor> ret = null;
            try
            {
                ret = new List<Fornecedor>();
                foreach (Fornecedor fornecedor in fornecedores)
                {
                    Fornecedor result = AtualizarFornecedor(fornecedor);
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

        public bool ExisteFornecedor(Guid fornecedorId)
        {
            bool ret = false;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Fornecedor> fornecedorRepository = new Repository<Fornecedor>(context, unitOfWork);
                    IFornecedorService fornecedorService = new FornecedorService(fornecedorRepository);

                    ret = (!(fornecedorService.Find(fornecedorId) == null));
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public Fornecedor CarregarFornecedor(Guid fornecedorId)
        {
            Fornecedor ret = null;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Fornecedor> fornecedorRepository = new Repository<Fornecedor>(context, unitOfWork);
                    IFornecedorService fornecedorService = new FornecedorService(fornecedorRepository);

                    ret = fornecedorService.Find(fornecedorId);
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

        public bool ExcluirFornecedor(Fornecedor fornecedor)
        {
            bool ret = true;

            if (fornecedor == null)
                return false;

            if (fornecedor.FornecedorId == Guid.Empty)
                return false;

            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Fornecedor> fornecedorRepository = new Repository<Fornecedor>(context, unitOfWork);
                    IFornecedorService fornecedorService = new FornecedorService(fornecedorRepository);
                    fornecedor.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Deleted;
                    fornecedorService.Delete(fornecedor.FornecedorId);
                    unitOfWork.SaveChanges();
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public List<Guid> ExcluirMuitosFornecedores(List<Fornecedor> fornecedores)
        {
            List<Guid> ret = null;
            try
            {
                ret = new List<Guid>();
                foreach (Fornecedor fornecedor in fornecedores)
                {
                    bool result = ExcluirFornecedor(fornecedor);
                    
                    if (result)
                        ret.Add(fornecedor.FornecedorId);
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
