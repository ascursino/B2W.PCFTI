
namespace B2WTI.PCFTI.TESTE
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using INFRAESTRUTURA.TRANSVERSAL.DataContexts;
    using INFRAESTRUTURA.TRANSVERSAL.UnitOfWork;
    using INFRAESTRUTURA.TRANSVERSAL.Repositories;
    using DOMINIO.Model.Global;
    using INFRAESTRUTURA.HORIZONTAL;
    using B2WTI.PCFTI.APLICACAO.Modulo.Cadastro;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TesteDoCRUDFornecedor()
        {

            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Fornecedor> fornecedorRepository = new Repository<Fornecedor>(context, unitOfWork);
                    IFornecedorService fornecedorService = new FornecedorService(fornecedorRepository);

                    #region CREATE

                    var fornecedor = fornecedorService.NovoFornecedor(
                        new Fornecedor() 
                        { 
                            FornecedorId = Guid.NewGuid(), 
                            CNPJ = "00000000000", 
                            NomeFantasia = "NomeFantasia de Teste", 
                            RazaoSocial = "Razão Social de Teste LTDA", 
                            Ativo = true 
                        });

                    unitOfWork.SaveChanges();

                    if (fornecedor == null)
                        Assert.Fail("O fornecedor retornou nulo ao criar um novo.");

                    #endregion

                    #region READ
                    
                    var fornecedores = fornecedorService.ListarTodosOsFornecedores();

                    if (fornecedores == null)
                        Assert.Fail("A leitura de fornecedores retornou nulo.");

                    if (fornecedores.Count() == 0)
                        Assert.Fail("O objeto foi instanciado, mas não contém nenhum fornecedor definido.");

                    #endregion

                    #region UPDATE

                    var query = from item in fornecedores
                                where item.CNPJ == fornecedor.CNPJ
                                select item;


                    Fornecedor temp = query.ToList<Fornecedor>().FirstOrDefault<Fornecedor>();
                    temp.CNPJ = "111111111";

                    temp.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Modified;
                    fornecedorService.Update(temp);
                    unitOfWork.SaveChanges();

                    #endregion

                    #region DELETE

                    var queryDelete = from item in fornecedores
                                      where item.FornecedorId == fornecedor.FornecedorId
                                      select item;
                    
                    Fornecedor tempDelete = query.ToList<Fornecedor>().FirstOrDefault<Fornecedor>();

                    temp.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Deleted;
                    fornecedorService.Delete(tempDelete);
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
        public void TesteDoCRUDBloco()
        {

            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<Bloco> blocoRepository = new Repository<Bloco>(context, unitOfWork);
                    IBlocoService blocoService = new BlocoService(blocoRepository);

                    #region CREATE

                    var bloco = blocoService.NovoBloco(
                        new Bloco()
                        {
                            BlocoId = Guid.NewGuid(),
                            Descricao = "NOVO BLOCO DE TESTE",    
                            Ativo = true
                        });

                    unitOfWork.SaveChanges();

                    if (bloco == null)
                        Assert.Fail("O bloco retornou nulo ao criar um novo.");

                    #endregion

                    #region READ

                    var blocos = blocoService.ListarTodosOsBlocos();

                    if (blocos == null)
                        Assert.Fail("A leitura de blocos retornou nulo.");

                    if (blocos.Count() == 0)
                        Assert.Fail("O objeto foi instanciado, mas não contém nenhum bloco definido.");

                    #endregion

                    #region UPDATE

                    var query = from item in blocos
                                where item.BlocoId == bloco.BlocoId
                                select item;


                    Bloco temp = query.ToList<Bloco>().FirstOrDefault<Bloco>();
                    temp.Descricao = "NOVO BLOCO DE TESTE 222";

                    temp.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Modified;
                    blocoService.Update(temp);
                    unitOfWork.SaveChanges();

                    #endregion

                    #region DELETE

                    var queryDelete = from item in blocos
                                      where item.BlocoId == bloco.BlocoId
                                      select item;

                    Bloco tempDelete = query.ToList<Bloco>().FirstOrDefault<Bloco>();

                    temp.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Deleted;
                    blocoService.Delete(tempDelete);
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
        public void TesteDoCRUDTipoBloco()
        {

            try
            {
                using (IDataContextAsync context = new PCFTIDataContext())
                using (IUnitOfWorkAsync unitOfWork = new UnitOfWork(context))
                {
                    IRepositoryAsync<TipoBloco> tipoblocoRepository = new Repository<TipoBloco>(context, unitOfWork);
                    ITipoBlocoService tipoblocoService = new TipoBlocoService(tipoblocoRepository);

                    #region CREATE

                    var tipobloco = tipoblocoService.NovoTipoBloco(
                        new TipoBloco()
                        {
                            TipoBlocoId = Guid.NewGuid(),
                            Descricao = "NOVO BLOCO DE TESTE",
                            Ativo = true
                        });

                    unitOfWork.SaveChanges();

                    if (tipobloco == null)
                        Assert.Fail("O Tipo Bloco retornou nulo ao criar um novo.");

                    #endregion

                    #region READ

                    var tipoblocos = tipoblocoService.ListarTodosOsTiposBloco();

                    if (tipoblocos == null)
                        Assert.Fail("A leitura de Tipos Bloco retornou nulo.");

                    if (tipoblocos.Count() == 0)
                        Assert.Fail("O objeto foi instanciado, mas não contém nenhum Tipo Bloco definido.");

                    #endregion

                    #region UPDATE

                    var query = from item in tipoblocos
                                where item.TipoBlocoId == tipobloco.TipoBlocoId
                                select item;


                    TipoBloco temp = query.ToList<TipoBloco>().FirstOrDefault<TipoBloco>();
                    temp.Descricao = "NOVO TIPO DE BLOCO DE TESTE 222";

                    temp.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Modified;
                    tipoblocoService.Update(temp);
                    unitOfWork.SaveChanges();

                    #endregion

                    #region DELETE

                    var queryDelete = from item in tipoblocos
                                      where item.TipoBlocoId == tipobloco.TipoBlocoId
                                      select item;

                    TipoBloco tempDelete = query.ToList<TipoBloco>().FirstOrDefault<TipoBloco>();

                    temp.ObjectState = INFRAESTRUTURA.TRANSVERSAL.Core.States.ObjectState.Deleted;
                    tipoblocoService.Delete(tempDelete);
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
        public void TesteDoCRUDPropriedade()
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
        public void TesteDoCRUDResponsavel()
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
        public void TesteDoCRUDStatus()
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
        public void TesteDoCRUDTipoDePagamento()
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
        public void TesteDoCRUDTipoServico()
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
