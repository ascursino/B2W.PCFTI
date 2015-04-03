
namespace B2WTI.PCFTI.TESTE
{
    using APLICACAO.Modulo.Cadastro;
    using B2WTI.PCFTI.APLICACAO.Operacao;
    using DOMINIO.Model.Global;
    using INFRAESTRUTURA.HORIZONTAL;
    using INFRAESTRUTURA.TRANSVERSAL.DataContexts;
    using INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using INFRAESTRUTURA.TRANSVERSAL.UnitOfWork;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [TestClass]
    public class CRUDCadastroTest
    {

        public Execute Executar = new Execute();

        [TestMethod]
        public void CRUD_Cadastro_Fornecedor()
        {
            try
            {

                #region Massa de Testes

                //Unidade
                Fornecedor objetoTeste = new Fornecedor()
                {
                    FornecedorId = Guid.NewGuid(),
                    CNPJ = "0000000010",
                    NomeFantasia = "Nome Fantasia de Teste 10",
                    RazaoSocial = "Razão Social de Teste 10",
                    Ativo = true
                };

                //Coleção
                List<Fornecedor> objetosTeste = new List<Fornecedor>();
                Parallel.For(0, 10, i =>
                {
                    Fornecedor objetoFor = new Fornecedor()
                    {
                        FornecedorId = Guid.NewGuid(),
                        CNPJ = string.Format("000000000{0}", i),
                        NomeFantasia = string.Format("Nome Fantasia de Teste {0}", i),
                        RazaoSocial = string.Format("Razão Social de Teste {0}", i),
                        Ativo = true
                    };
                    objetosTeste.Add(objetoFor);
                });

                #endregion

                #region Teste da Criação Unitária

                objetoTeste = Executar.Cadastro.Fornecedor.CriarNovoFornecedor(objetoTeste);

                if (objetoTeste == null)
                    Assert.Fail("Falha ao testar a criação de um novo fornecedor.");

                #endregion

                #region Teste da Criação em Massa

                int totalacriar = objetosTeste.Count;
                objetosTeste = Executar.Cadastro.Fornecedor.CriarMuitosNovosFornecedores(objetosTeste);

                if (objetosTeste == null)
                    Assert.Fail("Falha ao testar a criação dos novos fornecedores.");

                if (objetosTeste.Count == 0)
                    Assert.Fail("Falha ao testar a criação dos novos fornecedores. Nenhum fornecedor foi gravado.");

                if (objetosTeste.Count != totalacriar)
                    Assert.Fail("Falha ao testar a criação dos novos fornecedores. A contagem não confere.");

                #endregion

                #region Teste da Atualização Unitária

                objetoTeste.NomeFantasia = "Nome fantasia de Teste atualizado";
                objetoTeste = Executar.Cadastro.Fornecedor.AtualizarFornecedor(objetoTeste);

                #endregion

                #region Teste da Atualização em Massa

                Parallel.ForEach<Fornecedor>(objetosTeste, item =>
                {
                    item.NomeFantasia = "Nome Fantasia de Teste atualizado";
                });

                int totalaatualizar = objetosTeste.Count;

                objetosTeste = Executar.Cadastro.Fornecedor.AtualizarMuitosFornecedores(objetosTeste);

                if (objetosTeste == null)
                    Assert.Fail("Falha ao testar a atualização dos fornecedores.");

                if (objetosTeste.Count == 0)
                    Assert.Fail("Falha ao testar a atualização dos fornecedores. Nenhum fornecedor foi salvo.");

                if (objetosTeste.Count != totalaatualizar)
                    Assert.Fail("Falha ao testar a atualização dos fornecedores. A contagem não confere.");

                #endregion

                #region Teste da Exclusão Unitária

                bool resultExclusao = Executar.Cadastro.Fornecedor.ExcluirFornecedor(objetoTeste);

                if (!resultExclusao)
                    Assert.Fail("Falha ao testar a exclusão do fornecedore.");

                #endregion

                #region Teste da Exclusão em Massa

                List<Guid> resultsExlusoes = Executar.Cadastro.Fornecedor.ExcluirMuitosFornecedores(objetosTeste);

                if (resultsExlusoes == null)
                    Assert.Fail("Falha ao testar a exclusão dos fornecedores.");

                if (resultsExlusoes.Count == 0)
                    Assert.Fail("Falha ao testar a exclusão dos fornecedores.");

                #endregion

            }
            catch (Exception Ex)
            {
                Assert.Fail(Ex.Message);
            }
        }

