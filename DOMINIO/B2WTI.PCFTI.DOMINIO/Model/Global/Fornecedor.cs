
namespace B2WTI.PCFTI.DOMINIO.Model.Global
{
    using INFRAESTRUTURA.TRANSVERSAL.Base;
    using System;

    public partial class Fornecedor : Entity
    {

        public Guid FornecedorId { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }

        public bool Ativo { get; set; }

    }



}
