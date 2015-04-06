
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

    public class AnoCalendarioBuild
    {
        #region CRIAÇÃO

        public AnoCalendario CriarNovoAnoCalendario(AnoCalendario anocalendario, bool Atualizar = false)
        {
            if (anocalendario == null)
            {
                anocalendario = new AnoCalendario();
                anocalendario.Ano = 0;
            }

            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<AnoCalendario> AnoCalendarioRepository = new Repository<AnoCalendario>(context, unitOfWork);
                IAnoCalendarioService AnoCalendarioService = new AnoCalendarioService(AnoCalendarioRepository);
                if (!ExisteAnoCalendario(anocalendario.Ano))
                {
                    anocalendario = AnoCalendarioService.NovoAnoCalendario(anocalendario);
                    unitOfWork.SaveChanges();
                }
                else if (Atualizar)
                {
                    anocalendario = AtualizarAnoCalendario(anocalendario);
                    unitOfWork.SaveChanges();
                }

                unitOfWork.Dispose();
            }

            return anocalendario;
        }

        public List<AnoCalendario> CriarMuitosNovosAnoCalendarios(List<AnoCalendario> anocalendarios, bool Atualizar = false)
        {
            List<AnoCalendario> ret = null;
            try
            {
                ret = new List<AnoCalendario>();
                foreach (AnoCalendario AnoCalendario in anocalendarios)
                {
                    AnoCalendario result = CriarNovoAnoCalendario(AnoCalendario, Atualizar);
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

        public AnoCalendario AtualizarAnoCalendario(AnoCalendario anocalendario)
        {
            if (anocalendario == null)
                return anocalendario;

            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<AnoCalendario> anocalendarioRepository = new Repository<AnoCalendario>(context, unitOfWork);
                IAnoCalendarioService anocalendarioService = new AnoCalendarioService(anocalendarioRepository);
                anocalendario.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Modified;
                anocalendarioService.Update(anocalendario);
                unitOfWork.SaveChanges();
            }

            return anocalendario;
        }

        public List<AnoCalendario> AtualizarMuitosAnoCalendarios(List<AnoCalendario> anocalendarios)
        {
            List<AnoCalendario> ret = null;
            try
            {
                ret = new List<AnoCalendario>();
                foreach (AnoCalendario AnoCalendario in anocalendarios)
                {
                    AnoCalendario result = AtualizarAnoCalendario(AnoCalendario);
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

        public bool ExisteAnoCalendario(int Ano)
        {
            bool ret = false;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<AnoCalendario> anocalendarioRepository = new Repository<AnoCalendario>(context, unitOfWork);
                    IAnoCalendarioService anocalendarioService = new AnoCalendarioService(anocalendarioRepository);

                    ret = (!(anocalendarioService.Find(Ano) == null));
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public AnoCalendario CarregarAnoCalendario(int Ano)
        {
            AnoCalendario ret = null;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<AnoCalendario> anocalendarioRepository = new Repository<AnoCalendario>(context, unitOfWork);
                    IAnoCalendarioService anocalendarioService = new AnoCalendarioService(anocalendarioRepository);

                    ret = anocalendarioService.Find(Ano);
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

        public bool ExcluirAnoCalendario(AnoCalendario anocalendario)
        {
            bool ret = true;

            if (anocalendario == null)
                return false;

            if (anocalendario.Ano == 0)
                return false;

            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<AnoCalendario> AnoCalendarioRepository = new Repository<AnoCalendario>(context, unitOfWork);
                    IAnoCalendarioService AnoCalendarioService = new AnoCalendarioService(AnoCalendarioRepository);
                    anocalendario.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Deleted;
                    AnoCalendarioService.Delete(anocalendario.Ano);
                    unitOfWork.SaveChanges();
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public List<int> ExcluirMuitosAnosCalendario(List<AnoCalendario> anocalendarios)
        {
            List<int> ret = null;
            try
            {
                ret = new List<int>();
                foreach (AnoCalendario AnoCalendario in anocalendarios)
                {
                    bool result = ExcluirAnoCalendario(AnoCalendario);

                    if (result)
                        ret.Add(AnoCalendario.Ano);
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
