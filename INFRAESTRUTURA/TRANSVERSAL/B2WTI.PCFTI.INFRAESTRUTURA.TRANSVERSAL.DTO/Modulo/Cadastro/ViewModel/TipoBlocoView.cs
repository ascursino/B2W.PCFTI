
namespace B2WTI.PCFTI.INFRAESTRUTURA.TRANSVERSAL.DTO.Modulo.Cadastro.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class TipoServicoView
    {

        public Guid TipoServicoId { get; set; }

        [Required(ErrorMessage = "A descrição do Tipo de Servico é requerida.")]
        [DisplayName("Descrição")]
        [MaxLength(250, ErrorMessage="A descrição do Tipo de Servico não pode ter mais de 250 caracteres.")]
        public string Descricao { get; set; }

        public bool Ativo { get; set; }

    }
}