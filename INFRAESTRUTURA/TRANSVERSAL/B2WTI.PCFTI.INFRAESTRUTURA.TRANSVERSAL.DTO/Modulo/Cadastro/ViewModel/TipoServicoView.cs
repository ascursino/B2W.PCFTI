
namespace B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Cadastro.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class TipoBlocoView
    {

        public Guid TipoBlocoId { get; set; }

        [Required(ErrorMessage = "A descrição do Tipo de Bloco é requerida.")]
        [DisplayName("Descrição")]
        [MaxLength(250, ErrorMessage="A descrição do Tipo de bloco não pode ter mais de 250 caracteres.")]
        public string Descricao { get; set; }

        public bool Ativo { get; set; }

    }
}