        [TestMethod]
        public void CRUD_Cadastro_Bloco()
        {
            try
            {

                #region Massa de Testes

                //Unidade
                Bloco objetoTeste = new Bloco()
                {
                    BlocoId = Guid.NewGuid(),
                    Ativo = true
                };

                //Coleção
                List<Bloco> objetosTeste = new List<Bloco>();
                Parallel.For(0, 10, i =>
                {
                    Bloco objetoFor = new Bloco()
                    {
                        BlocoId = Guid.NewGuid(),
                        Descricao = string.Format("Descrição de Teste {0}", i),
                        Ativo = true
                    };
                    objetosTeste.Add(objetoFor);
                });

                #endregion

                #region Teste da Criação Unitária

                objetoTeste = Executar.Cadastro.Bloco.CriarNovoBloco(objetoTeste);

                if (objetoTeste == null)
                    Assert.Fail("Falha ao testar a criação de um novo bloco.");

                #endregion

                #region Teste da Criação em Massa

                int totalacriar = objetosTeste.Count;
                objetosTeste = Executar.Cadastro.Bloco.CriarMuitosNovosBlocos(objetosTeste);

                if (objetosTeste == null)
                    Assert.Fail("Falha ao testar a criação dos novos blocoes.");

                if (objetosTeste.Count == 0)
                    Assert.Fail("Falha ao testar a criação dos novos blocoes. Nenhum bloco foi gravado.");

                if (objetosTeste.Count != totalacriar)
                    Assert.Fail("Falha ao testar a criação dos novos blocoes. A contagem não confere.");

                #endregion

                #region Teste da Atualização Unitária

                objetoTeste.Descricao = "Descrição de Teste atualizado";
                objetoTeste = Executar.Cadastro.Bloco.AtualizarBloco(objetoTeste);

                #endregion

                #region Teste da Atualização em Massa

                Parallel.ForEach<Bloco>(objetosTeste, item =>
                {
                    item.Descricao = "Descrição de Teste atualizado";
                });

                int totalaatualizar = objetosTeste.Count;

                objetosTeste = Executar.Cadastro.Bloco.AtualizarMuitosBlocos(objetosTeste);

                if (objetosTeste == null)
                    Assert.Fail("Falha ao testar a atualização dos blocos.");

                if (objetosTeste.Count == 0)
                    Assert.Fail("Falha ao testar a atualização dos blocos. Nenhum bloco foi salvo.");

                if (objetosTeste.Count != totalaatualizar)
                    Assert.Fail("Falha ao testar a atualização dos blocos. A contagem não confere.");

                #endregion

                #region Teste da Exclusão Unitária

                bool resultExclusao = Executar.Cadastro.Bloco.ExcluirBloco(objetoTeste);

                if (!resultExclusao)
                    Assert.Fail("Falha ao testar a exclusão do bloco.");

                #endregion

                #region Teste da Exclusão em Massa

                List<Guid> resultsExlusoes = Executar.Cadastro.Bloco.ExcluirMuitosBlocos(objetosTeste);

                if (resultsExlusoes == null)
                    Assert.Fail("Falha ao testar a exclusão dos blocos.");

                if (resultsExlusoes.Count == 0)
                    Assert.Fail("Falha ao testar a exclusão dos blocos.");

                #endregion

            }
            catch (Exception Ex)
            {
                Assert.Fail(Ex.Message);
            }
        }

