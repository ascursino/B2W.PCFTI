
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

    public class BlocoBuild
    {

        #region CRIAÇÃO

        public Bloco CriarNovoBloco(Bloco bloco, bool Atualizar = false)
        {
            if (bloco == null)
            {
                bloco = new Bloco();
                bloco.BlocoId = Guid.Empty;
            }

            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<Bloco> BlocoRepository = new Repository<Bloco>(context, unitOfWork);
                IBlocoService BlocoService = new BlocoService(BlocoRepository);
                if (!ExisteBloco(bloco.BlocoId))
                {
                    bloco = BlocoService.NovoBloco(bloco);
                    unitOfWork.SaveChanges();
                }
                else if (Atualizar)
                {
                    bloco = AtualizarBloco(bloco);
                    unitOfWork.SaveChanges();
                }

                unitOfWork.Dispose();
            }

            return bloco;
        }

        public List<Bloco> CriarMuitosNovosBlocos(List<Bloco> blocos, bool Atualizar = false)
        {
            List<Bloco> ret = null;
            try
            {
                ret = new List<Bloco>();
                foreach (Bloco Bloco in blocos)
                {
                    Bloco result = CriarNovoBloco(Bloco, Atualizar);
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

        public Bloco AtualizarBloco(Bloco bloco)
        {
            if (bloco == null)
                return bloco;

            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<Bloco> blocoRepository = new Repository<Bloco>(context, unitOfWork);
                IBlocoService blocoService = new BlocoService(blocoRepository);
                bloco.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Modified;
                blocoService.Update(bloco);
                unitOfWork.SaveChanges();
            }

            return bloco;
        }

        public List<Bloco> AtualizarMuitosBlocos(List<Bloco> blocos)
        {
            List<Bloco> ret = null;
            try
            {
                ret = new List<Bloco>();
                foreach (Bloco Bloco in blocos)
                {
                    Bloco result = AtualizarBloco(Bloco);
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

        public bool ExisteBloco(Guid BlocoId)
        {
            bool ret = false;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Bloco> blocoRepository = new Repository<Bloco>(context, unitOfWork);
                    IBlocoService blocoService = new BlocoService(blocoRepository);

                    ret = (!(blocoService.Find(BlocoId) == null));
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public Bloco CarregarBloco(Guid BlocoId)
        {
            Bloco ret = null;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Bloco> blocoRepository = new Repository<Bloco>(context, unitOfWork);
                    IBlocoService blocoService = new BlocoService(blocoRepository);

                    ret = blocoService.Find(BlocoId);
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = null;
            }
            return ret;
        }

        public List<Bloco> ListarBlocos()
        {
            List<Bloco> ret = null;
            try
            {
                ret = new List<Bloco>();
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Bloco> blocoRepository = new Repository<Bloco>(context, unitOfWork);
                    IBlocoService blocoService = new BlocoService(blocoRepository);
                    ret = blocoService.ListarTodosOsBlocos().ToList<Bloco>();
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

        public bool ExcluirBloco(Bloco bloco)
        {
            bool ret = true;

            if (bloco == null)
                return false;

            if (bloco.BlocoId == Guid.Empty)
                return false;

            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Bloco> BlocoRepository = new Repository<Bloco>(context, unitOfWork);
                    IBlocoService BlocoService = new BlocoService(BlocoRepository);
                    bloco.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Deleted;
                    BlocoService.Delete(bloco.BlocoId);
                    unitOfWork.SaveChanges();
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public List<Guid> ExcluirMuitosBlocos(List<Bloco> blocos)
        {
            List<Guid> ret = null;
            try
            {
                ret = new List<Guid>();
                foreach (Bloco Bloco in blocos)
                {
                    bool result = ExcluirBloco(Bloco);
                    
                    if (result)
                        ret.Add(Bloco.BlocoId);
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
