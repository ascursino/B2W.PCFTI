
namespace B2WTI.PCFTI.APLICACAO.Operacao
{
    using System;
    using DOMINIO.Model.Global;
    using DOMINIO.Model.Orcamento;

    public class Execute
    {
        public Execute()
        {
            Cadastro = new Cadastro();
            Orcamento = new Orcamento();
        }

        public Cadastro Cadastro { get; set; }
        public Orcamento Orcamento { get; set; }

    }
}
