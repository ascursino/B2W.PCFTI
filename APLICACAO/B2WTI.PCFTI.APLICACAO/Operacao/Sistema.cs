
namespace B2WTI.PCFTI.APLICACAO.Operacao
{
    using B2WTI.PCFTI.APLICACAO.Operacao.Build;
    using System;

    public class Sistema
    {

        public Sistema()
        {
            Versao = new VersaoBuild();
            Regra = new RegraBuild();
            Usuario = new UsuarioBuild();
            UsuarioRegra = new UsuarioRegraBuild();
        }

        public VersaoBuild Versao { get; set; }
        public RegraBuild Regra { get; set; }
        public UsuarioBuild Usuario { get; set; }
        public UsuarioRegraBuild UsuarioRegra { get; set; }

    }
}
