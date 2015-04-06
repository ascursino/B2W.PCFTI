
namespace B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Cadastro.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class FornecedorView
    {

        public Guid FornecedorId { get; set; }
        
        [Required(ErrorMessage = "O CNPJ é requerido.")]
        [DisplayName("CNPJ")]
        [MaxLength(250, ErrorMessage = "O CNPJ deve conter entre")]
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }

        public bool Ativo { get; set; }

    }
}