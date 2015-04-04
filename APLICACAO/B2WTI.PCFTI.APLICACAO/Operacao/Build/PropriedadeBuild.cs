
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

    public class PropriedadeBuild
    {
        #region CRIAÇÃO

        public Propriedade CriarNovaPropriedade(Propriedade propriedade, bool Atualizar = false)
        {
            if (propriedade == null)
            {
                propriedade = new Propriedade();
                propriedade.Ano = 0;
            }

            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<Propriedade> PropriedadeRepository = new Repository<Propriedade>(context, unitOfWork);
                IPropriedadeService PropriedadeService = new PropriedadeService(PropriedadeRepository);
                if (!ExistePropriedade(propriedade.Ano))
                {
                    propriedade = PropriedadeService.NovaPropriedade(propriedade);
                    unitOfWork.SaveChanges();
                }
                else if (Atualizar)
                {
                    propriedade = AtualizarPropriedade(propriedade);
                    unitOfWork.SaveChanges();
                }

                unitOfWork.Dispose();
            }

            return propriedade;
        }

        public List<Propriedade> CriarMuitasNovasPropriedades(List<Propriedade> propriedades, bool Atualizar = false)
        {
            List<Propriedade> ret = null;
            try
            {
                ret = new List<Propriedade>();
                foreach (Propriedade Propriedade in propriedades)
                {
                    Propriedade result = CriarNovaPropriedade(Propriedade, Atualizar);
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

        public Propriedade AtualizarPropriedade(Propriedade propriedade)
        {
            if (propriedade == null)
                return propriedade;

            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<Propriedade> propriedadeRepository = new Repository<Propriedade>(context, unitOfWork);
                IPropriedadeService propriedadeService = new PropriedadeService(propriedadeRepository);
                propriedade.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Modified;
                propriedadeService.Update(propriedade);
                unitOfWork.SaveChanges();
            }

            return propriedade;
        }

        public List<Propriedade> AtualizarMuitasPropriedades(List<Propriedade> propriedades)
        {
            List<Propriedade> ret = null;
            try
            {
                ret = new List<Propriedade>();
                foreach (Propriedade Propriedade in propriedades)
                {
                    Propriedade result = AtualizarPropriedade(Propriedade);
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

        public bool ExistePropriedade(int Ano)
        {
            bool ret = false;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Propriedade> propriedadeRepository = new Repository<Propriedade>(context, unitOfWork);
                    IPropriedadeService propriedadeService = new PropriedadeService(propriedadeRepository);

                    ret = (!(propriedadeService.Find(Ano) == null));
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public Propriedade CarregarPropriedade(int Ano)
        {
            Propriedade ret = null;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Propriedade> propriedadeRepository = new Repository<Propriedade>(context, unitOfWork);
                    IPropriedadeService propriedadeService = new PropriedadeService(propriedadeRepository);

                    ret = propriedadeService.Find(Ano);
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

        public bool ExcluirPropriedade(Propriedade propriedade)
        {
            bool ret = true;

            if (propriedade == null)
                return false;

            if (propriedade.Ano == 0)
                return false;

            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Propriedade> PropriedadeRepository = new Repository<Propriedade>(context, unitOfWork);
                    IPropriedadeService PropriedadeService = new PropriedadeService(PropriedadeRepository);
                    propriedade.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Deleted;
                    PropriedadeService.Delete(propriedade.Ano);
                    unitOfWork.SaveChanges();
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public List<int> ExcluirMuitasPropriedades(List<Propriedade> propriedades)
        {
            List<int> ret = null;
            try
            {
                ret = new List<int>();
                foreach (Propriedade Propriedade in propriedades)
                {
                    bool result = ExcluirPropriedade(Propriedade);

                    if (result)
                        ret.Add(Propriedade.Ano);
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
