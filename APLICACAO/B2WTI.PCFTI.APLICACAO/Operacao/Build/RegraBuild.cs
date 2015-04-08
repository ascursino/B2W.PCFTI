
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

    public class RegraBuild
    {

        #region CRIAÇÃO

        //Generica
        public Regra CriarNovaRegra(Regra regra, bool Atualizar = false)
        {
            if (regra == null)
            {
                regra = new Regra();
                regra.RegraId = Guid.Empty;
            }

            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<Regra> regraRepository = new Repository<Regra>(context, unitOfWork);
                IRegraService regraService = new RegraService(regraRepository);
                if (!ExisteRegra(regra.RegraId))
                {
                    regra = regraService.NovaRegra(regra);
                    unitOfWork.SaveChanges();
                }
                else if (Atualizar)
                {
                    regra = AtualizarRegra(regra);
                    unitOfWork.SaveChanges();
                }

                unitOfWork.Dispose();
                (new Execute()).Sistema.Versao.NovaVersaoParaCriacao(regra);
            }

            return regra;
        }



        #endregion

        #region ATUALIZAÇÃO

        //Generica
        public Regra AtualizarRegra(Regra regra)
        {
            if (regra == null)
                return regra;

            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<Regra> regraRepository = new Repository<Regra>(context, unitOfWork);
                IRegraService regraService = new RegraService(regraRepository);
                regra.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Modified;
                regraService.Update(regra);
                unitOfWork.SaveChanges();
                (new Execute()).Sistema.Versao.NovaVersaoParaEdicao(regra);
            }

            return regra;
        }


        #endregion

        #region LEITURA

        public bool ExisteRegra(Guid RegraId)
        {
            bool ret = false;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Regra> regraRepository = new Repository<Regra>(context, unitOfWork);
                    IRegraService regraService = new RegraService(regraRepository);

                    ret = (!(regraService.Find(RegraId) == null));
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public Regra CarregarRegra(Guid RegraId)
        {
            Regra ret = null;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Regra> regraRepository = new Repository<Regra>(context, unitOfWork);
                    IRegraService regraService = new RegraService(regraRepository);

                    ret = regraService.Find(RegraId);
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = null;
            }
            return ret;
        }

        public List<Regra> ListarRegras()
        {
            List<Regra> ret = null;
            try
            {
                ret = new List<Regra>();
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Regra> regraRepository = new Repository<Regra>(context, unitOfWork);
                    IRegraService regraService = new RegraService(regraRepository);
                    ret = regraService.ListarTodosAsRegras().ToList<Regra>();
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = null;
            }
            return ret;
        }

        public List<Regra> BuscarRegras(string filtro)
        {
            List<Regra> ret = null;
            try
            {
                ret = new List<Regra>();
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Regra> regraRepository = new Repository<Regra>(context, unitOfWork);
                    IRegraService regraService = new RegraService(regraRepository);
                    ret = regraService.BuscarVersoes(filtro).ToList<Regra>();
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
        public bool ExcluirRegra(Regra regra)
        {
            bool ret = true;

            if (regra == null)
                return false;

            if (regra.RegraId == Guid.Empty)
                return false;

            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Regra> RegraRepository = new Repository<Regra>(context, unitOfWork);
                    IRegraService RegraService = new RegraService(RegraRepository);
                    regra.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Deleted;
                    RegraService.Delete(regra.RegraId);
                    unitOfWork.SaveChanges();
                    (new Execute()).Sistema.Versao.NovaVersaoParaExclusao(regra);
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
