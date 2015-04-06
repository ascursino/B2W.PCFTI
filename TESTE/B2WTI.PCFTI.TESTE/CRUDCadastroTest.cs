
namespace B2WTI.PCFTI.TESTE
{
    using APLICACAO.Modulo.Cadastro;
    using B2WTI.PCFTI.APLICACAO.Operacao;
    using B2WTI.PCFTI.TESTE.Massa;
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
                Fornecedor objetoTeste = CadastroFake.NovoFornecedorFake();
                List<Fornecedor> objetosTeste = CadastroFake.NovosFornecedoresFake();

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

                Bloco objetoTeste = CadastroFake.NovoBlocoFake();
                List<Bloco> objetosTeste = CadastroFake.NovosBlocosFake();

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

                TipoBloco objetoTeste = CadastroFake.NovoTipoBlocoFake();
                List<TipoBloco> objetosTeste = CadastroFake.NovosTiposBlocosFake();

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
        public void CRUD_Cadastro_AnoCalendario()
        {
            try
            {

                #region Massa de Testes

                AnoCalendario objetoTeste = CadastroFake.NovoAnoCalendarioFake();
                List<AnoCalendario> objetosTeste = CadastroFake.NovosAnosCalendarioFake();

                #endregion

                #region Teste da Criação Unitária

                objetoTeste = Executar.Cadastro.AnoCalendario.CriarNovoAnoCalendario(objetoTeste);

                if (objetoTeste == null)
                    Assert.Fail("Falha ao testar a criação de um novo Ano Calendário.");

                #endregion

                #region Teste da Criação em Massa

                int totalacriar = objetosTeste.Count;
                objetosTeste = Executar.Cadastro.AnoCalendario.CriarMuitosNovosAnoCalendarios(objetosTeste);

                if (objetosTeste == null)
                    Assert.Fail("Falha ao testar a criação dos novos Anos Calendário.");

                if (objetosTeste.Count == 0)
                    Assert.Fail("Falha ao testar a criação dos novos Anos Calendário. Nenhum ano calendário foi gravado.");

                if (objetosTeste.Count != totalacriar)
                    Assert.Fail("Falha ao testar a criação dos novos Anos Calendário. A contagem não confere.");

                #endregion

                #region Teste da Atualização Unitária

                objetoTeste.Ativo = false;
                objetoTeste = Executar.Cadastro.AnoCalendario.AtualizarAnoCalendario(objetoTeste);

                #endregion

                #region Teste da Atualização em Massa

                Parallel.ForEach<AnoCalendario>(objetosTeste, item =>
                {
                    item.Ativo = false;
                });

                int totalaatualizar = objetosTeste.Count;

                objetosTeste = Executar.Cadastro.AnoCalendario.AtualizarMuitosAnoCalendarios(objetosTeste);

                if (objetosTeste == null)
                    Assert.Fail("Falha ao testar a atualização dos Anos Calendários.");

                if (objetosTeste.Count == 0)
                    Assert.Fail("Falha ao testar a atualização dos Anos Calendários. Nenhum ano calendário foi salvo.");

                if (objetosTeste.Count != totalaatualizar)
                    Assert.Fail("Falha ao testar a atualização dos Anos Calendários. A contagem não confere.");

                #endregion

                #region Teste da Exclusão Unitária

                bool resultExclusao = Executar.Cadastro.AnoCalendario.ExcluirAnoCalendario(objetoTeste);

                if (!resultExclusao)
                    Assert.Fail("Falha ao testar a exclusão do tipo de bloco.");

                #endregion

                #region Teste da Exclusão em Massa

                List<int> resultsExlusoes = Executar.Cadastro.AnoCalendario.ExcluirMuitosAnosCalendario(objetosTeste);

                if (resultsExlusoes == null)
                    Assert.Fail("Falha ao testar a exclusão dos Anos Calendários.");

                if (resultsExlusoes.Count == 0)
                    Assert.Fail("Falha ao testar a exclusão dos Anos Calendários.");

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

                Responsavel objetoTeste = CadastroFake.NovoResponsavelFake();
                List<Responsavel> objetosTeste = CadastroFake.NovosResponsaveisFake();
                
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

                Status objetoTeste = CadastroFake.NovoStatusFake();
                List<Status> objetosTeste = CadastroFake.NovosStatusFake();

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

        [TestMethod]
        public void CRUD_Cadastro_TipoDePagamento()
        {
            try
            {

                #region Massa de Testes

                TipoDePagamento objetoTeste = CadastroFake.NovoTipoDePagamentoFake();
                List<TipoDePagamento> objetosTeste = CadastroFake.NovosTiposDePagamentoFake();

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

                TipoServico objetoTeste = CadastroFake.NovoTipoServicoFake();
                List<TipoServico> objetosTeste = CadastroFake.NovosTiposServicosFake();

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
