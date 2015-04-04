
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

        [TestMethod]
        public void CRUD_Cadastro_Propriedade()
        {
            try
            {

                #region Massa de Testes

                //Unidade
                Propriedade objetoTeste = new Propriedade()
                {
                    Ano = 9989,
                    Ativo = true
                };

                //Coleção
                List<Propriedade> objetosTeste = new List<Propriedade>();
                Parallel.For(0, 10, i =>
                {
                    Propriedade objetoFor = new Propriedade()
                    {
                        Ano = 9990 + i,
                        Ativo = true
                    };
                    objetosTeste.Add(objetoFor);
                });

                #endregion

                #region Teste da Criação Unitária

                objetoTeste = Executar.Cadastro.Propriedade.CriarNovaPropriedade(objetoTeste);

                if (objetoTeste == null)
                    Assert.Fail("Falha ao testar a criação de um novo propriedade.");

                #endregion

                #region Teste da Criação em Massa

                int totalacriar = objetosTeste.Count;
                objetosTeste = Executar.Cadastro.Propriedade.CriarMuitasNovasPropriedades(objetosTeste);

                if (objetosTeste == null)
                    Assert.Fail("Falha ao testar a criação dos novos tipos de blocos.");

                if (objetosTeste.Count == 0)
                    Assert.Fail("Falha ao testar a criação dos novos tipos de blocos. Nenhum propriedade foi gravado.");

                if (objetosTeste.Count != totalacriar)
                    Assert.Fail("Falha ao testar a criação dos novos tipos de blocos. A contagem não confere.");

                #endregion

                #region Teste da Atualização Unitária

                objetoTeste.Ativo = false;
                objetoTeste = Executar.Cadastro.Propriedade.AtualizarPropriedade(objetoTeste);

                #endregion

                #region Teste da Atualização em Massa

                Parallel.ForEach<Propriedade>(objetosTeste, item =>
                {
                    item.Ativo = false;
                });

                int totalaatualizar = objetosTeste.Count;

                objetosTeste = Executar.Cadastro.Propriedade.AtualizarMuitasPropriedades(objetosTeste);

                if (objetosTeste == null)
                    Assert.Fail("Falha ao testar a atualização das propriedades.");

                if (objetosTeste.Count == 0)
                    Assert.Fail("Falha ao testar a atualização das propriedades. Nenhum propriedade foi salvo.");

                if (objetosTeste.Count != totalaatualizar)
                    Assert.Fail("Falha ao testar a atualização das propriedades. A contagem não confere.");

                #endregion

                #region Teste da Exclusão Unitária

                bool resultExclusao = Executar.Cadastro.Propriedade.ExcluirPropriedade(objetoTeste);

                if (!resultExclusao)
                    Assert.Fail("Falha ao testar a exclusão do tipo de bloco.");

                #endregion

                #region Teste da Exclusão em Massa

                List<int> resultsExlusoes = Executar.Cadastro.Propriedade.ExcluirMuitasPropriedades(objetosTeste);

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

        [TestMethod]
        public void CRUD_Cadastro_Responsavel()
        {
            try
            {

                #region Massa de Testes

                //Unidade
                Responsavel objetoTeste = new Responsavel()
                {
                    ResponsavelId = Guid.NewGuid(),
                    Ativo = true
                };

                //Coleção
                List<Responsavel> objetosTeste = new List<Responsavel>();
                Parallel.For(0, 10, i =>
                {
                    Responsavel objetoFor = new Responsavel()
                    {
                        ResponsavelId = Guid.NewGuid(),
                        Descricao = string.Format("Descrição de Teste {0}", i),
                        Ativo = true
                    };
                    objetosTeste.Add(objetoFor);
                });

                #endregion

                #region Teste da Criação Unitária

                objetoTeste = Executar.Cadastro.Responsavel.CriarNovoResponsavel(objetoTeste);

                if (objetoTeste == null)
                    Assert.Fail("Falha ao testar a criação de um novo responsavel.");

                #endregion

                #region Teste da Criação em Massa

                int totalacriar = objetosTeste.Count;
                objetosTeste = Executar.Cadastro.Responsavel.CriarMuitosNovosResponsaveis(objetosTeste);

                if (objetosTeste == null)
                    Assert.Fail("Falha ao testar a criação dos novos Responsaveis.");

                if (objetosTeste.Count == 0)
                    Assert.Fail("Falha ao testar a criação dos novos Responsaveis. Nenhum responsavel foi gravado.");

                if (objetosTeste.Count != totalacriar)
                    Assert.Fail("Falha ao testar a criação dos novos Responsaveis. A contagem não confere.");

                #endregion

                #region Teste da Atualização Unitária

                objetoTeste.Descricao = "Descrição de Teste atualizado";
                objetoTeste = Executar.Cadastro.Responsavel.AtualizarResponsavel(objetoTeste);

                #endregion

                #region Teste da Atualização em Massa

                Parallel.ForEach<Responsavel>(objetosTeste, item =>
                {
                    item.Descricao = "Descrição de Teste atualizado";
                });

                int totalaatualizar = objetosTeste.Count;

                objetosTeste = Executar.Cadastro.Responsavel.AtualizarMuitosResponsaveis(objetosTeste);

                if (objetosTeste == null)
                    Assert.Fail("Falha ao testar a atualização dos responsavels.");

                if (objetosTeste.Count == 0)
                    Assert.Fail("Falha ao testar a atualização dos responsavels. Nenhum responsavel foi salvo.");

                if (objetosTeste.Count != totalaatualizar)
                    Assert.Fail("Falha ao testar a atualização dos responsavels. A contagem não confere.");

                #endregion

                #region Teste da Exclusão Unitária

                bool resultExclusao = Executar.Cadastro.Responsavel.ExcluirResponsavel(objetoTeste);

                if (!resultExclusao)
                    Assert.Fail("Falha ao testar a exclusão do tipo de bloco.");

                #endregion

                #region Teste da Exclusão em Massa

                List<Guid> resultsExlusoes = Executar.Cadastro.Responsavel.ExcluirMuitosResponsaveis(objetosTeste);

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

        [TestMethod]
        public void CRUD_Cadastro_Status()
        {
            try
            {

                #region Massa de Testes

                //Unidade
                Status objetoTeste = new Status()
                {
                    StatusId = Guid.NewGuid(),
                    Ativo = true
                };

                //Coleção
                List<Status> objetosTeste = new List<Status>();
                Parallel.For(0, 10, i =>
                {
                    Status objetoFor = new Status()
                    {
                        StatusId = Guid.NewGuid(),
                        Descricao = string.Format("Descrição de Teste {0}", i),
                        Ativo = true
                    };
                    objetosTeste.Add(objetoFor);
                });

                #endregion

                #region Teste da Criação Unitária

                objetoTeste = Executar.Cadastro.Status.CriarNovoStatus(objetoTeste);

                if (objetoTeste == null)
                    Assert.Fail("Falha ao testar a criação de um novo Status.");

                #endregion

                #region Teste da Criação em Massa

                int totalacriar = objetosTeste.Count;
                objetosTeste = Executar.Cadastro.Status.CriarMuitosNovosStatus(objetosTeste);

                if (objetosTeste == null)
                    Assert.Fail("Falha ao testar a criação dos novos Status.");

                if (objetosTeste.Count == 0)
                    Assert.Fail("Falha ao testar a criação dos novos Status. Nenhum Status foi gravado.");

                if (objetosTeste.Count != totalacriar)
                    Assert.Fail("Falha ao testar a criação dos novos Status. A contagem não confere.");

                #endregion

                #region Teste da Atualização Unitária

                objetoTeste.Descricao = "Descrição de Teste atualizado";
                objetoTeste = Executar.Cadastro.Status.AtualizarStatus(objetoTeste);

                #endregion

                #region Teste da Atualização em Massa

                Parallel.ForEach<Status>(objetosTeste, item =>
                {
                    item.Descricao = "Descrição de Teste atualizado";
                });

                int totalaatualizar = objetosTeste.Count;

                objetosTeste = Executar.Cadastro.Status.AtualizarMuitosStatus(objetosTeste);

                if (objetosTeste == null)
                    Assert.Fail("Falha ao testar a atualização dos status.");

                if (objetosTeste.Count == 0)
                    Assert.Fail("Falha ao testar a atualização dos status. Nenhum status foi salvo.");

                if (objetosTeste.Count != totalaatualizar)
                    Assert.Fail("Falha ao testar a atualização dos status. A contagem não confere.");

                #endregion

                #region Teste da Exclusão Unitária

                bool resultExclusao = Executar.Cadastro.Status.ExcluirStatus(objetoTeste);

                if (!resultExclusao)
                    Assert.Fail("Falha ao testar a exclusão do tipo de bloco.");

                #endregion

                #region Teste da Exclusão em Massa

                List<Guid> resultsExlusoes = Executar.Cadastro.Status.ExcluirMuitosStatus(objetosTeste);

                if (resultsExlusoes == null)
                    Assert.Fail("Falha ao testar a exclusão dos Status.");

                if (resultsExlusoes.Count == 0)
                    Assert.Fail("Falha ao testar a exclusão dos Status.");

                #endregion

            }
            catch (Exception Ex)
            {
                Assert.Fail(Ex.Message);
            }
        }

        //--> ...

        [TestMethod]
        public void CRUD_Cadastro_TipoDePagamento()
        {
            try
            {

                #region Massa de Testes

                //Unidade
                TipoDePagamento objetoTeste = new TipoDePagamento()
                {
                    TipoDePagamentoId = Guid.NewGuid(),
                    Ativo = true
                };

                //Coleção
                List<TipoDePagamento> objetosTeste = new List<TipoDePagamento>();
                Parallel.For(0, 10, i =>
                {
                    TipoDePagamento objetoFor = new TipoDePagamento()
                    {
                        TipoDePagamentoId = Guid.NewGuid(),
                        Descricao = string.Format("Descrição de Teste {0}", i),
                        Ativo = true
                    };
                    objetosTeste.Add(objetoFor);
                });

                #endregion

                #region Teste da Criação Unitária

                objetoTeste = Executar.Cadastro.TipoDePagamento.CriarNovoTipoDePagamento(objetoTeste);

                if (objetoTeste == null)
                    Assert.Fail("Falha ao testar a criação de um novo TipoDePagamento.");

                #endregion

                #region Teste da Criação em Massa

                int totalacriar = objetosTeste.Count;
                objetosTeste = Executar.Cadastro.TipoDePagamento.CriarMuitosNovosTiposDePagamentos(objetosTeste);

                if (objetosTeste == null)
                    Assert.Fail("Falha ao testar a criação dos novos tipos de pagamentos.");

                if (objetosTeste.Count == 0)
                    Assert.Fail("Falha ao testar a criação dos novos tipos de pagamentos. Nenhum TipoDePagamento foi gravado.");

                if (objetosTeste.Count != totalacriar)
                    Assert.Fail("Falha ao testar a criação dos novos tipos de pagamentos. A contagem não confere.");

                #endregion

                #region Teste da Atualização Unitária

                objetoTeste.Descricao = "Descrição de Teste atualizado";
                objetoTeste = Executar.Cadastro.TipoDePagamento.AtualizarTipoDePagamento(objetoTeste);

                #endregion

                #region Teste da Atualização em Massa

                Parallel.ForEach<TipoDePagamento>(objetosTeste, item =>
                {
                    item.Descricao = "Descrição de Teste atualizado";
                });

                int totalaatualizar = objetosTeste.Count;

                objetosTeste = Executar.Cadastro.TipoDePagamento.AtualizarMuitosTiposDePagamentos(objetosTeste);

                if (objetosTeste == null)
                    Assert.Fail("Falha ao testar a atualização dos TipoDePagamentos.");

                if (objetosTeste.Count == 0)
                    Assert.Fail("Falha ao testar a atualização dos TipoDePagamentos. Nenhum TipoDePagamento foi salvo.");

                if (objetosTeste.Count != totalaatualizar)
                    Assert.Fail("Falha ao testar a atualização dos TipoDePagamentos. A contagem não confere.");

                #endregion

                #region Teste da Exclusão Unitária

                bool resultExclusao = Executar.Cadastro.TipoDePagamento.ExcluirTipoDePagamento(objetoTeste);

                if (!resultExclusao)
                    Assert.Fail("Falha ao testar a exclusão do tipo de bloco.");

                #endregion

                #region Teste da Exclusão em Massa

                List<Guid> resultsExlusoes = Executar.Cadastro.TipoDePagamento.ExcluirMuitosTiposDePagamentos(objetosTeste);

                if (resultsExlusoes == null)
                    Assert.Fail("Falha ao testar a exclusão dos tipos de pagamentos.");

                if (resultsExlusoes.Count == 0)
                    Assert.Fail("Falha ao testar a exclusão dos tipos de pagamentos.");

                #endregion

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

                #region Massa de Testes

                //Unidade
                TipoServico objetoTeste = new TipoServico()
                {
                    TipoServicoId = Guid.NewGuid(),
                    Ativo = true
                };

                //Coleção
                List<TipoServico> objetosTeste = new List<TipoServico>();
                Parallel.For(0, 10, i =>
                {
                    TipoServico objetoFor = new TipoServico()
                    {
                        TipoServicoId = Guid.NewGuid(),
                        Descricao = string.Format("Descrição de Teste {0}", i),
                        Ativo = true
                    };
                    objetosTeste.Add(objetoFor);
                });

                #endregion

                #region Teste da Criação Unitária

                objetoTeste = Executar.Cadastro.TipoServico.CriarNovoTipoServico(objetoTeste);

                if (objetoTeste == null)
                    Assert.Fail("Falha ao testar a criação de um novo TipoServico.");

                #endregion

                #region Teste da Criação em Massa

                int totalacriar = objetosTeste.Count;
                objetosTeste = Executar.Cadastro.TipoServico.CriarMuitosNovosTiposServicos(objetosTeste);

                if (objetosTeste == null)
                    Assert.Fail("Falha ao testar a criação dos novos tipo de servico.");

                if (objetosTeste.Count == 0)
                    Assert.Fail("Falha ao testar a criação dos novos tipo de servico. Nenhum TipoServico foi gravado.");

                if (objetosTeste.Count != totalacriar)
                    Assert.Fail("Falha ao testar a criação dos novos tipo de servico. A contagem não confere.");

                #endregion

                #region Teste da Atualização Unitária

                objetoTeste.Descricao = "Descrição de Teste atualizado";
                objetoTeste = Executar.Cadastro.TipoServico.AtualizarTipoServico(objetoTeste);

                #endregion

                #region Teste da Atualização em Massa

                Parallel.ForEach<TipoServico>(objetosTeste, item =>
                {
                    item.Descricao = "Descrição de Teste atualizado";
                });

                int totalaatualizar = objetosTeste.Count;

                objetosTeste = Executar.Cadastro.TipoServico.AtualizarMuitosTiposServicos(objetosTeste);

                if (objetosTeste == null)
                    Assert.Fail("Falha ao testar a atualização dos TipoServicos.");

                if (objetosTeste.Count == 0)
                    Assert.Fail("Falha ao testar a atualização dos TipoServicos. Nenhum TipoServicofoi salvo.");

                if (objetosTeste.Count != totalaatualizar)
                    Assert.Fail("Falha ao testar a atualização dos TipoServicos. A contagem não confere.");

                #endregion

                #region Teste da Exclusão Unitária

                bool resultExclusao = Executar.Cadastro.TipoServico.ExcluirTipoServico(objetoTeste);

                if (!resultExclusao)
                    Assert.Fail("Falha ao testar a exclusão do tipo de bloco.");

                #endregion

                #region Teste da Exclusão em Massa

                List<Guid> resultsExlusoes = Executar.Cadastro.TipoServico.ExcluirMuitosTiposServicos(objetosTeste);

                if (resultsExlusoes == null)
                    Assert.Fail("Falha ao testar a exclusão dos tipo de servico.");

                if (resultsExlusoes.Count == 0)
                    Assert.Fail("Falha ao testar a exclusão dos tipo de servico.");

                #endregion

            }
            catch (Exception Ex)
            {
                Assert.Fail(Ex.Message);
            }
        }

    }
}
