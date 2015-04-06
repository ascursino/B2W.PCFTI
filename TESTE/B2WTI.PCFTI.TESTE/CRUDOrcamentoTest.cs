
namespace B2WTI.PCFTI.TESTE
{
    using APLICACAO.Modulo.Cadastro;
    using B2WTI.PCFTI.APLICACAO.Operacao;
    using B2WTI.PCFTI.DOMINIO.Model.Orcamento;
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
    public class CRUDOrcamentoTest
    {
        public Execute Executar = new Execute();

        [TestMethod]
        public void CRUD_Orcamento_Lancamento()
        {
            try
            {

                #region Massa de Testes

                Lancamento objetoTeste = OrcamentoFake.NovoLancamentoFake();

                #endregion

                #region Teste da Criação Unitária

                objetoTeste = Executar.Orcamento.Lancamento.CriarNovoLancamento(objetoTeste);

                if (objetoTeste == null)
                    Assert.Fail("Falha ao testar a criação de um novo Lançamento.");

                #endregion

                #region Teste da Criação em Massa

                //int totalacriar = objetosTeste.Count;
                //objetosTeste = Executar.Orcamento.Lancamento.CriarMuitosNovosLancamentos(objetosTeste);

                //if (objetosTeste == null)
                //    Assert.Fail("Falha ao testar a criação dos novos Lançamentos.");

                //if (objetosTeste.Count == 0)
                //    Assert.Fail("Falha ao testar a criação dos novos Lançamentos. Nenhum tipobloco foi gravado.");

                //if (objetosTeste.Count != totalacriar)
                //    Assert.Fail("Falha ao testar a criação dos novos Lançamentos. A contagem não confere.");

                #endregion

                #region Teste da Atualização Unitária

                AnoCalendario anocalendario = new AnoCalendario()
                {
                    Ano = 2014,
                    Ativo = true
                };
                Executar.Cadastro.AnoCalendario.CriarNovoAnoCalendario(anocalendario);

                objetoTeste.Ano = anocalendario.Ano;
                objetoTeste = Executar.Orcamento.Lancamento.AtualizarLancamento(objetoTeste);

                #endregion

                #region Teste da Atualização em Massa

                //Parallel.ForEach<Lancamento>(objetosTeste, item =>
                //{
                //    //item.Descricao = "Descrição de Teste atualizado";
                //});

                //int totalaatualizar = objetosTeste.Count;

                //objetosTeste = Executar.Orcamento.Lancamento.AtualizarMuitosLancamentos(objetosTeste);

                //if (objetosTeste == null)
                //    Assert.Fail("Falha ao testar a atualização dos Lançamentos.");

                //if (objetosTeste.Count == 0)
                //    Assert.Fail("Falha ao testar a atualização dos Lançamentos. Nenhum Lançamento foi salvo.");

                //if (objetosTeste.Count != totalaatualizar)
                //    Assert.Fail("Falha ao testar a atualização dos Lançamentos. A contagem não confere.");

                #endregion

                #region Teste da Exclusão Unitária

                //bool resultExclusao = Executar.Orcamento.Lancamento.ExcluirLancamento(objetoTeste);

                //if (!resultExclusao)
                //    Assert.Fail("Falha ao testar a exclusão do Lançamento.");

                #endregion

                #region Teste da Exclusão em Massa

                //List<Guid> resultsExlusoes = Executar.Orcamento.Lancamento.ExcluirMuitosLancamentos(objetosTeste);

                //if (resultsExlusoes == null)
                //    Assert.Fail("Falha ao testar a exclusão dos Lançamentos.");

                //if (resultsExlusoes.Count == 0)
                //    Assert.Fail("Falha ao testar a exclusão dos Lançamentos.");

                #endregion

            }
            catch (Exception Ex)
            {
                Assert.Fail(Ex.Message);
            }
        }

    }
}
