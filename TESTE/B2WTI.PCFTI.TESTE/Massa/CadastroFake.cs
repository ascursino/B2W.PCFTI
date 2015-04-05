
namespace B2WTI.PCFTI.TESTE.Massa
{
    using B2WTI.PCFTI.DOMINIO.Model.Global;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class CadastroFake
    {

        #region Fornecedor

        public static Fornecedor NovoFornecedorFake()
        {
            return new Fornecedor() 
            { 
                FornecedorId = Guid.NewGuid(), 
                CNPJ = "0000000010", 
                NomeFantasia = "Nome fantasia de teste", 
                RazaoSocial = "Razão social de teste", 
                Ativo = true 
            };
        }

        public static List<Fornecedor> NovosFornecedoresFake()
        {
            List<Fornecedor> fornecedores = new List<Fornecedor>();

            Parallel.For(0, 9, i =>
            {
                Fornecedor objetoFor = new Fornecedor()
                {
                    FornecedorId = Guid.NewGuid(),
                    CNPJ = string.Format("000000000{0}", i),
                    NomeFantasia = string.Format("Nome fantasia de Teste {0}", i),
                    RazaoSocial = string.Format("Razão social de Teste {0}", i),
                    Ativo = true
                };
                fornecedores.Add(objetoFor);
            });

            return fornecedores;
        }

        #endregion

        #region Bloco

        public static Bloco NovoBlocoFake()
        {
            return new Bloco()
            {
                BlocoId = Guid.NewGuid(),
                Descricao = "Bloco de teste 10",
                Ativo = true
            };
        }

        public static List<Bloco> NovosBlocosFake()
        {
            List<Bloco> blocos = new List<Bloco>();

            Parallel.For(0, 9, i =>
            {
                Bloco objetoFor = new Bloco()
                {
                    BlocoId = Guid.NewGuid(),
                    Descricao = string.Format("Bloco de teste {0}", i),
                    Ativo = true
                };
                blocos.Add(objetoFor);
            });

            return blocos;
        }

        #endregion

        #region Tipo de Bloco

        public static TipoBloco NovoTipoBlocoFake()
        {
            return new TipoBloco()
            {
                TipoBlocoId = Guid.NewGuid(),
                Descricao = "Tipo de Bloco de teste 10",
                Ativo = true
            };
        }

        public static List<TipoBloco> NovosTiposBlocosFake()
        {
            List<TipoBloco> tiposblocos = new List<TipoBloco>();

            Parallel.For(0, 9, i =>
            {
                TipoBloco objetoFor = new TipoBloco()
                {
                    TipoBlocoId = Guid.NewGuid(),
                    Descricao = string.Format("Tipo de Bloco de teste {0}", i),
                    Ativo = true
                };
                tiposblocos.Add(objetoFor);
            });

            return tiposblocos;
        }

        #endregion

        #region Propriedade

        public static Propriedade NovaPropriedadeFake()
        {
            return new Propriedade()
            {
                Ano = 2010,
                Ativo = true
            };
        }

        public static List<Propriedade> NovasPropriedadesFake()
        {
            List<Propriedade> propriedades = new List<Propriedade>();

            Parallel.For(0, 9, i =>
            {
                Propriedade objetoFor = new Propriedade()
                {
                    Ano = 2000 + i,
                    Ativo = true
                };
                propriedades.Add(objetoFor);
            });

            return propriedades;
        }

        #endregion

        #region Responsavel

        public static Responsavel NovoResponsavelFake()
        {
            return new Responsavel()
            {
                ResponsavelId = Guid.NewGuid(),
                Descricao = "Responsavel de teste 10",
                Ativo = true
            };
        }

        public static List<Responsavel> NovosResponsaveisFake()
        {
            List<Responsavel> responsaveis = new List<Responsavel>();

            Parallel.For(0, 9, i =>
            {
                Responsavel objetoFor = new Responsavel()
                {
                    ResponsavelId = Guid.NewGuid(),
                    Descricao = string.Format("Responsavel de teste {0}", i),
                    Ativo = true
                };
                responsaveis.Add(objetoFor);
            });
            return responsaveis;
        }

        #endregion

        #region Status

        public static Status NovoStatusFake()
        {
            return new Status()
            {
                StatusId = Guid.NewGuid(),
                Descricao = "Status de teste 10",
                Ativo = true
            };
        }

        public static List<Status> NovosStatusFake()
        {
            List<Status> status = new List<Status>();

            Parallel.For(0, 9, i =>
            {
                Status objetoFor = new Status()
                {
                    StatusId = Guid.NewGuid(),
                    Descricao = string.Format("Status de teste {0}", i),
                    Ativo = true
                };
                status.Add(objetoFor);
            });
            return status;
        }

        #endregion

        #region TipoDePagamento

        public static TipoDePagamento NovoTipoDePagamentoFake()
        {
            return new TipoDePagamento()
            {
                TipoDePagamentoId = Guid.NewGuid(),
                Descricao = "Tipo de Pagamento de teste 10",
                Ativo = true
            };
        }

        public static List<TipoDePagamento> NovosTiposDePagamentoFake()
        {
            List<TipoDePagamento> tipodepagamento = new List<TipoDePagamento>();

            Parallel.For(0, 9, i =>
            {
                TipoDePagamento objetoFor = new TipoDePagamento()
                {
                    TipoDePagamentoId = Guid.NewGuid(),
                    Descricao = string.Format("Tipos de Pagamento de teste {0}", i),
                    Ativo = true
                };
                tipodepagamento.Add(objetoFor);
            });
            return tipodepagamento;
        }

        #endregion

        #region TipoServico

        public static TipoServico NovoTipoServicoFake()
        {
            return new TipoServico()
            {
                TipoServicoId = Guid.NewGuid(),
                Descricao = "Tipo de Serviço de teste 10",
                Ativo = true
            };
        }

        public static List<TipoServico> NovosTiposServicosFake()
        {
            List<TipoServico> tiposervico = new List<TipoServico>();

            Parallel.For(0, 9, i =>
            {
                TipoServico objetoFor = new TipoServico()
                {
                    TipoServicoId = Guid.NewGuid(),
                    Descricao = string.Format("Tipos de Serviços de teste {0}", i),
                    Ativo = true
                };
                tiposervico.Add(objetoFor);
            });
            return tiposervico;
        }

        #endregion

    }
}
