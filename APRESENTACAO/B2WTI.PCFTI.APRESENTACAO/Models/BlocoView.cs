
namespace B2WTI.PCFTI.APRESENTACAO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;

    public class BlocoView
    {

        public Guid BlocoId { get; set; }

        [Required(ErrorMessage = "A descrição do Bloco é requerida.")]
        [DisplayName("Descrição")]
        [MaxLength(250, ErrorMessage="A descrição do bloco não pode ter mais de 250 caracteres.")]
        public string Descricao { get; set; }

        public bool Ativo { get; set; }

    }
}