        [TestMethod]
        public void CRUD_Cadastro_TipoBloco()
        {
            try
            {

                #region Massa de Testes

                //Unidade
                TipoBloco objetoTeste = new TipoBloco()
                {
                    TipoBlocoId = Guid.NewGuid(),
                    Ativo = true
                };

                //Coleção
                List<TipoBloco> objetosTeste = new List<TipoBloco>();
                Parallel.For(0, 10, i =>
                {
                    TipoBloco objetoFor = new TipoBloco()
                    {
                        TipoBlocoId = Guid.NewGuid(),
                        Descricao = string.Format("Descrição de Teste {0}", i),
                        Ativo = true
                    };
                    objetosTeste.Add(objetoFor);
                });

                #endregion

                #region Teste da Criação Unitária

                objetoTeste = Executar.Cadastro.TipoBloco.CriarNovoTipoBloco(objetoTeste);

                if (objetoTeste == null)
                    Assert.Fail("Falha ao testar a criação de um novo tipobloco.");

                #endregion

                #region Teste da Criação em Massa

                int totalacriar = objetosTeste.Count;
                objetosTeste = Executar.Cadastro.TipoBloco.CriarMuitosNovosTiposBlocos(objetosTeste);

                if (objetosTeste == null)
                    Assert.Fail("Falha ao testar a criação dos novos tipos de blocos.");

                if (objetosTeste.Count == 0)
                    Assert.Fail("Falha ao testar a criação dos novos tipos de blocos. Nenhum tipobloco foi gravado.");

                if (objetosTeste.Count != totalacriar)
                    Assert.Fail("Falha ao testar a criação dos novos tipos de blocos. A contagem não confere.");

                #endregion

                #region Teste da Atualização Unitária

                objetoTeste.Descricao = "Descrição de Teste atualizado";
                objetoTeste = Executar.Cadastro.TipoBloco.AtualizarTipoBloco(objetoTeste);

                #endregion

                #region Teste da Atualização em Massa

                Parallel.ForEach<TipoBloco>(objetosTeste, item =>
                {
                    item.Descricao = "Descrição de Teste atualizado";
                });

                int totalaatualizar = objetosTeste.Count;

                objetosTeste = Executar.Cadastro.TipoBloco.AtualizarMuitosTiposBlocos(objetosTeste);

                if (objetosTeste == null)
                    Assert.Fail("Falha ao testar a atualização dos tipoblocos.");

                if (objetosTeste.Count == 0)
                    Assert.Fail("Falha ao testar a atualização dos tipoblocos. Nenhum tipobloco foi salvo.");

                if (objetosTeste.Count != totalaatualizar)
                    Assert.Fail("Falha ao testar a atualização dos tipoblocos. A contagem não confere.");

                #endregion

                #region Teste da Exclusão Unitária

                bool resultExclusao = Executar.Cadastro.TipoBloco.ExcluirTipoBloco(objetoTeste);

                if (!resultExclusao)
                    Assert.Fail("Falha ao testar a exclusão do tipo de bloco.");

                #endregion

                #region Teste da Exclusão em Massa

                List<Guid> resultsExlusoes = Executar.Cadastro.TipoBloco.ExcluirMuitosTiposBlocos(objetosTeste);

                if (resultsExlusoes == null)
                    Assert.Fail("Falha ao testar a exclusão dos tipos de blocos.");

                if (resultsExlusoes.Count == 0)
                    Assert.Fail("Falha ao testar a exclusão dos tipos de blocos.");

                #endregion

            }
            catch (Exception Ex)
            {
                Assert.Fail(Ex.Message);
            }
        }


