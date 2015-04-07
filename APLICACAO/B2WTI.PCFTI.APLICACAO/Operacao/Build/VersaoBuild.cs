
namespace B2WTI.PCFTI.APLICACAO.Operacao.Build
{
    using B2WTI.PCFTI.APLICACAO.Modulo.Sistema;
    using B2WTI.PCFTI.DOMINIO.Model.Orcamento;
    using B2WTI.PCFTI.DOMINIO.Model.Sistema;
    using DOMINIO.Model.Global;
    using INFRAESTRUTURA.HORIZONTAL;
    using INFRAESTRUTURA.TRANSVERSAL.DataContexts;
    using INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using INFRAESTRUTURA.TRANSVERSAL.UnitOfWork;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class VersaoBuild
    {

        #region CRIAÇÃO

        //Generica
        public Versao CriarNovaVersao(Versao versao, bool Atualizar = false)
        {
            if (versao == null)
            {
                versao = new Versao();
                versao.VersaoId = Guid.Empty;
            }

            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<Versao> versaoRepository = new Repository<Versao>(context, unitOfWork);
                IVersaoService versaoService = new VersaoService(versaoRepository);
                if (!ExisteVersao(versao.VersaoId))
                {
                    versao = versaoService.NovaVersao(versao);
                    unitOfWork.SaveChanges();
                }
                else if (Atualizar)
                {
                    versao = AtualizarVersao(versao);
                    unitOfWork.SaveChanges();
                }

                unitOfWork.Dispose();

            }

            return versao;
        }


