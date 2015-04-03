
namespace B2WTI.PCFTI.APLICACAO.Operacao.Build
{
    using System;
    using DOMINIO.Model.Global;
    using APLICACAO.Modulo.Cadastro;

    public class FornecedorBuild
    {

        public Guid CriarNovoFornecedor(Fornecedor fornecedor)
        {
            if (fornecedor == null)
            {
                fornecedor = new Fornecedor();
                fornecedor.FornecedorId = Guid.Empty;
            }

            return fornecedor.FornecedorId;
        }

    }
}