        //--> ...
        [TestMethod]
        public void CRUD_Cadastro_Propriedade()
        {

            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Propriedade> propriedadeRepository = new Repository<Propriedade>(context, unitOfWork);
                    IPropriedadeService propriedadeService = new PropriedadeService(propriedadeRepository);

                    #region CREATE

                    var propriedade = propriedadeService.NovaPropriedade(
                        new Propriedade()
                        {
                            Ano = 2015,
                            Ativo = true
                        });

                    unitOfWork.SaveChanges();

                    if (propriedade == null)
                        Assert.Fail("A Propriedade retornou nulo ao criar um novo.");

                    #endregion

                    #region READ

                    var propriedades = propriedadeService.ListarTodasAsPropriedades();

                    if (propriedades == null)
                        Assert.Fail("A leitura de Tipos Bloco retornou nulo.");

                    if (propriedades.Count() == 0)
                        Assert.Fail("O objeto foi instanciado, mas não contém nenhum Tipo Bloco definido.");

                    #endregion

                    #region UPDATE

                    var query = from item in propriedades
                                where item.Ano == propriedade.Ano
                                select item;


                    Propriedade temp = query.ToList<Propriedade>().FirstOrDefault<Propriedade>();
                    temp.Ativo = true;

                    temp.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Modified;
                    propriedadeService.Update(temp);
                    unitOfWork.SaveChanges();

                    #endregion

                    #region DELETE

                    var queryDelete = from item in propriedades
                                      where item.Ano == temp.Ano
                                      select item;

                    Propriedade tempDelete = query.ToList<Propriedade>().FirstOrDefault<Propriedade>();

                    temp.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Deleted;
                    propriedadeService.Delete(tempDelete);
                    unitOfWork.SaveChanges();

                    #endregion

                }
            }
            catch (Exception Ex)
            {
                Assert.Fail(Ex.Message);
            }


        }

        [TestMethod]
        public void CRUD_Cadastro_Responsavel()
        {

            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Responsavel> responsavelRepository = new Repository<Responsavel>(context, unitOfWork);
                    IResponsavelService responsavelService = new ResponsavelService(responsavelRepository);

                    #region CREATE

                    var responsavel = responsavelService.NovoResponsavel(
                        new Responsavel()
                        {
                            Ativo = true
                        });

                    unitOfWork.SaveChanges();

                    if (responsavel == null)
                        Assert.Fail("A Responsavel retornou nulo ao criar um novo.");

                    #endregion

                    #region READ

                    var responsaveis = responsavelService.ListarTodosOsResponsaveis();

                    if (responsaveis == null)
                        Assert.Fail("A leitura de Responsaveis retornou nulo.");

                    if (responsaveis.Count() == 0)
                        Assert.Fail("O objeto foi instanciado, mas não contém nenhum responsável definido.");

                    #endregion

                    #region UPDATE

                    var query = from item in responsaveis
                                where item.ResponsavelId == responsavel.ResponsavelId
                                select item;


                    Responsavel temp = query.ToList<Responsavel>().FirstOrDefault<Responsavel>();
                    temp.Ativo = true;

                    temp.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Modified;
                    responsavelService.Update(temp);
                    unitOfWork.SaveChanges();

                    #endregion

                    #region DELETE

                    var queryDelete = from item in responsaveis
                                      where item.ResponsavelId == temp.ResponsavelId
                                      select item;

                    Responsavel tempDelete = query.ToList<Responsavel>().FirstOrDefault<Responsavel>();

                    temp.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Deleted;
                    responsavelService.Delete(tempDelete);
                    unitOfWork.SaveChanges();

                    #endregion

                }
            }
            catch (Exception Ex)
            {
                Assert.Fail(Ex.Message);
            }
        }

        [TestMethod]
        public void CRUD_Cadastro_Status()
        {

            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Status> statusRepository = new Repository<Status>(context, unitOfWork);
                    IStatusService statusService = new StatusService(statusRepository);

                    #region CREATE

                    var _status = statusService.NovoStatus(
                        new Status()
                        {
                            Ativo = true
                        });

                    unitOfWork.SaveChanges();

                    if (_status == null)
                        Assert.Fail("A Status retornou nulo ao criar um novo.");

                    #endregion

                    #region READ

                    var lststatus = statusService.ListarTodosOsStatus();

                    if (lststatus == null)
                        Assert.Fail("A leitura de Responsaveis retornou nulo.");

                    if (lststatus.Count() == 0)
                        Assert.Fail("O objeto foi instanciado, mas não contém nenhum responsável definido.");

                    #endregion

                    #region UPDATE

                    var query = from item in lststatus
                                where item.StatusId == _status.StatusId
                                select item;


                    Status temp = query.ToList<Status>().FirstOrDefault<Status>();
                    temp.Ativo = true;

                    temp.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Modified;
                    statusService.Update(temp);
                    unitOfWork.SaveChanges();

                    #endregion

                    #region DELETE

                    var queryDelete = from item in lststatus
                                      where item.StatusId == temp.StatusId
                                      select item;

                    Status tempDelete = query.ToList<Status>().FirstOrDefault<Status>();

                    temp.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Deleted;
                    statusService.Delete(tempDelete);
                    unitOfWork.SaveChanges();

                    #endregion

                }
            }
            catch (Exception Ex)
            {
                Assert.Fail(Ex.Message);
            }
        }

        [TestMethod]
        public void CRUD_Cadastro_TipoDePagamento()
        {

            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<TipoDePagamento> tipodepagamentoRepository = new Repository<TipoDePagamento>(context, unitOfWork);
                    ITipoDePagamentoService tipodepagamentoService = new TipoDePagamentoService(tipodepagamentoRepository);

                    #region CREATE

                    var _TipoDePagamento = tipodepagamentoService.NovoTipoDePagamento(
                        new TipoDePagamento()
                        {
                            Ativo = true
                        });

                    unitOfWork.SaveChanges();

                    if (_TipoDePagamento == null)
                        Assert.Fail("A TipoDePagamento retornou nulo ao criar um novo.");

                    #endregion

                    #region READ

                    var lstTipoDePagamento = tipodepagamentoService.ListarTodosOsTipoDePagamento();

                    if (lstTipoDePagamento == null)
                        Assert.Fail("A leitura de Responsaveis retornou nulo.");

                    if (lstTipoDePagamento.Count() == 0)
                        Assert.Fail("O objeto foi instanciado, mas não contém nenhum responsável definido.");

                    #endregion

                    #region UPDATE

                    var query = from item in lstTipoDePagamento
                                where item.TipoDePagamentoId == _TipoDePagamento.TipoDePagamentoId
                                select item;


                    TipoDePagamento temp = query.ToList<TipoDePagamento>().FirstOrDefault<TipoDePagamento>();
                    temp.Ativo = true;

                    temp.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Modified;
                    tipodepagamentoService.Update(temp);
                    unitOfWork.SaveChanges();

                    #endregion

                    #region DELETE

                    var queryDelete = from item in lstTipoDePagamento
                                      where item.TipoDePagamentoId == temp.TipoDePagamentoId
                                      select item;

                    TipoDePagamento tempDelete = query.ToList<TipoDePagamento>().FirstOrDefault<TipoDePagamento>();

                    temp.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Deleted;
                    tipodepagamentoService.Delete(tempDelete);
                    unitOfWork.SaveChanges();

                    #endregion

                }
            }
            catch (Exception Ex)
            {
                Assert.Fail(Ex.Message);
            }
        }

        [TestMethod]
        public void CRUD_Cadastro_TipoServico()
        {

            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<TipoServico> TipoServicoRepository = new Repository<TipoServico>(context, unitOfWork);
                    ITipoServicoService TipoServicoService = new TipoServicoService(TipoServicoRepository);

                    #region CREATE

                    var _TipoServico = TipoServicoService.NovoTipoServico(
                        new TipoServico()
                        {
                            Ativo = true
                        });

                    unitOfWork.SaveChanges();

                    if (_TipoServico == null)
                        Assert.Fail("A TipoServico retornou nulo ao criar um novo.");

                    #endregion

                    #region READ

                    var lstTipoServico = TipoServicoService.ListarTodosOsTiposServicos();

                    if (lstTipoServico == null)
                        Assert.Fail("A leitura de Responsaveis retornou nulo.");

                    if (lstTipoServico.Count() == 0)
                        Assert.Fail("O objeto foi instanciado, mas não contém nenhum responsável definido.");

                    #endregion

                    #region UPDATE

                    var query = from item in lstTipoServico
                                where item.TipoServicoId == _TipoServico.TipoServicoId
                                select item;


                    TipoServico temp = query.ToList<TipoServico>().FirstOrDefault<TipoServico>();
                    temp.Ativo = true;

                    temp.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Modified;
                    TipoServicoService.Update(temp);
                    unitOfWork.SaveChanges();

                    #endregion

                    #region DELETE

                    var queryDelete = from item in lstTipoServico
                                      where item.TipoServicoId == temp.TipoServicoId
                                      select item;

                    TipoServico tempDelete = query.ToList<TipoServico>().FirstOrDefault<TipoServico>();

                    temp.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Deleted;
                    TipoServicoService.Delete(tempDelete);
                    unitOfWork.SaveChanges();

                    #endregion

                }
            }
            catch (Exception Ex)
            {
                Assert.Fail(Ex.Message);
            }
        }

    }
}