        //Usuario
        public void NovaVersaoParaCriacao(Usuario usuario, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "C",
                Entidade = usuario.GetType().Name,
                EnitdadeId = usuario.UsuarioId.ToString(),
                Promotor = usuario.CriadoPor,
                Dados = JsonConvert.SerializeObject(usuario)
            });
        }

        //Regra
        public void NovaVersaoParaCriacao(Regra regra, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "C",
                Entidade = regra.GetType().Name,
                EnitdadeId = regra.RegraId.ToString(),
                Promotor = regra.CriadoPor,
                Dados = JsonConvert.SerializeObject(regra)
            });
        }

        //UsuarioRegra
        public void NovaVersaoParaCriacao(UsuarioRegra usuarioregra, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "C",
                Entidade = usuarioregra.GetType().Name,
                EnitdadeId = string.Format("UsuarioId: {0} | RegraId: {1}", usuarioregra.UsuarioId.ToString(), usuarioregra.RegraId.ToString()),
                Promotor = usuarioregra.CriadoPor,
                Dados = JsonConvert.SerializeObject(usuarioregra)
            });
        }


        //AnoCalendario
        public void NovaVersaoParaCriacao(AnoCalendario anocalendario, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "C",
                Entidade = anocalendario.GetType().Name,
                EnitdadeId = anocalendario.Ano.ToString(),
                Promotor = anocalendario.CriadoPor,
                Dados = JsonConvert.SerializeObject(anocalendario)
            });
        }

        //Bloco
        public void NovaVersaoParaCriacao(Bloco bloco, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "C",
                Entidade = bloco.GetType().Name,
                EnitdadeId = bloco.BlocoId.ToString(),
                Promotor = bloco.CriadoPor,
                Dados = JsonConvert.SerializeObject(bloco)
            });
        }

        //TipoBloco
        public void NovaVersaoParaCriacao(TipoBloco tipobloco, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "C",
                Entidade = tipobloco.GetType().Name,
                EnitdadeId = tipobloco.TipoBlocoId.ToString(),
                Promotor = tipobloco.CriadoPor,
                Dados = JsonConvert.SerializeObject(tipobloco)
            });
        }

        //Fornecedor
        public void NovaVersaoParaCriacao(Fornecedor fornecedor, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "C",
                Entidade = fornecedor.GetType().Name,
                EnitdadeId = fornecedor.FornecedorId.ToString(),
                Promotor = fornecedor.CriadoPor,
                Dados = JsonConvert.SerializeObject(fornecedor)
            });
        }

        //Responsave
        public void NovaVersaoParaCriacao(Responsavel responsavel, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "C",
                Entidade = responsavel.GetType().Name,
                EnitdadeId = responsavel.ResponsavelId.ToString(),
                Promotor = responsavel.CriadoPor,
                Dados = JsonConvert.SerializeObject(responsavel)
            });
        }

        //Status
        public void NovaVersaoParaCriacao(Status status, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "C",
                Entidade = status.GetType().Name,
                EnitdadeId = status.StatusId.ToString(),
                Promotor = status.CriadoPor,
                Dados = JsonConvert.SerializeObject(status)
            });
        }

        //TipoDePagamento
        public void NovaVersaoParaCriacao(TipoDePagamento tipodepagamento, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "C",
                Entidade = tipodepagamento.GetType().Name,
                EnitdadeId = tipodepagamento.TipoDePagamentoId.ToString(),
                Promotor = tipodepagamento.CriadoPor,
                Dados = JsonConvert.SerializeObject(tipodepagamento)
            });
        }

        //TipoServico
        public void NovaVersaoParaCriacao(TipoServico tiposervico, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "C",
                Entidade = tiposervico.GetType().Name,
                EnitdadeId = tiposervico.TipoServicoId.ToString(),
                Promotor = tiposervico.CriadoPor,
                Dados = JsonConvert.SerializeObject(tiposervico)
            });
        }

        //TipoServico
        public void NovaVersaoParaCriacao(Lancamento lancamento, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "C",
                Entidade = lancamento.GetType().Name,
                EnitdadeId = lancamento.TipoServicoId.ToString(),
                Promotor = lancamento.CriadoPor,
                Dados = JsonConvert.SerializeObject(lancamento)
            });
        }


        #endregion

        #region ATUALIZAÇÃO

        //Generica
        public Versao AtualizarVersao(Versao versao)
        {
            if (versao == null)
                return versao;

            using (IDataContextAsync context = new PCFTIDataContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
            {
                IRepositoryAsync<Versao> versaoRepository = new Repository<Versao>(context, unitOfWork);
                IVersaoService versaoService = new VersaoService(versaoRepository);
                versao.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Modified;
                versaoService.Update(versao);
                unitOfWork.SaveChanges();
            }

            return versao;
        }


        //Usuario
        public void NovaVersaoParaEdicao(Usuario usuario, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "U",
                Entidade = usuario.GetType().Name,
                EnitdadeId = usuario.UsuarioId.ToString(),
                Promotor = usuario.AlteradoPor,
                Dados = JsonConvert.SerializeObject(usuario)
            });
        }

        //Regra
        public void NovaVersaoParaEdicao(Regra regra, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "U",
                Entidade = regra.GetType().Name,
                EnitdadeId = regra.RegraId.ToString(),
                Promotor = regra.AlteradoPor,
                Dados = JsonConvert.SerializeObject(regra)
            });
        }

        //UsuarioRegra
        public void NovaVersaoParaEdicao(UsuarioRegra usuarioregra, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "U",
                Entidade = usuarioregra.GetType().Name,
                EnitdadeId = string.Format("UsuarioId: {0} | RegraId: {1}", usuarioregra.UsuarioId.ToString(), usuarioregra.RegraId.ToString()),
                Promotor = usuarioregra.AlteradoPor,
                Dados = JsonConvert.SerializeObject(usuarioregra)
            });
        }

        //AnoCalendario
        public void NovaVersaoParaEdicao(AnoCalendario anocalendario, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "U",
                Entidade = anocalendario.GetType().Name,
                EnitdadeId = anocalendario.Ano.ToString(),
                Promotor = anocalendario.CriadoPor,
                Dados = JsonConvert.SerializeObject(anocalendario)
            });
        }

        //Bloco
        public void NovaVersaoParaEdicao(Bloco bloco, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "U",
                Entidade = bloco.GetType().Name,
                EnitdadeId = bloco.BlocoId.ToString(),
                Promotor = bloco.CriadoPor,
                Dados = JsonConvert.SerializeObject(bloco)
            });
        }

        //TipoBloco
        public void NovaVersaoParaEdicao(TipoBloco tipobloco, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "U",
                Entidade = tipobloco.GetType().Name,
                EnitdadeId = tipobloco.TipoBlocoId.ToString(),
                Promotor = tipobloco.CriadoPor,
                Dados = JsonConvert.SerializeObject(tipobloco)
            });
        }

        //Fornecedor
        public void NovaVersaoParaEdicao(Fornecedor fornecedor, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "U",
                Entidade = fornecedor.GetType().Name,
                EnitdadeId = fornecedor.FornecedorId.ToString(),
                Promotor = fornecedor.CriadoPor,
                Dados = JsonConvert.SerializeObject(fornecedor)
            });
        }

        //Responsave
        public void NovaVersaoParaEdicao(Responsavel responsavel, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "U",
                Entidade = responsavel.GetType().Name,
                EnitdadeId = responsavel.ResponsavelId.ToString(),
                Promotor = responsavel.CriadoPor,
                Dados = JsonConvert.SerializeObject(responsavel)
            });
        }

        //Status
        public void NovaVersaoParaEdicao(Status status, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "U",
                Entidade = status.GetType().Name,
                EnitdadeId = status.StatusId.ToString(),
                Promotor = status.CriadoPor,
                Dados = JsonConvert.SerializeObject(status)
            });
        }

        //TipoDePagamento
        public void NovaVersaoParaEdicao(TipoDePagamento tipodepagamento, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "U",
                Entidade = tipodepagamento.GetType().Name,
                EnitdadeId = tipodepagamento.TipoDePagamentoId.ToString(),
                Promotor = tipodepagamento.CriadoPor,
                Dados = JsonConvert.SerializeObject(tipodepagamento)
            });
        }

        //TipoServico
        public void NovaVersaoParaEdicao(TipoServico tiposervico, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "U",
                Entidade = tiposervico.GetType().Name,
                EnitdadeId = tiposervico.TipoServicoId.ToString(),
                Promotor = tiposervico.CriadoPor,
                Dados = JsonConvert.SerializeObject(tiposervico)
            });
        }

        //TipoServico
        public void NovaVersaoParaEdicao(Lancamento lancamento, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "U",
                Entidade = lancamento.GetType().Name,
                EnitdadeId = lancamento.TipoServicoId.ToString(),
                Promotor = lancamento.CriadoPor,
                Dados = JsonConvert.SerializeObject(lancamento)
            });
        }


        #endregion

        #region LEITURA

        public bool ExisteVersao(Guid VersaoId)
        {
            bool ret = false;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Versao> versaoRepository = new Repository<Versao>(context, unitOfWork);
                    IVersaoService versaoService = new VersaoService(versaoRepository);

                    ret = (!(versaoService.Find(VersaoId) == null));
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        public Versao CarregarVersao(Guid VersaoId)
        {
            Versao ret = null;
            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Versao> versaoRepository = new Repository<Versao>(context, unitOfWork);
                    IVersaoService versaoService = new VersaoService(versaoRepository);

                    ret = versaoService.Find(VersaoId);
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = null;
            }
            return ret;
        }

        public List<Versao> ListarVersoes()
        {
            List<Versao> ret = null;
            try
            {
                ret = new List<Versao>();
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Versao> versaoRepository = new Repository<Versao>(context, unitOfWork);
                    IVersaoService versaoService = new VersaoService(versaoRepository);
                    ret = versaoService.ListarTodosAsVersoes().ToList<Versao>();
                    unitOfWork.Dispose();
                }
            }
            catch
            {
                ret = null;
            }
            return ret;
        }

        public List<Versao> BuscarVersoes(string filtro)
        {
            List<Versao> ret = null;
            try
            {
                ret = new List<Versao>();
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Versao> versaoRepository = new Repository<Versao>(context, unitOfWork);
                    IVersaoService versaoService = new VersaoService(versaoRepository);
                    ret = versaoService.BuscarVersoes(filtro).ToList<Versao>();
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
        public bool ExcluirVersao(Versao versao)
        {
            bool ret = true;

            if (versao == null)
                return false;

            if (versao.VersaoId == Guid.Empty)
                return false;

            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Versao> VersaoRepository = new Repository<Versao>(context, unitOfWork);
                    IVersaoService VersaoService = new VersaoService(VersaoRepository);
                    versao.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Deleted;
                    VersaoService.Delete(versao.VersaoId);
                    unitOfWork.SaveChanges();
                }
            }
            catch
            {
                ret = false;
            }
            return ret;
        }

        //Usuario
        public void NovaVersaoParaExclusao(Usuario usuario, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "D",
                Entidade = usuario.GetType().Name,
                EnitdadeId = usuario.UsuarioId.ToString(),
                Promotor = usuario.CriadoPor,
                Dados = JsonConvert.SerializeObject(usuario)
            });
        }

        //Regra
        public void NovaVersaoParaExclusao(Regra regra, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "D",
                Entidade = regra.GetType().Name,
                EnitdadeId = regra.RegraId.ToString(),
                Promotor = regra.AlteradoPor,
                Dados = JsonConvert.SerializeObject(regra)
            });
        }

        //UsuarioRegra
        public void NovaVersaoParaExclusao(UsuarioRegra usuarioregra, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "D",
                Entidade = usuarioregra.GetType().Name,
                EnitdadeId = string.Format("UsuarioId: {0} | RegraId: {1}", usuarioregra.UsuarioId.ToString(), usuarioregra.RegraId.ToString()),
                Promotor = usuarioregra.AlteradoPor,
                Dados = JsonConvert.SerializeObject(usuarioregra)
            });
        }

        //AnoCalendario
        public void NovaVersaoParaExclusao(AnoCalendario anocalendario, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "D",
                Entidade = anocalendario.GetType().Name,
                EnitdadeId = anocalendario.Ano.ToString(),
                Promotor = anocalendario.AlteradoPor,
                Dados = JsonConvert.SerializeObject(anocalendario)
            });
        }

        //Bloco
        public void NovaVersaoParaExclusao(Bloco bloco, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "D",
                Entidade = bloco.GetType().Name,
                EnitdadeId = bloco.BlocoId.ToString(),
                Promotor = bloco.AlteradoPor,
                Dados = JsonConvert.SerializeObject(bloco)
            });
        }

        //TipoBloco
        public void NovaVersaoParaExclusao(TipoBloco tipobloco, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "D",
                Entidade = tipobloco.GetType().Name,
                EnitdadeId = tipobloco.TipoBlocoId.ToString(),
                Promotor = tipobloco.AlteradoPor,
                Dados = JsonConvert.SerializeObject(tipobloco)
            });
        }

        //Fornecedor
        public void NovaVersaoParaExclusao(Fornecedor fornecedor, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "D",
                Entidade = fornecedor.GetType().Name,
                EnitdadeId = fornecedor.FornecedorId.ToString(),
                Promotor = fornecedor.AlteradoPor,
                Dados = JsonConvert.SerializeObject(fornecedor)
            });
        }

        //Responsave
        public void NovaVersaoParaExclusao(Responsavel responsavel, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "D",
                Entidade = responsavel.GetType().Name,
                EnitdadeId = responsavel.ResponsavelId.ToString(),
                Promotor = responsavel.AlteradoPor,
                Dados = JsonConvert.SerializeObject(responsavel)
            });
        }

        //Status
        public void NovaVersaoParaExclusao(Status status, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "D",
                Entidade = status.GetType().Name,
                EnitdadeId = status.StatusId.ToString(),
                Promotor = status.AlteradoPor,
                Dados = JsonConvert.SerializeObject(status)
            });
        }

        //TipoDePagamento
        public void NovaVersaoParaExclusao(TipoDePagamento tipodepagamento, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "D",
                Entidade = tipodepagamento.GetType().Name,
                EnitdadeId = tipodepagamento.TipoDePagamentoId.ToString(),
                Promotor = tipodepagamento.AlteradoPor,
                Dados = JsonConvert.SerializeObject(tipodepagamento)
            });
        }

        //TipoServico
        public void NovaVersaoParaExclusao(TipoServico tiposervico, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "D",
                Entidade = tiposervico.GetType().Name,
                EnitdadeId = tiposervico.TipoServicoId.ToString(),
                Promotor = tiposervico.AlteradoPor,
                Dados = JsonConvert.SerializeObject(tiposervico)
            });
        }

        //TipoServico
        public void NovaVersaoParaExclusao(Lancamento lancamento, bool Atualizar = false)
        {
            (new Execute()).Sistema.Versao.CriarNovaVersao(new DOMINIO.Model.Sistema.Versao()
            {
                VersaoId = Guid.NewGuid(),
                Momento = DateTime.Now,
                Operacao = "D",
                Entidade = lancamento.GetType().Name,
                EnitdadeId = lancamento.TipoServicoId.ToString(),
                Promotor = lancamento.AlteradoPor,
                Dados = JsonConvert.SerializeObject(lancamento)
            });
        }

        #endregion

    }
}
