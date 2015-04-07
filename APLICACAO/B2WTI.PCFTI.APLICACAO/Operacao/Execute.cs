
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
            Sistema = new Sistema();
        }

        public Cadastro Cadastro { get; set; }
        public Orcamento Orcamento { get; set; }
        public Sistema Sistema { get; set; }

    }
}
